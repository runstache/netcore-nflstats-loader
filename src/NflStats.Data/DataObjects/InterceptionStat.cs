using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NflStats.Data.DataObjects
{
    public class InterceptionStat : BasePlayerStat
    {
        public int Interceptions { get; set; }
        public int Yards { get; set; }
        public int Touchdowns { get; set; }
    }
}
