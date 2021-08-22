using Newtonsoft.Json;
using System.Collections.Generic;

namespace NflStats.Loader.Models
{
    public class PlayerModel
    {
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "bio")]

        public Dictionary<string, string> Bio { get; set; }

        public PlayerModel()
        {
            Bio = new Dictionary<string, string>();
        }
    }
}
