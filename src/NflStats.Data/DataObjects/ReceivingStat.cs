namespace NflStats.Data.DataObjects
{
    public class ReceivingStat : BasePlayerStat
    {
        public int Receptions { get; set; }
        public int Yards { get; set; }
        public double AveragePerReception { get; set; }
        public int Touchdowns { get; set; }
        public int LongestReception { get; set; }
        public int Targets { get; set; }       
    }
}
