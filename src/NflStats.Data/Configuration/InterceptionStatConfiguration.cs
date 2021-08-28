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
    public class InterceptionStatConfiguration : BasePlayerStatConfiguration, IEntityTypeConfiguration<InterceptionStat>
    {
        public void Configure(EntityTypeBuilder<InterceptionStat> builder)
        {
            base.Configure(builder);
            builder.ToTable("tblInterceptionStats");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Interceptions).IsRequired().HasColumnName("Interceptions").HasColumnType("int");
            builder.Property(c => c.Touchdowns).IsRequired().HasColumnName("Touchdowns").HasColumnType("int");
            builder.Property(c => c.Yards).IsRequired().HasColumnName("Yards").HasColumnType("int");
        }
    }
}
