using Microsoft.EntityFrameworkCore;
using NflStats.Data.Configuration;
using NflStats.Data.DataObjects;

namespace NflStats.Data.Contexts
{
    public class SqlContext : DbContext
    {

        private readonly string _connectionString;

        public SqlContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<DefensiveStat> DefensiveStats { get; set; }
        public DbSet<KickingStat> KickingStats { get; set; }
        public DbSet<PassingStat> PassingStats { get; set; }
        public DbSet<ReceivingStat> ReceivingStats { get; set; }
        public DbSet<RushingStat> RushingStats { get; set; }
        public DbSet<ScheduleItem> ScheduleItems { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamStat> TeamStats { get; set; }
        public DbSet<DataObjects.TypeCode> TypeCodes { get; set; }
        public DbSet<ReturnStat> ReturnStats { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<FumbleStat> Fumbles { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured && !string.IsNullOrEmpty(_connectionString))
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new DefensiveStatConfiguration());
            modelBuilder.ApplyConfiguration(new KickingStatConfiguration());
            modelBuilder.ApplyConfiguration(new PassingStatConfiguration());
            modelBuilder.ApplyConfiguration(new ReceivingStatConfiguration());
            modelBuilder.ApplyConfiguration(new RushingStatConfiguration());
            modelBuilder.ApplyConfiguration(new ScheduleItemConfiguration());
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new TeamStatConfiguration());
            modelBuilder.ApplyConfiguration(new TypeCodeConfiguration());
            modelBuilder.ApplyConfiguration(new ReturnStatConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerConfiguration());
            modelBuilder.ApplyConfiguration(new FumbleStatConfiguration());
        }

    }
}
