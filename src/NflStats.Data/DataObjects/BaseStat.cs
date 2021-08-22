namespace NflStats.Data.DataObjects
{
    public class BaseStat
    {
        public long Id { get; set; }
        public int TeamId { get; set; }
        public int OpponentId { get; set; }
        public long ScheduleId { get; set; }
    }
}
