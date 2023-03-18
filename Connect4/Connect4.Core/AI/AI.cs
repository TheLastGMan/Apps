using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Connect4.Core
{
    public class AI
    {
        public virtual AIMoveSummary MakeMove(Board board, PieceType piece, int depth)
        {
            //init move container
            List<AIMoveInfo> moves = NavigateOneLevel(new AIMoveInfo() { Board = board }, piece)
                .GroupBy(f => f.Move.PositionValue)
                .OrderByDescending(f => f.Key)
                .First()
                .ToList();

            //depth search
            while (depth-- != 0)
            {
                //depth piece
                PieceType nextPiece = moves.First().Move.Piece == PieceType.P1 ? PieceType.P2 : PieceType.P1;

                //group by their values
                var moveGroups = moves
                                    .AsParallel()
                                    .GroupBy(f => f.Move.PositionValue)
                                    .OrderByDescending(f => f.Key)
                                    .ToList();

                //value check
                if (moves.First().Move.Piece == piece)
                {
                    //out piece, check for win
                    if (moves.Count == 1 && moveGroups.First().Key == 100)
                        //we win no matter what
                        return createSummary(moves, piece, true, true);
                    else if (moveGroups.First().Key == 100)
                        return createSummary(moveGroups.First().ToList(), piece, true, false);
                    else if (moves.Count == 1 && !moves[0].MoveHistory.Any(g => g.PositionValue > 0))
                        //tie
                        return createSummary(moves, piece, true, true, true);
                    else
                        //take best move
                        moves = moveGroups.First().ToList();
                }
                else
                {
                    //opponent piece logic
                    if (moveGroups.First().Key == 100)
                    {
                        //don't navigate down columns that lead to their win
                        var losingColumns = moveGroups.First().Select(f => f.MoveHistory[0].Column).Distinct().ToList();
                        var nonLosingColumnPaths = moves.Where(f => !losingColumns.Contains(f.MoveHistory[0].Column));

                        //if there are any non losing columns, navigate down those first
                        if (nonLosingColumnPaths.Any())
                            moves = nonLosingColumnPaths.ToList();
                        else
                        {
                            //don't traverse down any paths that lead to the node they win by
                            //group by last node
                            var losingPathNodes = moveGroups.First().Select(f => f.MoveHistoryPreviousNodeCSV).ToList();
                            var nonLosingPaths = moves.AsParallel().Where(f => !losingPathNodes.Contains(f.MoveHistoryPreviousNodeCSV));

                            //are they any paths we can avoid
                            if (nonLosingPaths.Any())
                                moves = nonLosingPaths.ToList();
                            else
                            {
                                //remove immediate paths that let the opponent win
                                var nonDirectLosingPaths = moves.AsParallel().Where(f => f.Move.PositionValue != 100).ToList();
                                if (nonDirectLosingPaths.Any())
                                    moves = nonDirectLosingPaths;
                                else
                                    //total loss, no moves where we win
                                    return createSummary(moves, piece, true, true);
                            }
                        }
                    }
                    else
                        //assume they take best option
                        moves = moveGroups.First().ToList();
                }

                //next depth search
                var nextMoves =
                        moves
                        .AsParallel()
                        .SelectMany(f => NavigateOneLevel(f, nextPiece))
                        .ToList();

                //check for no more depths
                if (!nextMoves.Any())
                    //give best found
                    break;

                //update moves
                moves = nextMoves;
            }

            //give best result
            return createSummary(moves, piece, false, false);
        }

        protected AIMoveSummary createSummary(List<AIMoveInfo> moveInfos, PieceType playerPiece, bool endOfSearch, bool sureThing, bool isTie = false)
        {
            //check for not moves
            if (moveInfos.Count == 0)
                return null;

            //selected move
            var moveInfo = moveInfos.ElementAt(new Random().Next(moveInfos.Count));

            //initialize summary with basic info
            var summary = new AIMoveSummary();
            summary.MoveHistory = moveInfo.MoveHistory.ToArray();

            //add in sure-thing modifier
            MoveInfo lastMove = moveInfo.Move;
            lastMove.PositionValue += (sbyte)(sureThing ? 1 : 0);

            //update position value
            if (lastMove.Piece != playerPiece)
                lastMove.PositionValue *= -1;

            //check ending state
            if (!endOfSearch)
                summary.State = AIMoveState.UNKNOWN;
            else if (isTie)
                summary.State = AIMoveState.TIE;
            else if (lastMove.PositionValue == 100)
                summary.State = AIMoveState.YOU_CAN_LOSE;
            else if (lastMove.PositionValue == 101 || lastMove.PositionValue == 51)
                summary.State = AIMoveState.YOU_WILL_LOSE;
            else if (lastMove.PositionValue == -100 || lastMove.PositionValue == -1)
                summary.State = AIMoveState.YOU_CAN_WIN;
            else if (lastMove.PositionValue == -101 || lastMove.PositionValue == -51)
                summary.State = AIMoveState.YOU_WILL_WIN;

            //report
            return summary;
        }

        public List<AIMoveInfo> NavigateOneLevel(AIMoveInfo lastMove, PieceType nextPiece)
        {
            //check the last move was a winning move, dont process futher
            if (lastMove.Move.PositionValue == 100)
                return new List<AIMoveInfo>() { lastMove };

            //find next moves
            var result = new List<AIMoveInfo>(Board.BoardColumns);
            for (byte col = 0; col < Board.BoardColumns; col++)
            {
                if (lastMove.Board.ColumnAvailable(col))
                {
                    //move information
                    MoveInfo moveInfo = new MoveInfo();
                    moveInfo.Column = col;
                    moveInfo.Piece = nextPiece;

                    //ai result
                    AIMoveInfo aiResult = new AIMoveInfo();
                    aiResult.Board = (Board)lastMove.Board.Clone();
                    aiResult.MoveHistory.AddRange(lastMove.MoveHistory);

                    //board value
                    sbyte row = aiResult.Board.PutPiece(col, nextPiece);
                    moveInfo.PositionValue = aiResult.Board.PositionValue(col, (byte)row, nextPiece); 
                    aiResult.MoveHistory.Add(moveInfo);

                    //add to our results
                    result.Add(aiResult);
                }
            }
            result.TrimExcess();
            return result;
        }
    }
}
