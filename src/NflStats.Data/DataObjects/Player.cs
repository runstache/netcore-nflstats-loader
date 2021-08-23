using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NflStats.Data.DataObjects
{
    public class Player
    {
        public long Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public string Position { get; set; }
    }
}
