using Connect4.Core;
using Connect4.Core.Heuristics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Connect4.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Board b = new Board();
                Mode m = ModeSelect.SelectMode();

                IPlayer player1;
                IPlayer player2;

                switch (m)
                {
                    case Mode.Ai_Vs_Ai:
                        player1 = new TeamAI(PieceType.P1);
                        player2 = new TeamAI(PieceType.P2);
                        break;
                    case Mode.Human_Vs_Ai:
                        player1 = new TeamPlayer(PieceType.P1);
                        player2 = new TeamAI(PieceType.P2);
                        break;
                    case Mode.Ai_Vs_Human:
                        player1 = new TeamAI(PieceType.P1);
                        player2 = new TeamPlayer(PieceType.P2);
                        break;
                    default:
                        player1 = new TeamPlayer(PieceType.P1);
                        player2 = new TeamPlayer(PieceType.P2);
                        break;
                }

                //pre-game
                player1?.PreGame();
                player2?.PreGame();
                byte moveCount = 1;
                PieceType winner = PieceType.NA;
                var moveHistory = new List<byte>(Board.BoardColumns * Board.BoardRows);

                //play game
                while (true)
                {
                    //draw board on screen
                    DrawBoard(b);

                    //select active player
                    IPlayer activePlayer = (moveCount % 2 == 1) ? player1 : player2;
                    PieceType activePiece = (moveCount % 2 == 1) ? PieceType.P1 : PieceType.P2;

                    //play piece
                    sbyte selectedCol = activePlayer.MakeMove(b);

                    if(selectedCol == -1)
                    {
                        //invalid column, check for tie
                        if (b.ColumnsAvailable)
                            continue;
                        else
                        {
                            //it's a tie
                            System.Console.WriteLine();
                            System.Console.WriteLine("----- TIE GAME -----");
                            System.Console.WriteLine();
                            break;
                        }
                    }

                    //make move
                    sbyte row = b.PutPiece((byte)selectedCol, activePiece);
                    moveHistory.Add((byte)(selectedCol + 1));

                    //check for a win
                    if ((new Core.Heuristics.Win()).WinningPosition(b, (byte)selectedCol, (byte)row, activePiece))
                    {
                        //we have a winner, break
                        winner = activePiece;
                        break;
                    }

                    //increase move counter
                    moveCount += 1;
                }

                //game over
                DrawBoard(b);
                System.Console.WriteLine();
                System.Console.WriteLine("--- Game Over ---");
                System.Console.WriteLine("Player (" + winner.ToString() + ") Wins!");
                System.Console.WriteLine();
                System.Console.WriteLine(String.Join(",", moveHistory));
                System.Console.WriteLine();
                System.Console.WriteLine("Play Again?");
                if (System.Console.ReadKey().KeyChar != 'y')
                    break;
            }
        }

        internal static void DrawBoard(Board board, char na = ' ', char p1 = 'X', char p2 = 'O')
        {
            var counts = new DirectionCounts(board);
            System.Console.Clear();
            System.Console.WriteLine("--------- Connect 4 ---------");
            System.Console.WriteLine("|===========================|");
            for (byte r = Board.BoardRows; r > 0; r--)
            {
                byte ri = (byte)(r - 1);
                System.Console.Write("|");
                //top row -> \|/
                for (byte c = 0; c < Board.BoardColumns; c++)
                {
                    PieceType t = board.GetPiece(ri, c);
                    if (t == PieceType.NA)
                        System.Console.Write("   ");
                    else
                    {
                        // [\]
                        if (counts.piecesToUL(c, ri, t) != 0)
                            System.Console.Write("\\");
                        else
                            System.Console.Write(" ");
                        // [|]
                        if (counts.piecesUp(c, ri, t) != 0)
                            System.Console.Write("|");
                        else
                            System.Console.Write(" ");
                        // [/]
                        if (counts.piecesToUR(c, ri, t) != 0)
                            System.Console.Write("/");
                        else
                            System.Console.Write(" ");
                    }
                    System.Console.Write("|");
                }
                System.Console.WriteLine("");
                System.Console.Write("|");
                //middle row -> -X-
                for (byte c = 0; c < Board.BoardColumns; c++)
                {
                    PieceType t = board.GetPiece(ri, c);
                    if (t == PieceType.NA)
                        System.Console.Write("   ");
                    else
                    {
                        // [-]
                        if (counts.piecesLeft(c, ri, t) != 0)
                            System.Console.Write("-");
                        else
                            System.Console.Write(" ");
                        // [|]
                        if (t == PieceType.P1)
                            System.Console.Write(p1.ToString(), ConsoleColor.Red);
                        else if (t == PieceType.P2)
                            System.Console.Write(p2.ToString(), ConsoleColor.Yellow);
                        else
                            System.Console.Write(na);
                        // [-]
                        if (counts.piecesRight(c, ri, t) != 0)
                            System.Console.Write("-");
                        else
                            System.Console.Write(" ");
                    }
                    System.Console.Write("|");
                }
                System.Console.WriteLine("");
                System.Console.Write("|");
                //bottom row -> /|\
                for (byte c = 0; c < Board.BoardColumns; c++)
                {
                    PieceType t = board.GetPiece(ri, c);
                    if (t == PieceType.NA)
                        System.Console.Write("   ");
                    else
                    {
                        // [/]
                        if (counts.piecesToLL(c, ri, t) != 0)
                            System.Console.Write("/");
                        else
                            System.Console.Write(" ");
                        // [|]
                        if (counts.piecesDown(c, ri, t) != 0)
                            System.Console.Write("|");
                        else
                            System.Console.Write(" ");
                        // [\]
                        if (counts.piecesToLR(c, ri, t) != 0)
                            System.Console.Write("\\");
                        else
                            System.Console.Write(" ");
                    }
                    System.Console.Write("|");
                }
                System.Console.WriteLine("");
                System.Console.WriteLine("|---|---|---|---|---|---|---|");
            }
            System.Console.WriteLine("| 1 | 2 | 3 | 4 | 5 | 6 | 7 |");
            System.Console.WriteLine("|===========================|");
            System.Console.WriteLine("");
        }
    }
}
