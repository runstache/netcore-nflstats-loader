using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NflStats.Data.DataObjects;

namespace NflStats.Data.Configuration
{
    public class RushingStatConfiguration : IEntityTypeConfiguration<RushingStat>
    {
        public void Configure(EntityTypeBuilder<RushingStat> builder)
        {
            builder.ToTable("tblRushingStats");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.AveragePerCarry).IsRequired().HasColumnName("AveragePerCarry").HasColumnType("float");
            builder.Property(c => c.Carries).IsRequired().HasColumnName("Carries").HasColumnType("int");
            builder.Property(c => c.Id).IsRequired().HasColumnName("Id").HasColumnType("bigint").UseIdentityColumn();
            builder.Property(c => c.LongestCarry).IsRequired().HasColumnName("LongestCarry").HasColumnType("int");
            builder.Property(c => c.OpponentId).IsRequired().HasColumnName("OpponentId").HasColumnType("int");
            builder.Property(c => c.PlayerId).IsRequired().HasColumnName("PlayerId").HasColumnType("bigint");
            builder.Property(c => c.ScheduleId).IsRequired().HasColumnName("ScheduleId").HasColumnType("bigint");
            builder.Property(c => c.TeamId).IsRequired().HasColumnName("TeamId").HasColumnType("int");
            builder.Property(c => c.Touchdowns).IsRequired().HasColumnName("Touchdowns").HasColumnType("int");
            builder.Property(c => c.Yards).IsRequired().HasColumnName("Yards").HasColumnType("int");
        }
    }
}
