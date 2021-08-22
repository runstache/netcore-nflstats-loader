using Newtonsoft.Json;
namespace NflStats.Loader.Models
{
    public class BoxscoreModel
    {
        public BoxscoreModel()
        {
            HomePassing = new PassingModel();
            AwayPassing = new PassingModel();
            HomeRushing = new RushingModel();
            AwayRushing = new RushingModel();
            HomeReceiving = new ReceivingModel();
            AwayReceiving = new ReceivingModel();
            HomeFumbles = new FumbleModel();
            AwayFumbles = new FumbleModel();
            HomeDefense = new DefenseModel();
            AwayDefense = new DefenseModel();
            HomeInterceptions = new InterceptionModel();
            AwayInterceptions = new InterceptionModel();
            HomeKickReturns = new ReturnModel();
            AwayKickReturns = new ReturnModel();
            HomePuntReturns = new ReturnModel();
            AwayPuntReturns = new ReturnModel();
            HomeKicking = new KickingModel();
            AwayKicking = new KickingModel();
            HomePunting = new PuntingModel();
            AwayPunting = new PuntingModel();
        }

        [JsonProperty(PropertyName = "homePassing")]
        public PassingModel HomePassing { get; set; }

        [JsonProperty(PropertyName = "awayPassing")]
        public PassingModel AwayPassing { get; set; }

        [JsonProperty(PropertyName = "homeRushing")]
        public RushingModel HomeRushing { get; set; }

        [JsonProperty(PropertyName = "awayRushing")]
        public RushingModel AwayRushing { get; set; }

        [JsonProperty(PropertyName = "homeReceiving")]
        public ReceivingModel HomeReceiving { get; set; }

        [JsonProperty(PropertyName = "awayReceiving")]
        public ReceivingModel AwayReceiving { get; set; }

        [JsonProperty(PropertyName = "homeFumbles")]
        public FumbleModel HomeFumbles { get; set; }

        [JsonProperty(PropertyName = "awayFumbles")]
        public FumbleModel AwayFumbles { get; set; }

        [JsonProperty(PropertyName = "homeDefense")]
        public DefenseModel HomeDefense { get; set; }

        [JsonProperty(PropertyName = "awayDefense")]
        public DefenseModel AwayDefense { get; set; }

        [JsonProperty(PropertyName = "homeInterceptions")]
        public InterceptionModel HomeInterceptions { get; set; }

        [JsonProperty(PropertyName = "awayInterceptions")]
        public InterceptionModel AwayInterceptions { get; set; }

        [JsonProperty(PropertyName = "homeKickReturns")]
        public ReturnModel HomeKickReturns { get; set; }

        [JsonProperty(PropertyName = "awayKickReturns")]
        public ReturnModel AwayKickReturns { get; set; }

        [JsonProperty(PropertyName = "homePuntReturns")]
        public ReturnModel HomePuntReturns { get; set; }

        [JsonProperty(PropertyName = "awayPuntReturns")]
        public ReturnModel AwayPuntReturns { get; set; }

        [JsonProperty(PropertyName = "homeKicking")]
        public KickingModel HomeKicking { get; set; }

        [JsonProperty(PropertyName = "awayKicking")]
        public KickingModel AwayKicking { get; set; }

        [JsonProperty(PropertyName = "homePunting")]
        public PuntingModel HomePunting { get; set; }

        [JsonProperty(PropertyName = "awayPunting")]
        public PuntingModel AwayPunting { get; set; }



    }
}
