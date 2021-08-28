using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NflStats.Data.DataObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NflStats.Data.Configuration
{
    public class FumbleStatConfiguration : IEntityTypeConfiguration<FumbleStat>
    {
        public void Configure(EntityTypeBuilder<FumbleStat> builder)
        {
            builder.ToTable("tblFumbleStats");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Fumbles).IsRequired().HasColumnName("Fumbles").HasColumnType("int");
            builder.Property(c => c.FumblesLost).IsRequired().HasColumnName("FumblesLost").HasColumnType("int");
            builder.Property(c => c.FumblesRecovered).IsRequired().HasColumnName("FumblesRecovered").HasColumnType("int");
            builder.Property(c => c.Id).IsRequired().HasColumnName("Id").HasColumnType("bigint").UseIdentityColumn();
            builder.Property(c => c.OpponentId).IsRequired().HasColumnName("OpponentId").HasColumnType("int");
            builder.Property(c => c.PlayerId).IsRequired().HasColumnName("PlayerId").HasColumnType("bigint");
            builder.Property(c => c.ScheduleId).IsRequired().HasColumnName("ScheduleId").HasColumnType("bigint");
            builder.Property(c => c.TeamId).IsRequired().HasColumnName("TeamId").HasColumnType("int");

        }
    }
}
