using ArenaChessGameAnalyzer.Data;
using ArenaChessGameAnalyzer.Data.Analysis;
using ArenaChessGameAnalyzer.Data.Report;
using ArenaChessGameAnalyzer.Data.ReportAnalysis;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaChessGameAnalyzer.Core
{
    public class AnalysisReport
    {
        public static StatisticalReport GenerateStatistics(EngineAnalysisReport engineAnalysis)
        {
            return new StatisticalReport(engineAnalysis);
        }

        public static IList<StatisticalReport> GenerateStatistics(IList<EngineAnalysisReport> engineAnalysises)
        {
            return engineAnalysises.Select(f => new StatisticalReport(f)).ToList();
        }

        public static ReportAnalysisLog CreateAnalysisReport(ReportLog report, AnalysisLog analysis)
        {
            var log = new ReportAnalysisLog();
            log.CreatedAt = report.CreatedAt;
            log.FinishedAt = report.FinishedAt;
            log.Comment = report.Comment;

            foreach (var move in report.Moves)
            {
                //setup
                var analysisMove = new ReportAnalysisMove(move);

                //find best move for engine
                var bestMoveInfo = analysis.BestMoves.FirstOrDefault(f => f.PlyDepth == analysisMove.PlyDepth);
                var bestMove = bestMoveInfo.BestMoves.FirstOrDefault(f => f.Engine.Equals(analysisMove.Engine));

                //map over values
                if (bestMove != null)
                {
                    analysisMove.PgnMoveNotationBest = bestMove.Notation;
                    analysisMove.BestContinuation = PgnReader.ReplaceMultipleSpaces(bestMove.Line);
                    analysisMove.Depth = bestMove.Depth;
                    analysisMove.PrettyEvaluation = bestMove.Value;
                    log.Moves.Add(analysisMove);
                }
            }

            //filter out any duplicate moves
            log.Moves = log.Moves.GroupBy(f => new { f.PlyDepth, f.Engine }).Select(f => f.First()).OrderBy(f => f.PlyDepth).ThenBy(f => f.Engine).ToList();

            return log;
        }

        public static IList<EngineAnalysisReport> CreateEngineAnalysisReport(ReportAnalysisLog report, LastEcoMove ecoOpening, IList<PgnMove> moves, ILookup<EcoData, EcoData> ecoOpenings)
        {
            var engineReports = new List<EngineAnalysisReport>(4);

            foreach (var engine in report.Moves.GroupBy(f => f.Engine))
            {
                var engineReport = new EngineAnalysisReport(report);
                engineReport.Engine = engine.Key;
                engineReport.BookOpening = $"{ ecoOpening.LastEco.Code }: { ecoOpening.LastEco.Name }";

                //map PGN moves up to last ECO code found
                for (int i = 1; i <= ecoOpening.PlyNumber; i++)
                {
                    //active ECO code
                    var ecoCurrent = ecoOpenings[new EcoData() { Moves = moves.Take(i).Select(f => f.Notation).ToList() }];

                    //create move from PGN and ECO Opening
                    var eMove = moves[i - 1];
                    var aMove = new EngineMoveAnalysis();
                    aMove.PlyDepth = eMove.PlyDepth;
                    aMove.Player = (MoveType)((eMove.PlyDepth - 1) % 2);
                    aMove.FriendlyMoveNotation = eMove.Notation;
                    aMove.FriendlyBestMoveNotation = eMove.Notation;
                    aMove.EngineMoveNotation = eMove.Notation;
                    aMove.EngineBestMoveNotation = eMove.Notation;
                    aMove.IsBestMove = true;
                    aMove.BestContinuation = String.Join(" ", ecoOpening.LastEco.Moves);
                    aMove.Depth = eMove.PlyDepth.ToString();
                    aMove.PrettyEval = "0";
                    aMove.MoveClassification = EngineMoveType.BOOK;
                    //aMove.BestMoveDifference = 0;

                    //add move to report
                    engineReport.Moves.Add(aMove);
                }

                //map moves to output format
                foreach (var eMove in engine.Where(f => f.PlyDepth > ecoOpening.PlyNumber))
                {
                    var aMove = new EngineMoveAnalysis();
                    aMove.PlyDepth = eMove.PlyDepth;
                    aMove.Player = eMove.Player;
                    //aMove.FriendlyMoveNotation = "";
                    aMove.FriendlyBestMoveNotation = eMove.PgnMoveNotationBest;
                    aMove.EngineMoveNotation = eMove.Move;
                    aMove.EngineBestMoveNotation = eMove.BestMove;
                    aMove.IsBestMove = eMove.IsBestMove;
                    aMove.BestContinuation = eMove.BestContinuation;
                    aMove.Depth = eMove.Depth;
                    aMove.PrettyEval = eMove.PrettyEvaluation;
                    //aMove.MoveClassification = null;
                    //aMove.BestMoveDifference = 0;

                    //find friendly move
                    var pgnMove = moves.FirstOrDefault(f => f.PlyDepth == aMove.PlyDepth);
                    if (pgnMove != null || aMove.PlyDepth <= ecoOpening.PlyNumber)
                        //book or valid move, use that
                        aMove.FriendlyMoveNotation = pgnMove.Notation;
                    else
                        //not found, use engine notation for friendly move
                        aMove.FriendlyMoveNotation = eMove.Move;

                    engineReport.Moves.Add(aMove);
                }

                //different PGN logic for being checkmated
                var finalMove = moves.Last();
                if (finalMove.Notation.EndsWith("#"))
                {
                    var eLast = engineReport.Moves.Last();
                    eLast.Depth = String.Empty;
                    eLast.BestContinuation = String.Empty;
                    eLast.PrettyEval = "+M1";
                }

                //map evaluations down to show how our move changed
                for (int i = 1; i < engineReport.Moves.Count; i++)
                {
                    //flip by -1 to change sides
                    string convertedValue = engineReport.Moves[i].PrettyEval;
                    decimal bestVal = 0;
                    if (decimal.TryParse(engineReport.Moves[i].PrettyEval, out bestVal))
                        convertedValue = (bestVal * -1).ToString("0.00");
                    else
                    {
                        //it's a Mate format
                        string mateText = convertedValue.Substring(convertedValue.IndexOf('M'));
                        char mateNotation = convertedValue[0];
                        convertedValue = ((mateNotation == '+') ? "-" : "+") + mateText;
                    }

                    //update with best val
                    engineReport.Moves[i - 1].BestPrettyEval = convertedValue;
                }

                //calculate best move difference and type
                for (int i = 0; i < engineReport.Moves.Count - 1; i++)
                {
                    var move = engineReport.Moves[i];

                    //basic classification
                    if (move.PlyDepth < ecoOpening.PlyNumber)
                    {
                        //find ECO opening up to this code
                        var openingCode = ecoOpenings[new EcoData() { Moves = moves.Take(i + 1).Select(f => f.Notation).ToList() }]?.First();
                        if (openingCode != null)
                            move.Comment = $"BOOK: { openingCode.Code }: { openingCode.Name }";
                        else
                            move.Comment = "BOOK MOVE";

                        //basic information
                        move.MoveClassification = EngineMoveType.BOOK;
                        move.BestContinuation = "";
                        move.PrettyEval = "";
                        move.BestPrettyEval = "";
                        move.Depth = "";
                        continue;
                    }
                    else if (move.PlyDepth == ecoOpening.PlyNumber)
                    {
                        move.MoveClassification = EngineMoveType.BOOK;
                        move.Comment = $"BOOK: { ecoOpening.LastEco.Code }: { ecoOpening.LastEco.Name }";
                        move.BestContinuation = "";
                        move.PrettyEval = "";
                        move.BestPrettyEval = "";
                        move.Depth = "";
                        continue;
                    }
                    else if (move.IsBestMove)
                    {
                        move.MoveClassification = EngineMoveType.BEST;
                        move.Comment = "BEST MOVE";
                        continue;
                    }
                    else if (move.PrettyEval.Contains("M") && move.BestPrettyEval.Contains("M"))
                    {
                        //check if are improving our checkmate sequence
                        int prettyMate = int.Parse(move.PrettyEval.Substring(move.PrettyEval.IndexOf('M') + 1));
                        int bestPrettyMate = int.Parse(move.BestPrettyEval.Substring(move.BestPrettyEval.IndexOf('M') + 1));

                        if (bestPrettyMate >= prettyMate && move.BestPrettyEval.Contains("+"))
                        {
                            //inaccurate if we are the one checkmating
                            move.MoveClassification = EngineMoveType.INACCURATE;
                            move.Comment = "NOT THE BEST CHECKMATE SEQUENCE";
                            move.Variant = move.BestContinuation;
                            move.BestContinuation = String.Empty;
                        }
                        else
                        {
                            //doesn't matter what we do, we are in check
                            move.MoveClassification = EngineMoveType.BEST;
                        }
                        continue;
                    }

                    //figure out centipawn loss for all moves but the last
                    if (i != engineReport.Moves.Count - 1)
                    {
                        //find still-in-mate move nets
                        if (move.PrettyEval.Contains("M") && !move.BestPrettyEval.Contains("M"))
                        {
                            //went out of mate
                            move.MoveClassification = EngineMoveType.INACCURATE;
                            move.BestMoveDifference = decimal.Parse(move.BestPrettyEval);
                            move.Comment = "LOST MATE OPPORTUNITY"; //sanity check, though can an engine really miss a mate
                            move.Variant = move.BestContinuation;
                            move.BestContinuation = String.Empty;
                        }
                        else if (!move.PrettyEval.Contains("M") && move.BestPrettyEval.Contains("M"))
                        {
                            //entered a mating net or a mate was found
                            move.MoveClassification = EngineMoveType.INACCURATE;
                            move.Comment = "MISSDED MATE";
                            move.Variant = move.BestContinuation;
                            move.BestContinuation = String.Empty;
                        }
                        //standard move differences between current and best
                        else
                        {
                            //move difference
                            decimal bestMove = decimal.Parse(move.PrettyEval);
                            decimal nextBestMove = decimal.Parse(move.BestPrettyEval);
                            decimal diff = Math.Abs(nextBestMove - bestMove);
                            move.BestMoveDifference = diff;

                            //move classification
                            if (diff >= 2.0M && nextBestMove <= 4.0M)
                            {
                                //we dropped 2 whole pawn points into only a better position
                                move.MoveClassification = EngineMoveType.BLUNDER;
                                move.Comment = $"BLUNDER: better move: { move.EngineBestMoveNotation }";
                                move.Variant = move.BestContinuation;
                                move.BestContinuation = String.Empty;
                            }
                            else if (diff >= 0.90M && nextBestMove <= 2.0M)
                            {
                                //we dropped a pawn in points into only a slightly better position
                                move.MoveClassification = EngineMoveType.MISTAKE;
                                move.Comment = $"MISTAKE: better move: { move.EngineBestMoveNotation }";
                                move.Variant = move.BestContinuation;
                                move.BestContinuation = String.Empty;
                            }
                            //we care about inaccuracies when our score drops below 1.2
                            //losing the winning edge (in most computer evaluation setups)
                            else if (diff >= 0.30M && nextBestMove < 1.2M)
                            {
                                move.MoveClassification = EngineMoveType.INACCURATE;
                                move.Comment = $"INACCURACY: better move: { move.EngineBestMoveNotation }";
                                move.Variant = move.BestContinuation;
                                move.BestContinuation = String.Empty;
                            }
                            else
                                move.MoveClassification = EngineMoveType.GOOD;
                        }
                    }
                }

                //TODO: determine ending state if last move was best or end of PGN
                //right now, we have full PGN, so last move is the best
                engineReport.Moves.Last().MoveClassification = EngineMoveType.BEST;

                //add report to output
                engineReports.Add(engineReport);
            }

            return engineReports;
        }

        public static EngineAnalysisReport CombineEngineReports(IList<EngineAnalysisReport> reports)
        {
            //quick check
            if (reports.Count == 1)
                return reports[0];

            //start and stop Plys
            int startPly = reports.Min(f => f.Moves.Min(g => g.PlyDepth));
            int stopPly = reports.Max(f => f.Moves.Max(g => g.PlyDepth));

            //setup combined report
            var combinedReport = new EngineAnalysisReport()
            {
                BookOpening = reports[0].BookOpening,
                Comment = reports[0].Comment,
                CreatedAt = reports[0].CreatedAt,
                FinishedAt = reports[0].FinishedAt,
                Engine = "Combined"
            };

            //combine output, for best moves across engines
            for (int ply = startPly; ply <= stopPly; ply++)
            {
                //find best moves for ply
                var plyMoves = reports.SelectMany(f => f.Moves).Where(f => f.PlyDepth == ply).ToList();
                var bestMoves = plyMoves.Where(f => f.IsBestMove).ToList();
                if(bestMoves.Any())
                {
                    //any of these is a best move
                    var best = bestMoves[0];
                    combinedReport.Moves.Add(best);
                }
                else
                {
                    //combine better moves
                    var move = plyMoves.ElementAt(new Random().Next(plyMoves.Count));
                    move.FriendlyBestMoveNotation = $"|{ String.Join(", ", plyMoves.Select(f => f.FriendlyBestMoveNotation).Distinct()) }|";
                    combinedReport.Moves.Add(move);
                }
            }

            return combinedReport;
        }
    }
}
