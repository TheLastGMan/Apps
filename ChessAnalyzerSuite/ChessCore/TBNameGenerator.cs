using ChessCore.Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessCore
{
    public class TBNameGenerator
    {
        #region Iterative Generation

        public static IList<TBNameEntry> TBNameGeneratorIterative(IList<TBNameEntry> lastIteration)
        {
            var nextGenNames = new SortedSet<TBNameEntry>(new TableEntryEqualityComparer());

            decimal splitBound = 150000;
            foreach (var split in Enumerable.Range(0, (int)Math.Ceiling(lastIteration.Count / splitBound))
                                                .AsParallel()
                                                .Select(f => iterativeInnerLoop(lastIteration, (int)(f * splitBound), (int)Math.Min((f + 1) * splitBound, lastIteration.Count))))
                foreach (var ngn in split)
                    nextGenNames.Add(ngn);

            return nextGenNames.ToList();
        }

        private static SortedSet<TBNameEntry> iterativeInnerLoop(IList<TBNameEntry> lastIteration, int startIndex, int stopIndex)
        {
            var tableComp = new TableEntryEqualityComparer();
            var nextGenNames = new SortedSet<TBNameEntry>(tableComp);

            //add to white
            for (int i = startIndex; i < stopIndex; i++)
            {
                var entry = lastIteration[i];

                if (entry.Black.Length > 0)
                {
                    //add to white
                    Piece[] newWhite = new Piece[entry.White.Length + 1];
                    Array.Copy(entry.White, newWhite, entry.White.Length);

                    int whiteLastIndex = newWhite.Length - 1;
                    while (newWhite[whiteLastIndex] != Piece.All)
                    {
                        Piece[] newWhiteEntry = (Piece[])newWhite.Clone();
                        Array.Sort(newWhiteEntry);
                        Array.Reverse(newWhiteEntry);

                        //validate
                        if (tbNameValid(newWhiteEntry))
                            nextGenNames.Add(new TBNameEntry() { White = newWhiteEntry, Black = entry.Black });

                        //increment last piece
                        newWhite[whiteLastIndex] += 1;
                    }
                }

                if (entry.White.Length > 0 && entry.Black.Length != entry.White.Length)
                {
                    //add to black
                    Piece[] newBlack = new Piece[entry.Black.Length + 1];
                    Array.Copy(entry.Black, newBlack, entry.Black.Length);

                    int blackLastIndex = newBlack.Length - 1;
                    while (newBlack[blackLastIndex] != Piece.All)
                    {
                        Piece[] newBlackEntry = (Piece[])newBlack.Clone();
                        Array.Sort(newBlackEntry);
                        Array.Reverse(newBlackEntry);

                        //validate
                        if (tbNameValid(newBlackEntry))
                            nextGenNames.Add(new TBNameEntry() { White = entry.White, Black = newBlackEntry });

                        //increment last piece
                        newBlack[blackLastIndex] += 1;
                    }
                }
            }

            return nextGenNames;
        }

        #endregion

        #region Sequential Generation

        public static List<Piece[]> TBNameSequentialGenerator(int pieces)
        {
            return Enumerable.Range(1, (int)Math.Floor(pieces / 2.0M))
                .AsParallel()
                .SelectMany(i => sequentialInnerLoop(pieces, i)).ToList();
        }

        private static IList<Piece[]> sequentialInnerLoop(int pieces, int generate)
        {
            //how many piece combinations to generate for each side
            int whiteGen = pieces - generate;
            int blackGen = generate;

            //generate combinations
            IList<Piece[]> whiteTB = generateTBNames(whiteGen);
            IList<Piece[]> blackTB = whiteTB;
            if (whiteGen != blackGen)
                blackTB = generateTBNames(blackGen);

            var eqComp = new PieceArrayEqualityComparer();
            var ayComp = new PieceArrayComparator();
            var subset = new List<Piece[]>(whiteTB.Count() * blackTB.Count());
            foreach (var w in whiteTB)
                foreach (var b in blackTB)
                {
                    Piece[] subsetCombined = new Piece[w.Length + b.Length];
                    Array.Copy(w, 0, subsetCombined, 0, w.Length);
                    Array.Copy(b, 0, subsetCombined, w.Length, b.Length);

                    Piece[] subsetInverse = new Piece[subsetCombined.Length];
                    Array.Copy(b, 0, subsetInverse, 0, b.Length);
                    Array.Copy(w, 0, subsetInverse, b.Length, w.Length);

                    if (whiteGen != blackGen || !subset.Contains(subsetInverse, eqComp))
                        subset.Add(subsetCombined);
                }

            return subset;
        }

        #endregion

        private static IList<Piece[]> generateTBNames(int pieces)
        {
            var cache = new LinkedList<Piece[]>();
            var generator = new Piece[pieces];
            while (generator[pieces - 1] != Piece.All)
            {
                //check if valid
                if (tbNameValid(generator))
                {
                    //sort to ensure ordering duplicates are not added
                    Piece[] copy = (Piece[])generator.Clone();
                    Array.Sort(copy);
                    Array.Reverse(copy);
                    cache.AddLast(copy);
                }

                //count up until all are checked
                for (int i = 0; i < generator.Length; i++)
                {
                    //increment piece at position
                    generator[i] += 1;

                    //do not move to next slot unless we reached the upper limit
                    if (generator[i] != Piece.All)
                        break;

                    //exit if last one flipped to all
                    if (i == (generator.Length - 1))
                        break;

                    //reset piece and continue if not last slot, next iteration will increment next slot
                    generator[i] = Piece.Pawn;
                }
            }

            var uniqueEntries = cache.Distinct(new PieceArrayEqualityComparer()).ToList();
            return uniqueEntries;
        }

        public static string PiecesToString(Piece[] pieces)
        {
            var sb = new StringBuilder(pieces.Length);
            foreach (Piece p in pieces)
            {
                switch (p)
                {
                    case Piece.King:
                        sb.Append('k');
                        break;
                    case Piece.Queen:
                        sb.Append('q');
                        break;
                    case Piece.Bishop:
                        sb.Append('b');
                        break;
                    case Piece.Knight:
                        sb.Append('n');
                        break;
                    case Piece.Rook:
                        sb.Append('r');
                        break;
                    default:
                        sb.Append('p');
                        break;
                }
            }

            string res = sb.ToString();
            return res;
        }

        private static bool tbNameValid(Piece[] pieces)
        {
            //null check
            if (pieces == null)
                return false;

            //must be between [1, 16] pieces
            if (pieces.Length < 1 || pieces.Length > 16)
                return false;

            //check for invalid pieces
            if (pieces.Any(f => f == Piece.All))
                return false;

            //only allow one king
            int kingCount = pieces.Count(f => f == Piece.King);
            if (kingCount != 1)
                return false;

            //can only have 8 pawns on the board
            int pawnCount = pieces.Count(f => f == Piece.Pawn);
            if (pawnCount > 8)
                return false;

            //check individual piece maximums with missing pawns
            int missingPawns = 8 - pawnCount;
            int queens = pieces.Count(f => f == Piece.Queen);
            int rooks = pieces.Count(f => f == Piece.Rook);
            int knights = pieces.Count(f => f == Piece.Knight);
            int bishops = pieces.Count(f => f == Piece.Bishop);
            if (queens - missingPawns > 1)
                return false;
            if (rooks - missingPawns > 2)
                return false;
            if (knights - missingPawns > 2)
                return false;
            if (bishops - missingPawns > 2)
                return false;

            //check all piece maximums with missing pawns
            int promotedPieces = 0;
            if (queens - 1 > 0)
                promotedPieces += queens - 1;
            if (rooks - 2 > 0)
                promotedPieces += rooks - 2;
            if (knights - 2 > 0)
                promotedPieces += knights - 2;
            if (bishops - 2 > 0)
                promotedPieces += bishops - 2;

            //number of promoted pieces cannot be greater than our missing pawns
            if (promotedPieces > missingPawns)
                return false;

            //limit to practicality, hardly see more than 4 promoted pawns
            if (promotedPieces > 4)
                return false;

            return true;
        }

        private class TableEntryEqualityComparer : IComparer<TBNameEntry>
        {
            private PieceArrayEqualityComparer _PieceComp = new PieceArrayEqualityComparer();
            private PieceArrayComparator _PieceOrder = new PieceArrayComparator();

            public int Compare(TBNameEntry x, TBNameEntry y)
            {
                Piece[] xsm = x.White.Length >= x.Black.Length ? x.White : x.Black;
                Piece[] xlg = x.White.Length < x.Black.Length ? x.White : x.Black;
                Piece[] bsm = y.White.Length >= y.Black.Length ? y.White : y.Black;
                Piece[] blg = y.White.Length < y.Black.Length ? y.White : y.Black;

                if (xsm.Length + xlg.Length == bsm.Length + blg.Length)
                {
                    if (_PieceOrder.Compare(xsm, xlg) > 0)
                    {
                        Piece[] tmp = xlg;
                        xlg = xsm;
                        xsm = tmp;
                    }

                    if (_PieceOrder.Compare(bsm, blg) > 0)
                    {
                        Piece[] tmp = blg;
                        blg = bsm;
                        bsm = tmp;
                    }
                }

                int cp1 = _PieceOrder.Compare(xsm, bsm);
                if (cp1 == 0)
                    return _PieceOrder.Compare(xlg, blg);
                return cp1;
            }

            public int GetHashCode(TBNameEntry obj)
            {
                Piece[] xsm = obj.White.Length >= obj.Black.Length ? obj.White : obj.Black;
                Piece[] xlg = obj.White.Length < obj.Black.Length ? obj.White : obj.Black;


                if (_PieceOrder.Compare(xsm, xlg) > 0)
                {
                    Piece[] tmp = xlg;
                    xlg = xsm;
                    xsm = tmp;
                }

                Piece[] combined = new Piece[obj.White.Length + obj.Black.Length];
                Array.Copy(xsm, 0, combined, 0, xsm.Length);
                Array.Copy(xlg, 0, combined, xsm.Length, xlg.Length);

                return _PieceComp.GetHashCode(combined);
            }
        }

        private class PieceArrayComparator : IComparer<Piece[]>
        {
            public int Compare(Piece[] x, Piece[] y)
            {
                if (x.Length > y.Length)
                    return 1;

                if (x.Length < y.Length)
                    return -1;

                for (int i = 0; i < x.Length; i++)
                    if (x[i] < y[i])
                        return -1;
                    else if (x[i] > y[i])
                        return 1;

                return 0;
            }
        }

        private class PieceArrayEqualityComparer : IEqualityComparer<Piece[]>
        {
            public bool Equals(Piece[] x, Piece[] y)
            {
                if (x.Length != y.Length)
                    return false;

                for (int i = 0; i < x.Length; i++)
                    if (x[i] != y[i])
                        return false;

                return true;
            }

            public int GetHashCode(Piece[] obj)
            {
                return PiecesToString(obj).GetHashCode();
            }
        }
    }
}
