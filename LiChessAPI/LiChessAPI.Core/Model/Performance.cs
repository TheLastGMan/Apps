namespace LiChessAPI.Core.Model
{
    public class Performance
    {
        public GameStat bullet { get; set; } = new GameStat();
        public GameStat chess960 { get; set; } = new GameStat();
        public GameStat classical { get; set; } = new GameStat();
        public GameStat kingOfTheHill { get; set; } = new GameStat();
        public GameStat puzzle { get; set; } = new GameStat();
        public GameStat threeCheck { get; set; } = new GameStat();
    }
}
