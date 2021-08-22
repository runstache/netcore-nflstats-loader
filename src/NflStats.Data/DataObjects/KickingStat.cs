namespace NflStats.Data.DataObjects
{
    public class KickingStat : BasePlayerStat
    {
        public int FieldGoals { get; set; }
        public int Attempts { get; set; }
        public int LongFieldGoal { get; set; }
        public int ExtraPoints { get; set; }
        public int ExtraPointAttempts { get; set; }
        public int Punts { get; set; }
        public int PuntTotalYards { get; set; }
        public double AveragePunt { get; set; }
        public int Touchbacks { get; set; }
        public int PuntInsideTwenty { get; set; }
        public int PuntLongest { get; set; }
    }
}
