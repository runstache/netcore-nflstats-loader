namespace NflStats.Data.DataObjects
{
    public class TeamStat : BaseStat
    {
        public int PassingFirstDowns { get; set; }
        public int RushingFirstDowns { get; set; }
        public int PenaltyFirstDowns { get; set; }
        public int ThirdDowns { get; set; }
        public int ThirdDownsConverted { get; set; }
        public int FourthDownAttempt { get; set; }
        public int FourthDownConverted { get; set; }
        public int TotalPlays { get; set; }
        public int TotalYards { get; set; }
        public int TotalDrives { get; set; }
        public double YardsPerPlay { get; set; }
        public int PassingAttempts { get; set; }
        public int PassingCompletions { get; set; }
        public double YardsPerPass { get; set; }
        public int PassingYards { get; set; }
        public int PassOverFifteen { get; set; }
        public int Interceptions { get; set; }
        public int RushingAttempts { get; set; }
        public double YardsPerRush { get; set; }
        public int RushingYards { get; set; }
        public int RushOverTen { get; set; }
        public int RedzoneAttempts { get; set; }
        public int RedzoneConverted { get; set; }
        public int FumblesLost { get; set; }
        public int TotalTurnovers { get; set; }
        public int DefensiveTouchdowns { get; set; }
        public long TimeOfPossession { get; set; }
        public int PointsScored { get; set; }
        public int PointsAllowed { get; set; }
        public int Penalties { get; set; }
        public int PenaltyYards { get; set; }
        public int Sacks { get; set; }
        public int SackYardsLost { get; set; }

    }
}
