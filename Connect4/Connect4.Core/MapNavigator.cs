using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Connect4.Core
{
    public class MapNavigator
    {
        private static AI _AI = new AI();
        public void EndGames(Board board, PieceType piece)
        {
            //init move container
            List<AIMoveInfo> moves = _AI.NavigateOneLevel(new AIMoveInfo() { Board = board }, piece)
                .GroupBy(f => f.Move.PositionValue)
                .OrderByDescending(f => f.Key)
                .First()
                .ToList();

            List<AIMoveInfo> endGames = new List<AIMoveInfo>();

            //depth search
            while (true)
            {
                //depth piece
                PieceType nextPiece = moves.First().Move.Piece == PieceType.P1 ? PieceType.P2 : PieceType.P1;

                //group by their values
                var moveGroups = moves
                                    .GroupBy(f => f.Move.PositionValue)
                                    .OrderByDescending(f => f.Key)
                                    .ToList();

                //value check
                if (moves.First().Move.Piece == piece)
                {
                    //out piece, check for win
                    if (moveGroups.First().Key == 100)
                    {
                        endGames.AddRange(moveGroups.First());
                        moves = moveGroups.Skip(1).SelectMany(f => f).ToList();
                    }
                    else
                        moves = moveGroups.SelectMany(f => f).ToList();
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
                            var nonLosingPaths = moves.Where(f => !losingPathNodes.Contains(f.MoveHistoryPreviousNodeCSV));

                            //are they any paths we can avoid
                            if (nonLosingPaths.Any())
                                moves = nonLosingPaths.ToList();
                            else
                            {
                                //remove immediate paths that let the opponent win
                                var nonDirectLosingPaths = moves.Where(f => f.Move.PositionValue != 100).ToList();
                                if (nonDirectLosingPaths.Any())
                                    moves = nonDirectLosingPaths;
                                else
                                {
                                    //total loss, no moves where we win
                                    endGames.AddRange(moves);
                                }
                            }
                        }
                    }
                    else
                        moves = moveGroups.SelectMany(f => f).ToList();
                }

                //next depth search
                var nextMoves =
                        moves
                        .AsParallel()
                        .SelectMany(f => _AI.NavigateOneLevel(f, nextPiece))
                        .ToList();

                //check for no more depths
                if (!nextMoves.Any())
                {
                    endGames.AddRange(moves);
                    break;
                }

                //update moves
                moves = nextMoves;
            }

            writeEnds(endGames.OrderBy(f => f.MoveHistoryCSV).ToList());
        }

        private void writeEnds(List<AIMoveInfo> moves)
        {
            using (var sw = new System.IO.StreamWriter("c:/users/rgau1/desktop/result.txt", true, System.Text.Encoding.ASCII))
                foreach (var m in moves)
                    sw.WriteLine(String.Join("|", m.MoveHistory.Select(f => f.Piece.ToString() + "," + f.Column.ToString() + "," + f.PositionValue.ToString())));
        }
    }
}
