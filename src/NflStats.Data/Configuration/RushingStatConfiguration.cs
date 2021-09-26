using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NflStats.Data.DataObjects;

namespace NflStats.Data.Configuration
{
    public class RushingStatConfiguration : BasePlayerStatConfiguration, IEntityTypeConfiguration<RushingStat>
    {
        public void Configure(EntityTypeBuilder<RushingStat> builder)
        {
            builder.ToTable("tblRushingStats");
            builder.Property(c => c.AveragePerCarry).IsRequired().HasColumnName("AveragePerCarry").HasColumnType("float");
            builder.Property(c => c.Carries).IsRequired().HasColumnName("Carries").HasColumnType("int");
            builder.Property(c => c.LongestCarry).IsRequired().HasColumnName("LongestCarry").HasColumnType("int");
            builder.Property(c => c.Touchdowns).IsRequired().HasColumnName("Touchdowns").HasColumnType("int");
            builder.Property(c => c.Yards).IsRequired().HasColumnName("Yards").HasColumnType("int");
        }
    }
}
