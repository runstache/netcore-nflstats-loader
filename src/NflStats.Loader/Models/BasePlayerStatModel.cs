using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NflStats.Loader.Models
{
    public class BasePlayerStatModel
    {
        protected BasePlayerStatModel()
        {
            Player = new PlayerModel();
        }

        [JsonProperty(PropertyName = "Player")]
        public PlayerModel Player { get; set; }

    }
}
