using Newtonsoft.Json;
namespace NflStats.Loader.Models
{
    public class PassingModel : BasePlayerStatModel
    {
        public PassingModel() : base()
        {

        }

        [JsonProperty(PropertyName = "completions")]
        public string Completions { get; set; }
        
        [JsonProperty(PropertyName = "attempts")]
        public string Attempts { get; set; }

        [JsonProperty(PropertyName = "sacks")]
        public string Sacks { get; set; }
        
        [JsonProperty(PropertyName = "yards")]
        public string Yards { get; set; }

        [JsonProperty(PropertyName = "passingAverage")]
        public string PassingAverage { get; set; }

        [JsonProperty(PropertyName = "touchdowns")]
        public string Touchdowns { get; set; }

        [JsonProperty(PropertyName = "interceptions")]
        public string Interceptions { get; set; }

        [JsonProperty(PropertyName = "qbrating")]
        public string QbRating { get; set; }

        [JsonProperty(PropertyName = "rating")]
        public string Rating { get; set; }
        
    }
}
