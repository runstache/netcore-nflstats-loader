using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NflStats.Data.DataObjects;

namespace NflStats.Data.Configuration
{
    public class ReceivingStatConfiguration : IEntityTypeConfiguration<ReceivingStat>
    {
        public void Configure(EntityTypeBuilder<ReceivingStat> builder)
        {
            builder.ToTable("tblReceivingStats");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.AveragePerReception).IsRequired().HasColumnName("AveragePerReception").HasColumnType("float");
            builder.Property(c => c.Id).IsRequired().HasColumnName("Id").HasColumnType("bigint").UseIdentityColumn();
            builder.Property(c => c.LongestReception).IsRequired().HasColumnName("LongestReception").HasColumnType("int");
            builder.Property(c => c.OpponentId).IsRequired().HasColumnName("OpponentId").HasColumnType("int");
            builder.Property(c => c.PlayerId).IsRequired().HasColumnName("PlayerId").HasColumnType("bigint");
            builder.Property(c => c.Receptions).IsRequired().HasColumnName("Receptions").HasColumnType("int");
            builder.Property(c => c.ScheduleId).IsRequired().HasColumnName("ScheduleId").HasColumnType("bigint");
            builder.Property(c => c.Targets).IsRequired().HasColumnName("Targets").HasColumnType("int");
            builder.Property(c => c.TeamId).IsRequired().HasColumnName("TeamId").HasColumnType("int");
            builder.Property(c => c.Touchdowns).IsRequired().HasColumnName("Touchdowns").HasColumnType("int");
            builder.Property(c => c.Yards).IsRequired().HasColumnName("Yards").HasColumnType("int");

        }
    }
}
