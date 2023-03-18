using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Connect4.Core
{
    public class AIV2 : AI
    {
        public new AIMoveSummary MakeMove(Board board, PieceType piece, int depth)
        {
            //check for opening move, as proven by research, chose the middle column
            if (board.IsEmpty)
                return new AIMoveSummary() { State = AIMoveState.UNKNOWN, MoveHistory = new MoveInfo[] { new MoveInfo() { Column = 3, Piece = piece, PositionValue = 0 } } };

            //init move container
            List<AIMoveInfo> moves = NavigateOneLevel(new AIMoveInfo() { Board = board }, piece);

            //depth search
            bool initialDepth = true;
            while (depth != 0)
            {
                depth -= 1;

                //depth piece
                PieceType currentPiece = moves.First().Move.Piece;
                PieceType nextPiece = moves.First().Move.Piece == PieceType.P1 ? PieceType.P2 : PieceType.P1;

                //group by their values
                var moveGroups = moves
                                    .AsParallel()
                                    .GroupBy(f => f.Move.PositionValue)
                                    .OrderByDescending(f => f.Key)
                                    .ToList();

                //value check
                if (initialDepth && moveGroups.First().Key > 0)
                    //take the win or block
                    return createSummary(moveGroups.First().ToList(), piece, true, true, false);
                else if (moveGroups.First().Key == short.MaxValue && moveGroups.Count > 1)
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
                        var nonLosingPaths = moves.AsParallel()
                                                .GroupBy(f => f.PreviousMoveHistory)
                                                .Where(f => !f.Any(g => g.Move.PositionValue == short.MaxValue))
                                                .SelectMany(f => f);

                        //are they any paths we can avoid
                        if (nonLosingPaths.Any())
                            moves = nonLosingPaths.ToList();
                        else
                        {
                            //remove immediate paths that let the opponent win
                            var nonDirectLosingPaths = moves.AsParallel().Where(f => f.Move.PositionValue != short.MaxValue).ToList();
                            if (nonDirectLosingPaths.Any())
                                moves = nonDirectLosingPaths;
                            else
                                //total loss, no moves where we win
                                return createSummary(moves, piece, true, true);
                        }
                    }
                }
                else if (moves.Count == 1)
                    return createSummary(moves, piece, true, false);
                else
                    moves = moveGroups.First().ToList();

                //update depth, no longer first
                initialDepth = false;

                //value based search, pick nodes where our score edges out on theirs
                var valuedMoveGroupsHistory = moves
                                            .AsParallel()
                                            .GroupBy(f => f.Move.PositionValue)
                                            .OrderByDescending(f => f.Key)
#if DEBUG
                                            .ToList()
#endif
                                            ;

                //for valid move, assign as new moves
                int maxNum = 100000;
                if (valuedMoveGroupsHistory.Any())
                {
                    //limit nodes to a random-ish limit to save memory usage
                    moves = valuedMoveGroupsHistory
                            .First()
                            .OrderBy(f => f.RandomId(maxNum, depth))
                            .Take(maxNum)
                            .ToList();
                }

                //next depth search
                var nextMoves =
                        moves
                        .AsParallel()
                        .SelectMany(f => NavigateOneLevel(f, nextPiece));

                //check for no more depths
                if (!nextMoves.Any())
                    //give best found
                    break;

                //update moves
                moves = nextMoves.ToList();
                moves.TrimExcess();

                continue;
            }

            //give best result
            return createSummary(moves, piece, false, false);
        }
    }
}
