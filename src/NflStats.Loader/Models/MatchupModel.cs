using Newtonsoft.Json;
using System.Collections.Generic;

namespace NflStats.Loader.Models
{
    public class MatchupModel
    {
        public MatchupModel()
        {
            FirstDowns = new();
            PassingFirstDowns = new();
            RushingFirstDowns = new();
            PenaltyFirstDowns = new();
            ThirdDownEfficiency = new();
            FourthDownEfficiency = new();
            DefensivePlays = new();
            TotalYards = new();
            TotalDrives = new();
            YardsPerPlay = new();
            TotalPassingYards = new();
            PassingEfficiency = new();
            YardsPerPass = new();
            InterceptionsThrown = new();
            Sacks = new();
            RushingYards = new();
            RushingAttempts = new();
            YardsPerRush = new();
            RedZoneEfficiency = new();
            Penalties = new();
            Turnovers = new();
            Fumbles = new();
            Interceptions = new();
            DefensiveTouchdowns = new();
            PossessionTime = new();
            Boxscore = new();
        }

        [JsonProperty(PropertyName = "firstDowns")]
        public MatchupStatModel FirstDowns { get; set; }

        [JsonProperty(PropertyName = "passingFirstDowns")]
        public MatchupStatModel PassingFirstDowns { get; set; }

        [JsonProperty(PropertyName = "rushingFirstDowns")]
        public MatchupStatModel RushingFirstDowns { get; set; }

        [JsonProperty(PropertyName = "penaltyFirstDowns")]
        public MatchupStatModel PenaltyFirstDowns { get; set; }

        [JsonProperty(PropertyName = "thirdDownEfficieny")]
        public MatchupStatModel ThirdDownEfficiency { get; set; }

        [JsonProperty(PropertyName = "fourthDownEfficiency")]
        public MatchupStatModel FourthDownEfficiency { get; set; }

        [JsonProperty(PropertyName = "defensivePlays")]
        public MatchupStatModel DefensivePlays { get; set; }

        [JsonProperty(PropertyName = "totalYards")]
        public MatchupStatModel TotalYards { get; set; }

        [JsonProperty(PropertyName = "totalDrives")]
        public MatchupStatModel TotalDrives { get; set; }

        [JsonProperty(PropertyName = "yardsPerPlay")]
        public MatchupStatModel YardsPerPlay { get; set; }

        [JsonProperty(PropertyName = "totalPassingYards")]
        public MatchupStatModel TotalPassingYards { get; set; }

        [JsonProperty(PropertyName = "passingEfficiency")]
        public MatchupStatModel PassingEfficiency { get; set; }

        [JsonProperty(PropertyName = "yardsPerPass")]
        public MatchupStatModel YardsPerPass { get; set; }

        [JsonProperty(PropertyName = "interceptionsThrown")]
        public MatchupStatModel InterceptionsThrown { get; set; }

        [JsonProperty(PropertyName = "sacks")]
        public MatchupStatModel Sacks { get; set; }

        [JsonProperty(PropertyName = "rushingYards")]
        public MatchupStatModel RushingYards { get; set; }

        [JsonProperty(PropertyName = "rushingAttempts")]
        public MatchupStatModel RushingAttempts { get; set; }

        [JsonProperty(PropertyName = "yardsPerRush")]
        public MatchupStatModel YardsPerRush { get; set; }

        [JsonProperty(PropertyName = "redZoneEfficiency")]
        public MatchupStatModel RedZoneEfficiency { get; set; }

        [JsonProperty(PropertyName = "penalties")]
        public MatchupStatModel Penalties { get; set; }

        [JsonProperty(PropertyName = "turnovers")]
        public MatchupStatModel Turnovers { get; set; }

        [JsonProperty(PropertyName = "fumbles")]
        public MatchupStatModel Fumbles { get; set; }

        [JsonProperty(PropertyName = "interceptions")]
        public MatchupStatModel Interceptions { get; set; }

        [JsonProperty(PropertyName = "defensiveTouchdowns")]
        public MatchupStatModel DefensiveTouchdowns { get; set; }

        [JsonProperty(PropertyName = "possesionTime")]
        public MatchupStatModel PossessionTime { get; set; }

        [JsonProperty(PropertyName = "boxscore")]
        public List<ScoringModel> Boxscore { get; set; }

 
    }
}
