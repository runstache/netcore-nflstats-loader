using Newtonsoft.Json;

namespace NflStats.Loader.Models
{
    public class FumbleModel : BasePlayerStatModel
    {
        public FumbleModel() : base()
        {

        }

        [JsonProperty(PropertyName = "fumbles")]
        public string Fumbles { get; set; }

        [JsonProperty(PropertyName = "fumblesLost")]
        public string FumblesLost { get; set; }

        [JsonProperty(PropertyName = "fumblesRecovered")]
        public string FumblesRecovered { get; set; }
    }
}
