using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NflStats.Data.DataObjects
{
    public class FumbleStat : BasePlayerStat
    {
        public int Fumbles { get; set; }
        public int FumblesLost { get; set; }
        public int FumblesRecovered { get; set; }

    }
}
