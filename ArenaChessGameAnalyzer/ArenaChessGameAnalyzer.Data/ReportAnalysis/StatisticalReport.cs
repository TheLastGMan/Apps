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
    public class StatisticalReport
    {
        public StatisticalReport()
        {
        }

        public StatisticalReport(EngineAnalysisReport report)
        {
            Engine = report.Engine;
            Moves = report.Moves;

            White_Moves = report.Moves.Where(f => f.Player == MoveType.WHITE).ToList();
            Black_Moves = report.Moves.Where(f => f.Player == MoveType.BLACK).ToList();

            White_AvgCentipawnLoss = report.AvgCentipawnLossWhite;
            Black_AvgCentipawnLoss = report.AvgCentipawnLossBlack;

            White_MoveTypes = White_Moves.GroupBy(f => f.MoveClassification).Select(f => new KeyValue<EngineMoveType, int>(f.Key, f.Count())).ToList();
            Black_MoveTypes = Black_Moves.GroupBy(f => f.MoveClassification).Select(f => new KeyValue<EngineMoveType, int>(f.Key, f.Count())).ToList();
        }

        public string Engine { get; set; }

        public int White_AvgCentipawnLoss { get; set; }

        public int Black_AvgCentipawnLoss { get; set; }

        public List<EngineMoveAnalysis> Moves { get; set; } = new List<EngineMoveAnalysis>();

        public List<EngineMoveAnalysis> White_Moves { get; set; } = new List<EngineMoveAnalysis>();
        public List<KeyValue<EngineMoveType, int>> White_MoveTypes { get; set; } = new List<KeyValue<EngineMoveType, int>>();

        public List<EngineMoveAnalysis> Black_Moves { get; set; } = new List<EngineMoveAnalysis>();
        public List<KeyValue<EngineMoveType, int>> Black_MoveTypes { get; set; } = new List<KeyValue<EngineMoveType, int>>();
    }
}
