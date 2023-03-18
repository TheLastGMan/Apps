using ArenaChessGameAnalyzer.Core;
using ArenaChessGameAnalyzer.Data;
using ArenaChessGameAnalyzer.Data.Analysis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaChessGameAnalyzer.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //determine mode
                if (args.Length < 1)
                {
                    Console.WriteLine("Expecting [Mode] argument");
                }
                else
                {
                    string[] nonCodeArgs = args.Skip(1).ToArray();
                    switch ((CmdCode)Enum.Parse(typeof(CmdCode), args[0]))
                    {
                        case CmdCode.ValidateEco:
                            validateEco(nonCodeArgs);
                            break;
                        case CmdCode.LastEco:
                            lastEco(nonCodeArgs);
                            break;
                        case CmdCode.Analysis:
                            analyzePgn(nonCodeArgs);
                            break;
                        default:
                            Console.WriteLine("Invalid [mode] argument: " + args[0] + " | Expecting: " + String.Join(", ", Enum.GetNames(typeof(CmdCode))));
                            break;
                    }
                }
                return;
            }
            catch (Exception ex)
            {
                do
                {
                    Console.WriteLine("Error: " + ex.Message);
                } while ((ex = ex.InnerException) != null);
                return;
            }
        }

        static void analyzePgn(string[] args)
        {
            //input files [ECO File] [PGN File] [Report File] [Analysis Log]
            if (args.Length < 4)
            {
                Console.WriteLine("Expecting arguments: [ECO File] [PGN File] [Report File] [Analysis Log]");
                return;
            }

            //run analysis
            string ecoFile = args[0];
            string pgnFile = args[1];
            string rptFile = args[2];
            string anlFile = args[3];

            //basic information
            Console.WriteLine("Reading ECO File");
            var ecoOpenings = EcoReader.ArenaEcoLookup(new FileInfo(ecoFile));
            var pgnPlys = PgnReader.LoadPgn(new FileInfo(pgnFile));

            //find last book move
            Console.WriteLine("Finding last book move");
            var lastBookMove = PgnReader.LastBookPly(pgnPlys, ecoOpenings);

            //load report file
            Console.WriteLine("Reading Report File");
            var rptInfo = ArenaReportReader.ReadReport(new FileInfo(rptFile));

            //load best move analysis
            Console.WriteLine("Reading Arena Log File");
            var logInfo = ArenaAnalysisReader.ReadLog(new FileInfo(anlFile));

            //merge report and move analysis
            Console.WriteLine("Merging Log and Report File");
            var analysisReport = AnalysisReport.CreateAnalysisReport(rptInfo, logInfo);

            //engine analysis report
            Console.WriteLine("Creating Analysis Report");
            var engineReports = AnalysisReport.CreateEngineAnalysisReport(analysisReport, lastBookMove, pgnPlys, ecoOpenings);

            //output directory
            var inputPgn = new FileInfo(pgnFile);
            string pgnOutputDirectory = inputPgn.DirectoryName + "\\analysis\\";
            Directory.CreateDirectory(pgnOutputDirectory);

            //statistical analysis
            Console.WriteLine("Creating Statistics");
            var statistics = AnalysisReport.GenerateStatistics(engineReports);
            foreach (var statistic in statistics)
            {
                string outputStasticFile = pgnOutputDirectory + statistic.Engine + "_Statistic.xml";
                using (var sw = new StreamWriter(outputStasticFile))
                    XmlSerializer.SerializeToStream(statistic, sw.BaseStream);
            }

            //create output PGNs
            Console.WriteLine("Writing Engine Analysis PGNs");
            foreach (var report in engineReports)
            {
                //save PGN
                string outputPgnFile = pgnOutputDirectory + inputPgn.Name.Substring(0, inputPgn.Name.IndexOf('.')) + "_(" + report.Engine + ").pgn";
                ArenaAnalysisPgn.SaveArenaAnalysisAsPgn(report, inputPgn, new FileInfo(outputPgnFile));

                //save XML
                string outputXmlFile = pgnOutputDirectory + report.Engine + "_Analysis.xml";
                using (var sw = new StreamWriter(outputXmlFile))
                    XmlSerializer.SerializeToStream(report, sw.BaseStream);
            }

            //combine engine analysis reports
            Console.WriteLine("Writing Combined Engine Reports");
            string combinedPgnFile = pgnOutputDirectory + inputPgn.Name;
            var combinedReport = AnalysisReport.CombineEngineReports(engineReports);
            ArenaAnalysisPgn.SaveArenaAnalysisAsPgn(combinedReport, inputPgn, new FileInfo(combinedPgnFile));
            string combinedXmlFile = pgnOutputDirectory + "CombinedReports.xml";
            using (var sw = new StreamWriter(combinedXmlFile))
                XmlSerializer.SerializeToStream(combinedReport, sw.BaseStream);

            //debug mode, break so we can see some results in code
            return;
        }

        static void lastEco(string[] args)
        {
            //input PGN and ECO files
            if (args.Length < 2)
            {
                Console.WriteLine("Expecting [ECO File] and [PGN File] arguments");
                return;
            }

            //find last ECO code
            var bookOpenings = EcoReader.ArenaEcoLookup(new FileInfo(args[0]));
            var pgnData = PgnReader.LoadPgn(new FileInfo(args[1]));
            var bookOpening = PgnReader.LastBookPly(pgnData, bookOpenings);

            //write info to console
            int startingMove = ((bookOpening.PlyNumber - 1) / 2 + 1);
            Console.WriteLine("ECO Code:   " + bookOpening.LastEco.Code);
            Console.WriteLine("ECO Name:   " + bookOpening.LastEco.Name);
            Console.WriteLine("ECO Moves:  " + String.Join(" ", bookOpening.LastEco.Moves));
            Console.WriteLine("Start Move: " + startingMove);
            return;
        }

        static void validateEco(string[] args)
        {
            //validate
            if (args.Length < 1)
            {
                Console.WriteLine("Expecting [Eco File] argument");
                return;
            }

            //load ECO codes
            string ecoFile = args[0];
            var ecoOpenings = EcoReader.ArenaEcoCodes(new FileInfo(ecoFile)).GroupBy(f => f, new EcoLineComparer());

            //VALIDATE ECO CODES
            var duplicatesEcoCodes = ecoOpenings.Where(f => f.Count() > 1).ToList();
            if (duplicatesEcoCodes.Any())
            {
                Console.WriteLine("==========================================================");
                Console.WriteLine("DUPLICATE ECO MOVE SEQUENCES FOUND");

                foreach (var codes in duplicatesEcoCodes)
                {
                    Console.WriteLine("==========================================================");
                    Console.WriteLine("Duplicate Moves For Sequence...");
                    foreach (var code in codes)
                    {
                        Console.WriteLine("* " + code.Code + ": " + code.Name);
                        Console.WriteLine("** (" + String.Join(" ", code.Moves) + ")");
                        Console.WriteLine();
                    }
                }

                Console.WriteLine("==========================================================");
            }
            //------------------
        }
    }
}
