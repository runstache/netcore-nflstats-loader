using Newtonsoft.Json;
namespace NflStats.Loader.Models
{
    public class MatchupStatModel
    {
        [JsonProperty(PropertyName = "home")]
        public string Home { get; set; }

        [JsonProperty(PropertyName = "away")]
        public string Away { get; set; }
    }
}
