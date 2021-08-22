using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NflStats.Data.DataObjects;


namespace NflStats.Data.Configuration
{
    public class PassingStatConfiguration : IEntityTypeConfiguration<PassingStat>
    {
        public void Configure(EntityTypeBuilder<PassingStat> builder)
        {
            builder.ToTable("tblPassingStats");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Attempts).IsRequired().HasColumnName("Attempts").HasColumnType("int");
            builder.Property(c => c.AveragePerAttempt).IsRequired().HasColumnName("AveragePerAttempt").HasColumnType("float");
            builder.Property(c => c.Completions).IsRequired().HasColumnName("Completions").HasColumnType("int");
            builder.Property(c => c.Id).IsRequired().HasColumnName("Id").HasColumnType("bigint");
            builder.Property(c => c.Interceptions).IsRequired().HasColumnName("Interceptions").HasColumnType("int");
            builder.Property(c => c.OpponentId).IsRequired().HasColumnName("OpponentId").HasColumnType("int");
            builder.Property(c => c.PlayerId).IsRequired().HasColumnName("PlayerId").HasColumnType("bigint");
            builder.Property(c => c.Qbr).IsRequired().HasColumnName("Qbr").HasColumnType("float");
            builder.Property(c => c.Rating).IsRequired().HasColumnName("Rating").HasColumnType("float");
            builder.Property(c => c.Sacks).IsRequired().HasColumnName("Sacks").HasColumnType("int");
            builder.Property(c => c.ScheduleId).IsRequired().HasColumnName("ScheduleId").HasColumnType("bigint");
            builder.Property(c => c.TeamId).IsRequired().HasColumnName("TeamId").HasColumnType("int");
            builder.Property(c => c.Touchdowns).IsRequired().HasColumnName("Touchdowns").HasColumnType("int");
            builder.Property(c => c.Yards).IsRequired().HasColumnName("Yards").HasColumnType("int");                
        }
    }
}
