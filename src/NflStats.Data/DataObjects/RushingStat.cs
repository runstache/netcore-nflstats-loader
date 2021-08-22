namespace NflStats.Data.DataObjects
{
    public class RushingStat : BasePlayerStat
    {

        public int Carries { get; set; }
        public int Yards { get; set; }
        public double AveragePerCarry { get; set; }
        public int Touchdowns { get; set; }
        public int LongestCarry { get; set; }

    }
}
