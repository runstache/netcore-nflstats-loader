using Newtonsoft.Json;

namespace NflStats.Loader.Models
{
    public class ReturnModel : BasePlayerStatModel
    {
        public ReturnModel () : base()
        {

        }

        [JsonProperty(PropertyName = "kickReturns")]
        public string KickReturns { get; set; }

        [JsonProperty(PropertyName = "yards")]
        public string Yards { get; set; }

        [JsonProperty(PropertyName = "averageReturns")]
        public string AverageReturns { get; set; }

        [JsonProperty(PropertyName = "longReturn")]
        public string LongReturn { get; set; }

        [JsonProperty(PropertyName = "touchdowns")]
        public string Touchdowns { get; set; }
    }
}
