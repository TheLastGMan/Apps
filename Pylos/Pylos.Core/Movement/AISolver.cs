using Pylos.Core.Board;
using Pylos.Core.Position;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Pylos.Core.Movement
{
    public class AISolver
    {
        private Dictionary<TableInfo, PositionInfo> _CachedBoards;
        private List<PositionInfo> _SearchPositions;
        private int _CachedBoardsMaxElements;
        private int _SearchPositionsMaxElements;

        private static Positions[] OpeningQuadrants =
            {
                Positions.L0R0C0 | Positions.L0R0C1 | Positions.L0R1C1,
                Positions.L0R0C0 | Positions.L0R1C0 | Positions.L0R1C1,

                Positions.L0R0C2 | Positions.L0R0C3 | Positions.L0R1C3,
                Positions.L0R0C2 | Positions.L0R1C2 | Positions.L0R1C3,

                Positions.L0R2C0 | Positions.L0R2C1 | Positions.L0R3C1,
                Positions.L0R2C0 | Positions.L0R3C0 | Positions.L0R3C1,

                Positions.L0R2C2 | Positions.L0R2C3 | Positions.L0R3C3,
                Positions.L0R2C2 | Positions.L0R3C2 | Positions.L0R3C3
            };

        public AISolver(short hashSizeMB)
        {
            //hash set size
            long hashSizeB = (long)(hashSizeMB * 1024 * 1024 * 0.2M); //leave room for some overhead
            int hashTypeSizeB = 512; //high estimate
            _CachedBoardsMaxElements = (int)(hashSizeB / hashTypeSizeB);
            _CachedBoards = new Dictionary<TableInfo, PositionInfo>(_CachedBoardsMaxElements, new TableInfoComparer());

            //search size
            long searchSizeB = (long)(hashSizeMB * 1024 * 1024 * 0.8M);
            _SearchPositionsMaxElements = (int)(searchSizeB / hashTypeSizeB);
            _SearchPositions = new List<PositionInfo>(_SearchPositionsMaxElements);
        }

        public PositionInfo MakeMove(BoardInfo boardInfo, PieceType player, Action<PositionInfo> activeBest, Action<PositionInfo> endBest, bool allowLines = false, bool newGame = false, int depth = 7)
        {
            //clean up previous calculations
            _CachedBoards.Clear();
            GC.Collect();

            //create base positions info
            var basePosition = new PositionInfo()
            {
                Board = boardInfo,
                Player = player
            };

            if (depth == 1)
                //return current best
                return bestMove(basePosition, player, allowLines, 1, 1, newGame).OrderByDescending(f => f.LastEvaluation).First();
            else
            {
                //setup
                int baseDepth = 1;
                var currentBests = new List<PositionInfo>();

                //iterative deepening
                for (int i = 1; i <= depth; i++)
                {
                    //load moves
                    newGame = false;
                    var nextBests = bestMove(basePosition, player, allowLines, baseDepth, i, newGame);
                    currentBests = nextBests;
                    var singleBestGroup = currentBests.GroupBy(f => f.LastEvaluation).OrderByDescending(f => f.Key).First();
                    var singleBest = singleBestGroup.ElementAt(new Random().Next(singleBestGroup.Count()));
                    activeBest(singleBest);

                    //after every nth depth, update base to best
                    if (i >= modNumber)
                    {
                        //recreate move stream
                        var bestMove = new PositionInfo()
                        {
                            Player = singleBest.Player,
                            MoveHistory = singleBest.MoveHistory.Take(baseDepth).ToList()
                        };
                        foreach (var move in bestMove.MoveHistory)
                            foreach (var action in move.ActionsApplied)
                                if (action.Action == MoveAction.Place)
                                    MoveConverter.SetPosition(ref bestMove.Board.Table, action.Position, move.Player);
                                else
                                    MoveConverter.ClearPosition(ref bestMove.Board.Table, action.Position);
                        bestMove.Board.Balls.WhiteBalls = (byte)(boardInfo.Balls.WhiteBalls - MoveConverter.CountPlayerBalls(bestMove.Board.Table, PieceType.White));
                        bestMove.Board.Balls.BlackBalls = (byte)(boardInfo.Balls.BlackBalls - MoveConverter.CountPlayerBalls(bestMove.Board.Table, PieceType.Black));

                        //update moves
                        basePosition = bestMove;
                        player = NextPlayer(basePosition.MoveHistory.Last().Player);
                    }
                }

                return currentBests[new Random().Next(currentBests.Count)];
            }
        }

        private List<PositionInfo> bestMove(PositionInfo basePosition, PieceType player, bool allowLines, int currentDepth, int maxDepth, bool newGame)
        {
            //populate available moves
            var moves = potentialMoves(basePosition, player, allowLines);
            var nextMoves = new List<PositionInfo>(moves.Count);

            //check for new game
            if (currentDepth == 1 && newGame)
            {
                //opening move, limit to one quadrant due to mirroring
                //var activeQuad = OpeningQuadrants[new Random().Next(0, OpeningQuadrants.Length)];
                //moves = moves.Where(f => (f.Board.Table.BallMask & activeQuad) > 0).ToList();
            }

            //check for no more moves
            if (!moves.Any() || Math.Abs(basePosition.LastEvaluation) == (short)Points.Win)
                return new List<PositionInfo>() { basePosition };

            //keep searching if we haven't reached our search depth
            if (currentDepth < maxDepth)
            {
                foreach (var move in moves)
                {
                    if (!_CachedBoards.ContainsKey(move.Board.Table))
                    {
                        //check if we can add it to the hash
                        if (_CachedBoards.Count < _CachedBoardsMaxElements)
                            _CachedBoards.Add(move.Board.Table, move);

                        //find next best move
                        var nextBest = bestMove(move, NextPlayer(player), allowLines, currentDepth + 1, maxDepth, newGame);
                        if (nextBest != null)
                            nextMoves.AddRange(nextBest);
                    }
                    else
                    {
                        //load cached move
                        var cacheMove = _CachedBoards[move.Board.Table];

                        //check if our depth is greater, we have a loop
                        if (move.MoveHistory.Count > cacheMove.MoveHistory.Count)
                        {
                            //loop, mark as draw
                            move.LastEvaluation = 0;
                            nextMoves.Add(move);
                        }
                        else if(move.MoveHistory.Count < cacheMove.MoveHistory.Count)
                        {
                            //haven't gotten here yet, just use value
                            move.LastEvaluation = cacheMove.LastEvaluation;
                            nextMoves.Add(move);
                        }
                        else
                        {
                            //keep searching
                            //our move has more depth, keep searching
                            var nextBest = bestMove(move, NextPlayer(player), allowLines, currentDepth + 1, maxDepth, newGame);
                            if (nextBest != null)
                                nextMoves.AddRange(nextBest);
                        }
                    }
                }
            }

            //check for no more moves
            if (!nextMoves.Any())
                nextMoves = moves;

            //mini-max remaining moves
            var grpMoves = nextMoves.GroupBy(f => f.LastEvaluation);
            if (currentDepth % 2 == 1)
            {
                //our player, min their moves
                return grpMoves.OrderBy(f => f.Key).Take(2).SelectMany(f => f).ToList();
            }
            else
            {
                //other player, min our moves
                return grpMoves.OrderByDescending(f => f.Key).Take(2).SelectMany(f => f).ToList();
            }
        }

        private List<PositionInfo> potentialMoves(PositionInfo position, PieceType player, bool allowLines)
        {
            //setup
            var boardPositions = new List<PositionInfo>(24);
            TableInfo tblInfo = position.Board.Table;

            //add in elevated positions
            var elevatedPos = elevatedPositions(position, player);
            boardPositions.AddRange(elevatedPos);

            //find open positions and add them to the list of potentials
            foreach (var opnPos in MoveService.OpenPositions(tblInfo.BallMask))
            {
                //make the move
                MoveConverter.SetPosition(ref tblInfo, opnPos, player);

                //record we added it
                var openPos = (PositionInfo)position.Clone();
                openPos.Board.Table = tblInfo;
                if (player == PieceType.White)
                    openPos.Board.Balls.WhiteBalls -= 1;
                else
                    openPos.Board.Balls.BlackBalls -= 1;
                openPos.Player = player;
                openPos.MoveHistory.Add(new MoveHistoryItem() { Player = player, ActionsApplied = new List<MoveType>() { new MoveType() { Action = MoveAction.Place, Position = opnPos } } });
                boardPositions.Add(openPos);

                //take it back
                MoveConverter.ClearPosition(ref tblInfo, opnPos);

                //==========================
                //if we make a square or a line on a level, we can remove up to two balls
                if (MoveService.MakeSquare(opnPos, Heuristic.MyPieces(tblInfo, player)) || (allowLines && MoveService.MakeLine(opnPos, Heuristic.MyPieces(tblInfo, player))))
                {
                    //make the move
                    MoveConverter.SetPosition(ref tblInfo, opnPos, player);

                    //can remove up to 2 non-locked balls
                    var nonLocked = myNonLockedBalls(tblInfo, player);
                    foreach (var openPos1 in nonLocked)
                    {
                        //remove the first ball
                        MoveConverter.ClearPosition(ref tblInfo, openPos1);

                        //record we added it
                        var remBall1 = (PositionInfo)openPos.Clone();
                        remBall1.Board.Table = tblInfo;
                        if (player == PieceType.White)
                            remBall1.Board.Balls.WhiteBalls += 1;
                        else
                            remBall1.Board.Balls.BlackBalls += 1;
                        remBall1.MoveHistory.Last().ActionsApplied.Add(new MoveType() { Action = MoveAction.Remove, Position = openPos1 });
                        boardPositions.Add(remBall1);

                        //remove second ball
                        var nonLocked2 = myNonLockedBalls(tblInfo, player);
                        foreach (var openPos2 in nonLocked2)
                        {
                            //remove the second ball
                            MoveConverter.ClearPosition(ref tblInfo, openPos2);

                            //record we added it
                            var remBall2 = (PositionInfo)remBall1.Clone();
                            remBall2.Board.Table = tblInfo;
                            if (player == PieceType.White)
                                remBall2.Board.Balls.WhiteBalls += 1;
                            else
                                remBall2.Board.Balls.BlackBalls += 1;
                            remBall2.MoveHistory.Last().ActionsApplied.Add(new MoveType() { Action = MoveAction.Remove, Position = openPos2 });
                            boardPositions.Add(remBall2);

                            //put it back
                            MoveConverter.SetPosition(ref tblInfo, openPos2, player);
                        }

                        //put it back
                        MoveConverter.SetPosition(ref tblInfo, openPos1, player);
                    }

                    //take it back
                    MoveConverter.ClearPosition(ref tblInfo, opnPos);
                }
            }

            //run heuristics
            foreach (var pif in boardPositions)
            {
                //run Heuristic on it
                pif.LastEvaluation = Heuristic.Evalulate(pif, allowLines);
                if (pif.Player != player)
                    pif.LastEvaluation *= -1;
            }

            //give collection of available moves
            return boardPositions;
        }

        private List<PositionInfo> elevatedPositions(PositionInfo position, PieceType player)
        {
            //setup
            var potentialPositions = new List<PositionInfo>();
            var tblInfo = position.Board.Table;

            //find positions we can elevate
            var nonLocked = myNonLockedBalls(position.Board.Table, player);
            foreach (var nlPos in nonLocked)
            {
                Positions elevatedPositions = MoveService.ElevatedPositions(tblInfo.BallMask, nlPos);
                foreach (var elPos in MoveConverter.SplitPositions(elevatedPositions))
                {
                    //remove ball from board and add to elevated position
                    MoveConverter.ClearPosition(ref tblInfo, nlPos);
                    MoveConverter.SetPosition(ref tblInfo, elPos, player);

                    //add to list of potentials
                    var elevatedPosition = (PositionInfo)position.Clone();
                    elevatedPosition.Board.Table = tblInfo;
                    elevatedPosition.Player = player;
                    elevatedPosition.MoveHistory.Add(new MoveHistoryItem() { Player = player, ActionsApplied = new List<MoveType>() { new MoveType() { Action = MoveAction.Remove, Position = nlPos }, new MoveType() { Action = MoveAction.Place, Position = elPos } } });
                    potentialPositions.Add(elevatedPosition);

                    //remove ball from elevated position and put it back
                    MoveConverter.ClearPosition(ref tblInfo, elPos);
                    MoveConverter.SetPosition(ref tblInfo, nlPos, player);
                }
            }

            //give elevated moves
            return potentialPositions;
        }

        private Positions[] myNonLockedBalls(TableInfo table, PieceType player)
        {
            Positions nonLocked = MoveService.NonLockedBalls(table.BallMask);
            nonLocked = player == PieceType.White ? ~table.Pieces & table.BallMask : table.Pieces;
            return MoveConverter.SplitPositions(nonLocked);
        }

        public static PieceType NextPlayer(PieceType player)
        {
            return player == PieceType.White ? PieceType.Black : PieceType.White;
        }
    }
}
