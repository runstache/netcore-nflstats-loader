using Newtonsoft.Json;

namespace NflStats.Loader.Models
{
    public class KickingModel : BasePlayerStatModel
    {
        public KickingModel() : base()
        {

        }

        [JsonProperty(PropertyName = "fieldGoalMade")]
        public string FieldGoalMade { get; set; }

        [JsonProperty(PropertyName = "fieldGoalAttempts")]
        public string FieldGoalAttempts { get; set; }

        [JsonProperty(PropertyName = "xpMade")]
        public string XpMade { get; set; }

        [JsonProperty(PropertyName = "xpAttempted")]
        public string XpAttempted { get; set; }

        [JsonProperty(PropertyName = "longFieldGoal")]
        public string LongFieldGoal { get; set; }

        [JsonProperty(PropertyName = "points")]
        public string Points { get; set; }

    }
}
