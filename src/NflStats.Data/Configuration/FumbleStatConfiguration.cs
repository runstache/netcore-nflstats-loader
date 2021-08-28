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
    public class FumbleStatConfiguration : BasePlayerStatConfiguration, IEntityTypeConfiguration<FumbleStat>
    {
        public void Configure(EntityTypeBuilder<FumbleStat> builder)
        {
            base.Configure(builder);
            builder.ToTable("tblFumbleStats");            
            builder.Property(c => c.Fumbles).IsRequired().HasColumnName("Fumbles").HasColumnType("int");
            builder.Property(c => c.FumblesLost).IsRequired().HasColumnName("FumblesLost").HasColumnType("int");
            builder.Property(c => c.FumblesRecovered).IsRequired().HasColumnName("FumblesRecovered").HasColumnType("int");


        }
    }
}
