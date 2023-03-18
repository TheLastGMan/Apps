using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onitama.Core
{
    public class MoveGenerator
    {
        /// <summary>
        /// Generate a set of moves based on the position and player cards
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="playerCards"></param>
        /// <returns></returns>
        public static Move[] GenerateMoves(Position pos, Color player, Card[] playerCards)
        {
            var moves = new LinkedList<Move>();

            //generate moves for each card and piece
            foreach (Card c in playerCards)
            {
                //rotate if blue (player 2)
                BitBoard cardBB = c.Moves;
                if (player == Color.Blue)
                    cardBB = Position.Rotate(cardBB);

                //apply moves to pieces
                Square[] pieces = Position.GetSquares(pos.ByColorBB[(int)player]);
                for (int pSq = 0; pSq < pieces.Length; pSq++)
                {
                    Square s = pieces[pSq];
                    Piece p = pos.Board[(int)s];

                    //adjust board for piece location rank and file
                    var cardPieceBB = generateCardOffset(cardBB, s);

                    //go through moves
                    foreach (var moveSq in Position.GetSquares(cardPieceBB))
                        //check if the move is not our color
                        if (pos.Board[(int)moveSq] == Piece.None)
                        {
                            //check for capture
                            Piece captured = Piece.None;
                            if (pos.Board[(int)moveSq] != Piece.None && Position.GetPieceColor(pos.Board[(int)moveSq]) != player)
                                captured = pos.Board[(int)moveSq];

                            Move m = new Move(s, moveSq, player, Position.GetPieceType(p), c);
                            moves.AddLast(m);
                        }
                        else if (Position.GetPieceColor(pos.Board[(int)moveSq]) != player)
                        {
                            Move m = new Move(s, moveSq, player, Position.GetPieceType(p), c, pos.Board[(int)moveSq]);
                            moves.AddLast(m);
                        }
                }
            }

            //check for no legal moves
            if(!moves.Any())
            {
                //no valid, create null moves
                foreach (Card c in playerCards)
                {
                    Move m = new Move(Square.None, Square.None, player, PieceType.None, c);
                    moves.AddLast(m);
                }

            }

            return moves.ToArray();
        }

        private static BitBoard generateCardOffset(BitBoard cardBB, Square sq)
        {
            //move rank
            Rank sqRank = Position.RankOf(sq);
            File sqFile = Position.FileOf(sq);
            cardBB = (BitBoard)((int)cardBB * Math.Pow(2, 5 * ((int)sqRank - (int)Rank.Three)));
            cardBB &= (BitBoard)0x1FFFFFF; //filter out non squares

            //create mask
            BitBoard mask = BitBoard.A1 | BitBoard.B1 | BitBoard.C1 | BitBoard.D1 | BitBoard.E1;
            double maskPower = Math.Pow(2, (int)sqFile - (int)File.C);
            mask = (BitBoard)((int)mask * maskPower) & mask;
            BitBoard bbMask = (BitBoard)mask;
            for (byte r = 0; r < 4; r++)
            {
                mask = (BitBoard)((int)mask << (int)Square.A2);
                bbMask |= mask;
            }

            //shift card and apply moved mask
            cardBB = (BitBoard)((int)cardBB * maskPower);
            cardBB &= bbMask;
            return cardBB;
        }
    }
}
