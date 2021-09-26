using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NflStats.Data.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NflStats.Data.Configuration
{
    public class ScoringStatConfiguration : BaseStatConfiguration, IEntityTypeConfiguration<ScoringStat>
    {
        public void Configure(EntityTypeBuilder<ScoringStat> builder)
        {
            BaseStatConfiguration.Configure(builder);
            builder.ToTable("tblScoringStats");
            builder.Property(c => c.Points).IsRequired().HasColumnName("Points").HasColumnType("int");
            builder.Property(c => c.Quarter).IsRequired().HasColumnName("Quarter").HasColumnType("int");
        }
    }
}
