using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NflStats.Data.DataObjects;

namespace NflStats.Data.Configuration
{
    public class DefensiveStatConfiguration : BasePlayerStatConfiguration, IEntityTypeConfiguration<DefensiveStat>
    {
        public void Configure(EntityTypeBuilder<DefensiveStat> builder)
        {
            base.Configure(builder);
            builder.ToTable("tblDefensiveStats");
            builder.Property(c => c.Interceptions).IsRequired().HasColumnName("Interceptions").HasColumnType("int");
            builder.Property(c => c.PassesDefended).IsRequired().HasColumnName("PassessDefended").HasColumnType("int");
            builder.Property(c => c.QbHits).IsRequired().HasColumnName("QbHits").HasColumnType("int");
            builder.Property(c => c.Sacks).IsRequired().HasColumnName("Sacks").HasColumnType("int");
            builder.Property(c => c.SoloTackles).IsRequired().HasColumnName("SoloTackles").HasColumnType("float");
            builder.Property(c => c.TacklesForLoss).IsRequired().HasColumnName("TacklesForLoss").HasColumnType("float");
            builder.Property(c => c.TotalTackles).IsRequired().HasColumnName("TotalTackles").HasColumnType("float");
            builder.Property(c => c.Touchdowns).IsRequired().HasColumnName("Touchdowns").HasColumnType("int");                
        }
    }
}
