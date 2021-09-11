using Newtonsoft.Json;

namespace NflStats.Roster.Loader.Models
{
    public class RosterModel
    {
        [JsonProperty(PropertyName = "team")]
        public string Team { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "position")]
        public string Position { get; set; }

    }
}
