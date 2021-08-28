using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace NflStats.Loader.Models
{
    public class ScoreValueModel
    {
        [JsonProperty(PropertyName = "quarter")]
        public int Quarter { get; set; }
        [JsonProperty(PropertyName = "points")]
        public string Points { get; set; }
    }
}
