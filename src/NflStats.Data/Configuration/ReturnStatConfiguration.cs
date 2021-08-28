using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NflStats.Data.DataObjects;

namespace NflStats.Data.Configuration
{
    public class ReturnStatConfiguration : BasePlayerStatConfiguration, IEntityTypeConfiguration<ReturnStat>
    {
        public void Configure(EntityTypeBuilder<ReturnStat> builder)
        {
            builder.ToTable("tblReturnStats");
            builder.Property(c => c.AverageReturn).IsRequired().HasColumnName("AverageReturn").HasColumnType("float");
            builder.Property(c => c.KickReturns).IsRequired().HasColumnName("KickReturns").HasColumnType("int");
            builder.Property(c => c.LongReturn).IsRequired().HasColumnName("LongReturn").HasColumnType("int");
            builder.Property(c => c.Touchdowns).IsRequired().HasColumnName("Touchdowns").HasColumnType("int");
            builder.Property(c => c.Yards).IsRequired().HasColumnName("Yards").HasColumnType("int");                
        }
    }
}
