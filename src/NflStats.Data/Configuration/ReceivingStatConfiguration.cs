using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NflStats.Data.DataObjects;

namespace NflStats.Data.Configuration
{
    public class ReceivingStatConfiguration : BasePlayerStatConfiguration, IEntityTypeConfiguration<ReceivingStat>
    {
        public void Configure(EntityTypeBuilder<ReceivingStat> builder)
        {
            builder.ToTable("tblReceivingStats");
            builder.Property(c => c.AveragePerReception).IsRequired().HasColumnName("AveragePerReception").HasColumnType("float");
            builder.Property(c => c.LongestReception).IsRequired().HasColumnName("LongestReception").HasColumnType("int");
            builder.Property(c => c.Receptions).IsRequired().HasColumnName("Receptions").HasColumnType("int");
            builder.Property(c => c.Targets).IsRequired().HasColumnName("Targets").HasColumnType("int");
            builder.Property(c => c.Touchdowns).IsRequired().HasColumnName("Touchdowns").HasColumnType("int");
            builder.Property(c => c.Yards).IsRequired().HasColumnName("Yards").HasColumnType("int");

        }
    }
}
