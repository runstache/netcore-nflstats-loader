using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NflStats.Data.DataObjects;

namespace NflStats.Data.Configuration
{
    public class ReturnStatConfiguration : IEntityTypeConfiguration<ReturnStat>
    {
        public void Configure(EntityTypeBuilder<ReturnStat> builder)
        {
            builder.ToTable("tblReturnStats");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.AverageReturn).IsRequired().HasColumnName("AverageReturn").HasColumnType("float");
            builder.Property(c => c.Id).IsRequired().HasColumnName("Id").HasColumnType("bigint").UseIdentityColumn();
            builder.Property(c => c.KickReturns).IsRequired().HasColumnName("KickReturns").HasColumnType("int");
            builder.Property(c => c.LongReturn).IsRequired().HasColumnName("LongReturn").HasColumnType("int");
            builder.Property(c => c.OpponentId).IsRequired().HasColumnName("OpponentId").HasColumnType("int");
            builder.Property(c => c.PlayerId).IsRequired().HasColumnName("PlayerId").HasColumnType("bigint");
            builder.Property(c => c.ScheduleId).IsRequired().HasColumnName("ScheduleId").HasColumnType("bigint");
            builder.Property(c => c.TeamId).IsRequired().HasColumnName("TeamId").HasColumnType("int");
            builder.Property(c => c.Touchdowns).IsRequired().HasColumnName("Touchdowns").HasColumnType("int");
            builder.Property(c => c.Yards).IsRequired().HasColumnName("Yards").HasColumnType("int");                
        }
    }
}
