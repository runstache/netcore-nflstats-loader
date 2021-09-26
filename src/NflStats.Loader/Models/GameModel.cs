using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NflStats.Loader.Models
{
    public class GameModel
    {
        [JsonProperty(PropertyName = "year")]
        public string Year { get; set; }

        [JsonProperty(PropertyName = "weekNumber")]
        public string WeekNumber { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string SeasonType { get; set; }

        [JsonProperty(PropertyName = "awayTeam")]
        public string AwayTeam { get; set; }

        [JsonProperty(PropertyName = "homeTeam")]
        public string HomeTeam { get; set; }

        [JsonProperty(PropertyName = "gameId")]
        public string GameId { get; set; }

        [JsonProperty(PropertyName = "boxscore")]
        public BoxscoreModel Boxscore { get; set; }

        [JsonProperty(PropertyName = "matchup")]
        public MatchupModel Matchup { get; set; }

        [JsonProperty(PropertyName = "bigplays")]
        public List<BigPlayModel> BigPlays { get; set; }

        public GameModel()
        {
            BigPlays = new List<BigPlayModel>();
            Boxscore = new BoxscoreModel();
            Matchup = new MatchupModel();
        }


    }
}
