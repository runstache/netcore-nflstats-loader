using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NflStats.Data.DataObjects;

namespace NflStats.Data.Configuration
{
    public class KickingStatConfiguration : BasePlayerStatConfiguration, IEntityTypeConfiguration<KickingStat>
    {
        public void Configure(EntityTypeBuilder<KickingStat> builder)
        {
            BasePlayerStatConfiguration.Configure(builder);
            builder.ToTable("tblKickingStats");
            builder.Property(c => c.Attempts).IsRequired().HasColumnName("Attempts").HasColumnType("int");
            builder.Property(c => c.AveragePunt).IsRequired().HasColumnName("AveragePunt").HasColumnType("float");
            builder.Property(c => c.ExtraPointAttempts).IsRequired().HasColumnName("ExtraPointAttempts").HasColumnType("int");
            builder.Property(c => c.ExtraPoints).IsRequired().HasColumnName("ExtraPoints").HasColumnType("int");
            builder.Property(c => c.FieldGoals).IsRequired().HasColumnName("FieldGoals").HasColumnType("int");
            builder.Property(c => c.LongFieldGoal).IsRequired().HasColumnName("LongFieldGoal").HasColumnType("int");
            builder.Property(c => c.PuntInsideTwenty).IsRequired().HasColumnName("PuntInsideTwenty").HasColumnType("int");
            builder.Property(c => c.PuntLongest).IsRequired().HasColumnName("PuntLongest").HasColumnType("int");
            builder.Property(c => c.Punts).IsRequired().HasColumnName("Punts").HasColumnType("int");
            builder.Property(c => c.PuntTotalYards).IsRequired().HasColumnName("PuntTotalYards").HasColumnType("int");
            builder.Property(c => c.Touchbacks).IsRequired().HasColumnName("Touchbacks").HasColumnType("int");
            builder.Property(c => c.Points).IsRequired().HasColumnName("Points").HasColumnType("int");
        }
    }
}
