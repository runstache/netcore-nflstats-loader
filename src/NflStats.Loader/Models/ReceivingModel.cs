using Newtonsoft.Json;
namespace NflStats.Loader.Models
{
    public class ReceivingModel : BasePlayerStatModel
    {
        public ReceivingModel() : base()
        {

        }

        [JsonProperty(PropertyName = "yards")]
        public string Yards { get; set; }

        [JsonProperty(PropertyName = "receivingAverage")]
        public string ReceivingAverage { get; set; }

        [JsonProperty(PropertyName = "touchdowns")]
        public string Touchdowns { get; set; }

        [JsonProperty(PropertyName = "receptions")]
        public string Receptions { get; set; }

        [JsonProperty(PropertyName = "longcatch")]
        public string LongCatch { get; set; }

        [JsonProperty(PropertyName = "targets")]
        public string Targets { get; set; }
    }
}
