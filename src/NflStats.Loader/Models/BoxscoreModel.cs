using System.Collections.Generic;
using Newtonsoft.Json;
namespace NflStats.Loader.Models
{
    public class BoxscoreModel
    {
        public BoxscoreModel()
        {
            HomePassing = new();
            AwayPassing = new();
            HomeRushing = new(); 
            AwayRushing = new();
            HomeReceiving = new();
            AwayReceiving = new();
            HomeFumbles = new();
            AwayFumbles = new();
            HomeDefense = new();
            AwayDefense = new();
            HomeInterceptions = new();
            AwayInterceptions = new();
            HomeKickReturns = new();
            AwayKickReturns = new();
            HomePuntReturns = new();
            AwayPuntReturns = new();
            HomeKicking = new();
            AwayKicking = new();
            HomePunting = new();
            AwayPunting = new();
        }

        [JsonProperty(PropertyName = "homePassing")]
        public List<PassingModel> HomePassing { get; set; }

        [JsonProperty(PropertyName = "awayPassing")]
        public List<PassingModel> AwayPassing { get; set; }

        [JsonProperty(PropertyName = "homeRushing")]
        public List<RushingModel> HomeRushing { get; set; }

        [JsonProperty(PropertyName = "awayRushing")]
        public List<RushingModel> AwayRushing { get; set; }

        [JsonProperty(PropertyName = "homeReceiving")]
        public List<ReceivingModel> HomeReceiving { get; set; }

        [JsonProperty(PropertyName = "awayReceiving")]
        public List<ReceivingModel> AwayReceiving { get; set; }

        [JsonProperty(PropertyName = "homeFumbles")]
        public List<FumbleModel> HomeFumbles { get; set; }

        [JsonProperty(PropertyName = "awayFumbles")]
        public List<FumbleModel> AwayFumbles { get; set; }

        [JsonProperty(PropertyName = "homeDefense")]
        public List<DefenseModel> HomeDefense { get; set; }

        [JsonProperty(PropertyName = "awayDefense")]
        public List<DefenseModel> AwayDefense { get; set; }

        [JsonProperty(PropertyName = "homeInterceptions")]
        public List<InterceptionModel> HomeInterceptions { get; set; }

        [JsonProperty(PropertyName = "awayInterceptions")]
        public List<InterceptionModel> AwayInterceptions { get; set; }

        [JsonProperty(PropertyName = "homeKickReturns")]
        public List<ReturnModel> HomeKickReturns { get; set; }

        [JsonProperty(PropertyName = "awayKickReturns")]
        public List<ReturnModel> AwayKickReturns { get; set; }

        [JsonProperty(PropertyName = "homePuntReturns")]
        public List<ReturnModel> HomePuntReturns { get; set; }

        [JsonProperty(PropertyName = "awayPuntReturns")]
        public List<ReturnModel> AwayPuntReturns { get; set; }

        [JsonProperty(PropertyName = "homeKicking")]
        public List<KickingModel> HomeKicking { get; set; }

        [JsonProperty(PropertyName = "awayKicking")]
        public List<KickingModel> AwayKicking { get; set; }

        [JsonProperty(PropertyName = "homePunting")]
        public List<PuntingModel> HomePunting { get; set; }

        [JsonProperty(PropertyName = "awayPunting")]
        public List<PuntingModel> AwayPunting { get; set; }



    }
}
