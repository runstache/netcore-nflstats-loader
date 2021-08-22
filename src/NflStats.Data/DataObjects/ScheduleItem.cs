using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NflStats.Data.DataObjects
{
    public class ScheduleItem
    {
        public long Id { get; set; }
        public int TeamId { get; set; }
        public int OpponentId { get; set; }
        public int YearValue { get; set; }
        public int WeekNumber { get; set; }
        public long GameId { get; set; }
        public int TypeId { get; set; }
        public bool IsHome { get; set; }
    }
}
