using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NflStats.Loader.Models
{
    public class BigPlayModel
    {
        [JsonProperty(PropertyName = "team")]
        public string Team { get; set; }

        [JsonProperty(PropertyName = "pass")]
        public int Pass { get; set; }

        [JsonProperty(PropertyName = "run")]
        public int Run { get; set; }

        [JsonProperty(PropertyName = "turnover")]
        public int Turnover { get; set; }
    }
}
