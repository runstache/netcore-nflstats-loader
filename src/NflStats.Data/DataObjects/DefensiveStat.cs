namespace NflStats.Data.DataObjects
{
    public class DefensiveStat : BasePlayerStat
    {
        public double TotalTackles { get; set; }
        public double SoloTackles { get; set; }
        public double Sacks { get; set; }
        public double TacklesForLoss { get; set; }
        public int PassesDefended { get; set; }
        public int QbHits { get; set; }
        public int Touchdowns { get; set; }
    }
}
