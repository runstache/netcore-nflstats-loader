using Newtonsoft.Json;

namespace NflStats.Loader.Models
{
    public class DefenseModel : BasePlayerStatModel
    {
        public DefenseModel() : base()
        {

        }

        [JsonProperty(PropertyName = "totalTackles")]
        public string TotalTackles { get; set; }

        [JsonProperty(PropertyName = "soloTackles")]
        public string SoloTackles { get; set; }

        [JsonProperty(PropertyName = "sacks")]
        public string Sacks { get; set; }

        [JsonProperty(PropertyName = "tacklesForLoss")]
        public string TacklesForLoss { get; set; }

        [JsonProperty(PropertyName = "qbHits")]
        public string QbHits { get; set; }

        [JsonProperty(PropertyName = "touchdowns")]
        public string Touchdowns { get; set; }

        [JsonProperty(PropertyName = "passesDefended")]
        public string PassesDefended { get; set; }
    }
}
