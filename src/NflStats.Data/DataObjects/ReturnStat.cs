namespace NflStats.Data.DataObjects
{
    public class ReturnStat : BasePlayerStat
    {
        public int KickReturns { get; set; }
        public int Yards { get; set; }
        public double AverageReturn { get; set; }
        public int LongReturn { get; set; }
        public int Touchdowns { get; set; }
    }
}
