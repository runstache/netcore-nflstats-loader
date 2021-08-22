using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NflStats.Data.DataObjects;

namespace NflStats.Data.Configuration
{
    public class DefensiveStatConfiguration : IEntityTypeConfiguration<DefensiveStat>
    {
        public void Configure(EntityTypeBuilder<DefensiveStat> builder)
        {
            builder.ToTable("tblDefensiveStats");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).IsRequired().HasColumnName("Id").HasColumnType("bigint").UseIdentityColumn();
            builder.Property(c => c.Interceptions).IsRequired().HasColumnName("Interceptions").HasColumnType("int");
            builder.Property(c => c.OpponentId).IsRequired().HasColumnName("OpponentId").HasColumnType("int");
            builder.Property(c => c.PassesDefended).IsRequired().HasColumnName("PassessDefended").HasColumnType("int");
            builder.Property(c => c.PlayerId).IsRequired().HasColumnName("PlayerId").HasColumnType("bigint");
            builder.Property(c => c.QbHits).IsRequired().HasColumnName("QbHits").HasColumnType("int");
            builder.Property(c => c.Sacks).IsRequired().HasColumnName("Sacks").HasColumnType("int");
            builder.Property(c => c.ScheduleId).IsRequired().HasColumnName("ScheduleId").HasColumnType("bigint");
            builder.Property(c => c.SoloTackles).IsRequired().HasColumnName("SoloTackles").HasColumnType("float");
            builder.Property(c => c.TacklesForLoss).IsRequired().HasColumnName("TacklesForLoss").HasColumnType("float");
            builder.Property(c => c.TeamId).IsRequired().HasColumnName("TeamId").HasColumnType("int");
            builder.Property(c => c.TotalTackles).IsRequired().HasColumnName("TotalTackles").HasColumnType("float");
            builder.Property(c => c.Touchdowns).IsRequired().HasColumnName("Touchdowns").HasColumnType("int");                
        }
    }
}
