using Newtonsoft.Json;

namespace NflStats.Loader.Models
{
    public class PuntingModel : BasePlayerStatModel
    {

        public PuntingModel() : base()
        {

        }


        [JsonProperty(PropertyName = "punts")]
        public string Punts { get; set; }

        [JsonProperty(PropertyName = "yards")]
        public string Yards { get; set; }

        [JsonProperty(PropertyName = "averagePunt")]
        public string AveragePunt { get; set; }

        [JsonProperty(PropertyName = "insideTwenty")]
        public string InsideTwenty { get; set; }

        [JsonProperty(PropertyName = "longPunt")]
        public string LongPunt { get; set; }

        [JsonProperty(PropertyName = "touchbacks")]
        public string Touchbacks { get; set; }
    }
}
