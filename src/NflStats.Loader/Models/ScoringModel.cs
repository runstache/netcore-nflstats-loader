using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NflStats.Loader.Models
{
    public class ScoringModel
    {
        [JsonProperty(PropertyName = "team")]
        public string Team { get; set; }
        [JsonProperty(PropertyName = "final")]
        public string Final { get; set; }
        [JsonProperty(PropertyName = "quarters")]
        public List<ScoreValueModel> Quarters { get; set; }
    }
}
