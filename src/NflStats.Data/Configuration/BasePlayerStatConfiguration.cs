using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NflStats.Data.DataObjects;

namespace NflStats.Data.Configuration
{
    public class BasePlayerStatConfiguration : BaseStatConfiguration
    {
        public new void Configure<TEntity>(EntityTypeBuilder<TEntity> builder) where TEntity : BasePlayerStat
        {
            BaseStatConfiguration.Configure(builder);
            builder.Property(c => c.PlayerId).IsRequired().HasColumnName("PlayerId").HasColumnType("bigint");
        }
    }
}
