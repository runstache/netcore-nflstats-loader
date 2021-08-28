using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NflStats.Data.DataObjects;


namespace NflStats.Data.Configuration
{
    public class PassingStatConfiguration : BasePlayerStatConfiguration, IEntityTypeConfiguration<PassingStat>
    {
        public void Configure(EntityTypeBuilder<PassingStat> builder)
        {
            builder.ToTable("tblPassingStats");
            builder.Property(c => c.Attempts).IsRequired().HasColumnName("Attempts").HasColumnType("int");
            builder.Property(c => c.AveragePerAttempt).IsRequired().HasColumnName("AveragePerAttempt").HasColumnType("float");
            builder.Property(c => c.Completions).IsRequired().HasColumnName("Completions").HasColumnType("int");
            builder.Property(c => c.Interceptions).IsRequired().HasColumnName("Interceptions").HasColumnType("int");
            builder.Property(c => c.Qbr).IsRequired().HasColumnName("Qbr").HasColumnType("float");
            builder.Property(c => c.Rating).IsRequired().HasColumnName("Rating").HasColumnType("float");
            builder.Property(c => c.Sacks).IsRequired().HasColumnName("Sacks").HasColumnType("int");
            builder.Property(c => c.Touchdowns).IsRequired().HasColumnName("Touchdowns").HasColumnType("int");
            builder.Property(c => c.Yards).IsRequired().HasColumnName("Yards").HasColumnType("int");                
        }
    }
}
