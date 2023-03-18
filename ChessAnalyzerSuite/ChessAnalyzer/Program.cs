using ChessCore;
using ChessCore.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ChessAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            //string fenData = @"3rk2r/1b1p1ppp/p1q2b2/1p1Np3/4P3/P2Q2P1/1PP1NP1P/3R1RK1 w k - 1 1";
            //var fenPos = FEN.FromFEN(fenData);
            //var moves = new MoveFinder().MovesFromFEN(fenData);
            //string fenBoard = fenPos.BoardPosition.GenerateFenCode();
            generateTBNames("c:/users/rgau1/desktop/tb/", 31);
        }

        private static void generateTBNames(string folderPath, int pieces)
        {
            IList<TBNameEntry> setup = new List<TBNameEntry>() { new TBNameEntry() { White = new Piece[] { Piece.King }, Black = new Piece[] { } } };
            for (int i = 2; i <= pieces; i++)
            {
                var pieceGen = TBNameGenerator.TBNameGeneratorIterative(setup);
                Console.WriteLine(i + " | " + pieceGen.Count);

                using (var swn = new StreamWriter(folderPath + i + ".txt"))
                using (var swp = new StreamWriter(folderPath + i + "-p.txt"))
                using (var swa = new StreamWriter(folderPath + i + "-a.txt"))
                    foreach (var l in pieceGen)
                    {
                        string prettyLine = l.PrettyPrint;
                        swa.WriteLine(prettyLine);
                        if (prettyLine.Contains("p"))
                            swp.WriteLine(prettyLine);
                        else
                            swn.WriteLine(prettyLine);
                    }
                setup = pieceGen;
            }
        }
    }
}
