using ArenaChessGameAnalyzer.Data.Report;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ArenaChessGameAnalyzer.Data.ReportAnalysis
{
    [XmlRoot]
    public class EngineAnalysisReport
    {
        public EngineAnalysisReport()
        { }

        public EngineAnalysisReport(ReportAnalysisLog log)
        {
            //my properties
            var myProps = this.GetType().GetProperties().ToList();

            //map properties
            foreach (var prop in log.GetType().GetProperties())
            {
                var myProp = myProps.FirstOrDefault(f => f.Name.Equals(prop.Name));
                if (myProp != null)
                {
                    try
                    {
                        //update ours with the input
                        myProp.SetValue(this, prop.GetValue(log, null));
                    }
                    catch
                    {
                        //do nothing if unable, don't care about those
                    }
                }
            }
        }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime FinishedAt { get; set; } = DateTime.Now;
        public TimeSpan TotalTime
        { get { return FinishedAt.Subtract(CreatedAt); } }

        public string Comment { get; set; } = String.Empty;
        public string Engine { get; set; } = String.Empty;
        public string BookOpening { get; set; } = String.Empty;

        public bool HasWhiteMoves
        { get { return Moves.Any(f => f.Player == MoveType.WHITE); } }
        public bool HasBlackMoves
        { get { return Moves.Any(f => f.Player == MoveType.BLACK); } }

        public List<EngineMoveAnalysis> Moves { get; set; } = new List<EngineMoveAnalysis>(4);

        public int AvgCentipawnLossWhite
        {
            get
            {
                if (Moves.Any())
                    return (int)Math.Round(Moves.Where(f => f.Player == MoveType.WHITE).Sum(f => f.BestMoveDifference) / Moves.Count * 100, 0);
                else
                    return 0;
            }
        }

        public int AvgCentipawnLossBlack
        {
            get
            {
                if (Moves.Any())
                    return (int)Math.Round(Moves.Where(f => f.Player == MoveType.BLACK).Sum(f => f.BestMoveDifference) / Moves.Count * 100, 0);
                else
                    return 0;
            }
        }
    }
}
