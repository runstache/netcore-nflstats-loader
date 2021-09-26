using Newtonsoft.Json;
namespace NflStats.Loader.Models
{
    public class RushingModel : BasePlayerStatModel
    {
        public RushingModel() : base()
        {

        }

        
        [JsonProperty(PropertyName = "yards")]
        public string Yards { get; set; }

        [JsonProperty(PropertyName = "rushingAverage")]
        public string RushingAverage { get; set; }

        [JsonProperty(PropertyName = "touchdowns")]
        public string Touchdowns { get; set; }

        [JsonProperty(PropertyName = "carries")]
        public string Carries { get; set; }

        [JsonProperty(PropertyName = "longrush")]
        public string LongRush { get; set; }

    }
}
