namespace NflStats.Data.DataObjects
{
    public class PassingStat : BasePlayerStat
    {
        public int Completions { get; set; }
        public int Attempts { get; set; }
        public int Yards { get; set; }
        public double AveragePerAttempt { get; set; }
        public int Touchdowns { get; set; }
        public int Interceptions { get; set; }
        public int Sacks { get; set; }
        public double Qbr { get; set; }
        public double Rating { get; set; }

    }
}
