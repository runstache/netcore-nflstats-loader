using Newtonsoft.Json;

namespace NflStats.Loader.Models
{
    public class InterceptionModel : BasePlayerStatModel
    {
        public InterceptionModel() : base()
        {

        }

        [JsonProperty(PropertyName = "interceptions")]
        public string Interceptions { get; set; }

        [JsonProperty(PropertyName = "yards")]
        public string Yards { get; set; }

        [JsonProperty(PropertyName = "touchdowns")]
        public string Touchdowns { get; set; }
    }
}
