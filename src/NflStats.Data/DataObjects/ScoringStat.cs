using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NflStats.Data.DataObjects
{
    public class ScoringStat : BaseStat
    {
        public int Quarter { get; set; }
        public int Points { get; set; }
    }
}
