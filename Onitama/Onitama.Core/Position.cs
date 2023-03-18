using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onitama.Core
{
    public class Position : ICloneable, IEqualityComparer<Position>
    {
        #region Common Static Methods

        /// <summary>
        /// Finds the horizontal row that the square is on
        /// </summary>
        /// <param name="sq"></param>
        /// <returns></returns>
        public static Rank RankOf(Square sq)
        {
            BitBoard mask = BitBoard.A1 | BitBoard.B1 | BitBoard.C1 | BitBoard.D1 | BitBoard.E1;
            BitBoard sqBB = MakeBitboard(sq);
            for (Rank r = Rank.One; r < Rank.UB; r++)
            {
                if ((sqBB & mask) > 0)
                    return r;

                //move to next row
                mask = (BitBoard)((int)mask << (int)Square.A2);
            }
            return Rank.None;
        }

        /// <summary>
        /// Finds the vertical file the square is on
        /// </summary>
        /// <param name="sq"></param>
        /// <returns></returns>
        public static File FileOf(Square sq)
        {
            BitBoard mask = BitBoard.A1 | BitBoard.A2 | BitBoard.A3 | BitBoard.A4 | BitBoard.A5;
            BitBoard sqBB = MakeBitboard(sq);

            for (File f = File.A; f < File.UB; f++)
            {
                if ((sqBB & mask) > 0)
                    return f;

                //move to next file
                mask = (BitBoard)((int)mask << (int)Square.B1);
            }
            return File.None;
        }

        /// <summary>
        /// Makes a square using the specified file and rank
        /// </summary>
        /// <param name="f"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static Square MakeSquare(File f, Rank r)
        {
            return (Square)((((int)r - 1) * 5) << ((int)f - 1));
        }

        /// <summary>
        /// Makes a given piece
        /// </summary>
        /// <returns></returns>
        public static Piece MakePiece(Color c, PieceType pt)
        {
            return (Piece)(((int)c << 2) | (int)pt);
        }

        /// <summary>
        /// Create a Bitboard from a mask
        /// </summary>
        /// <param name="sq"></param>
        /// <returns></returns>
        public static BitBoard MakeBitboard(Square sq)
        {
            return (BitBoard)Math.Pow(2, (int)sq);
        }

        /// <summary>
        /// Gets the squares in a given board
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public static Square[] GetSquares(BitBoard board)
        {
            var squares = new LinkedList<Square>();
            for (Square sq = Square.A1; sq < Square.UB; sq++)
            {
                if ((board & BitBoard.A1) > 0)
                    squares.AddLast(sq);

                board = (BitBoard)((int)board >> 1);

                //exit early if no squares left
                if (board == 0)
                    break;
            }

            return squares.ToArray();
        }

        /// <summary>
        /// Bread out a board into individual boards
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public static BitBoard[] BreakOutBoard(BitBoard board)
        {
            var squares = new LinkedList<BitBoard>();
            BitBoard mask = BitBoard.A1;
            for (Square sq = Square.A1; sq < Square.UB; sq++)
            {
                if (((int)mask & (int)sq) > 0)
                    squares.AddLast(mask);

                mask = (BitBoard)((int)mask << 1);
            }

            return squares.ToArray();
        }

        /// <summary>
        /// Combine bit boards into a single board
        /// </summary>
        /// <param name="boards"></param>
        /// <returns></returns>
        public static BitBoard CombineBoards(BitBoard[] boards)
        {
            BitBoard result = 0;
            foreach (var bb in boards)
                result |= bb;
            return result;
        }

        /// <summary>
        /// Rotate the board 180 degrees
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public static BitBoard Rotate(BitBoard board)
        {
            BitBoard rotated = 0;

            foreach (Square sq in GetSquares(board))
            {
                //mirror along the diagonal
                Square newSquare = Square.C3 + (Square.C3 - sq);
                rotated |= MakeBitboard(newSquare);
            }

            return rotated;
        }

        /// <summary>
        /// Get the color of the piece
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Color GetPieceColor(Piece p)
        {
            if (GetPieceType(p) == PieceType.None)
                return Color.NB;

            Color c = (Color)((int)p >> 2);
            return c;
        }

        /// <summary>
        /// Get the type of the piece
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static PieceType GetPieceType(Piece p)
        {
            PieceType pt = (PieceType)((int)p & 0x03);
            return pt;
        }

        #endregion

        //public Square[,,] PieceList = new Square[(int)Color.NB, (int)PieceType.NB, (int)Piece.Max]; //at most 5 pieces per color on board at same time
        public int[,] PieceCount = new int[(int)Color.NB, (int)PieceType.NB];
        public Piece[] Board = new Piece[(int)Square.UB];
        public BitBoard[] ByTypeBB = new BitBoard[(int)PieceType.NB];
        public BitBoard[] ByColorBB = new BitBoard[(int)Color.NB];
        public BitBoard[] BitMask = new BitBoard[(int)Square.UB];

        public Position()
        {
            //fill bit mask
            int mask = 1;
            for (Square s = Square.A1; s < Square.UB; s++)
            {
                BitMask[(int)s] = (BitBoard)mask;
                mask <<= 1;
            }
        }

        public void Clear()
        {
            //piece list
            /*for (Color c = Color.Red; c < Color.NB; c++)
                for (PieceType pt = PieceType.All; pt < PieceType.NB; pt++)
                    for (Piece p = Piece.None; p < Piece.Max; p++)
                        PieceList[(int)c, (int)pt, (int)p] = Square.None;
            */
            //piece type
            for (int i = 0; i < ByTypeBB.Length; i++)
                ByTypeBB[i] = 0;

            //color
            for (int i = 0; i < ByColorBB.Length; i++)
                ByColorBB[i] = 0;

            //board
            for (int i = 0; i < Board.Length; i++)
                Board[i] = Piece.None;

            //piece counts
            for (PieceType i = 0; i < PieceType.NB; i++)
                PieceCount[(int)Color.Red, (int)i] = PieceCount[(int)Color.Blue, (int)i] = 0;
        }

        /// <summary>
        /// Add a piece to the position
        /// </summary>
        /// <param name="sq"></param>
        /// <param name="c"></param>
        /// <param name="pt"></param>
        public void AddPiece(Square sq, Color c, PieceType pt)
        {
            //don't add to an empty square
            if (sq == Square.None)
                return;

            BitBoard bb = BitMask[(int)sq];
            Board[(int)sq] = MakePiece(c, pt);

            ByTypeBB[(int)pt] |= bb;
            ByTypeBB[(int)PieceType.All] |= bb;

            ByColorBB[(int)c] |= bb;
            ByColorBB[(int)Color.All] |= bb;

            PieceCount[(int)c, (int)pt] += 1;
            PieceCount[(int)c, (int)PieceType.All] += 1;
        }

        /// <summary>
        /// Remove a piece from the position
        /// </summary>
        /// <param name="sq"></param>
        /// <param name="c"></param>
        /// <param name="pt"></param>
        public void RemovePiece(Square sq, Color c, PieceType pt)
        {
            //don't remove from a empty square
            if (sq == Square.None)
                return;

            BitBoard bb = BitMask[(int)sq];
            Board[(int)sq] = Piece.None;

            ByTypeBB[(int)pt] ^= bb;
            ByTypeBB[(int)PieceType.All] ^= bb;

            ByColorBB[(int)c] ^= bb;
            ByColorBB[(int)Color.All] ^= bb;

            PieceCount[(int)c, (int)pt] -= 1;
            PieceCount[(int)c, (int)PieceType.All] -= 1;
        }

        /// <summary>
        /// Move a piece from one square to another
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="c"></param>
        /// <param name="pt"></param>
        public void MovePiece(Square from, Square to, Color c, PieceType pt)
        {
            //don't execute the from or to is empty
            if (from == Square.None || to == Square.None)
                return;

            //remove current piece
            RemovePiece(from, c, pt);

            //remove destination piece if one exists
            if(Board[(int)to] != Piece.None)
                RemovePiece(to, GetPieceColor(Board[(int)to]), GetPieceType(Board[(int)to]));

            //add piece to new square
            AddPiece(to, c, pt);
        }

        public void MakeMove(Move move)
        {
            //same as moving the piece for non null moves
            if(move.From != Square.None)
                MovePiece(move.From, move.To, move.PieceColor, move.PieceType);
        }

        public void UndoMove(Move move)
        {
            //don't undo a null move
            if (move.From == Square.None)
                return;

            //move the piece back
            MovePiece(move.To, move.From, move.PieceColor, move.PieceType);

            //add back the captured piece
            if (move.CapturedPiece != Piece.None)
                AddPiece(move.To, GetPieceColor(move.CapturedPiece), GetPieceType(move.CapturedPiece));
        }

        public object Clone()
        {
            Position pos = (Position)this.MemberwiseClone();
            pos.PieceCount = (int[,])this.PieceCount.Clone();
            pos.Board = (Piece[])Board.Clone();
            pos.ByTypeBB = (BitBoard[])ByTypeBB.Clone();
            pos.ByColorBB = (BitBoard[])ByColorBB.Clone();

            return pos;
        }

        public bool Equals(Position x, Position y)
        {
            for (int i = 0; i < x.Board.Length; i++)
                if (x.Board[i] != y.Board[i])
                    return false;

            return true;
        }

        public int GetHashCode(Position obj)
        {
            return obj.Board.GetHashCode();
        }
    }
}
