using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NflStats.Data.DataObjects;

namespace NflStats.Data.Configuration
{
    public class ScheduleItemConfiguration : IEntityTypeConfiguration<ScheduleItem>
    {
        public void Configure(EntityTypeBuilder<ScheduleItem> builder)
        {
            builder.ToTable("tblSchedule");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.GameId).IsRequired().HasColumnName("GameId").HasColumnType("bigint");
            builder.Property(c => c.Id).IsRequired().HasColumnName("Id").HasColumnType("bigint").UseIdentityColumn();
            builder.Property(c => c.IsHome).IsRequired().HasColumnName("IsHome").HasColumnType("bit");
            builder.Property(c => c.OpponentId).IsRequired().HasColumnName("OpponentId").HasColumnType("int");
            builder.Property(c => c.TeamId).IsRequired().HasColumnName("TeamId").HasColumnType("int");
            builder.Property(c => c.TypeId).IsRequired().HasColumnName("TypeId").HasColumnType("int");
            builder.Property(c => c.WeekNumber).IsRequired().HasColumnName("WeekNumber").HasColumnType("int");
            builder.Property(c => c.YearValue).IsRequired().HasColumnName("YearValue").HasColumnType("int");           
        }
    }
}
