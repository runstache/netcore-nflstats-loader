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
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.ToTable("tblPlayers");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Dob).HasColumnName("Dob").HasColumnType("date");
            builder.Property(c => c.Url).IsRequired().HasColumnName("Url").HasColumnType("varchar(255)").HasMaxLength(255);
            builder.Property(c => c.Name).IsRequired().HasColumnName("Name").HasColumnType("varchar(500)").HasMaxLength(500);
            builder.Property(c => c.Id).IsRequired().HasColumnName("Id").HasColumnType("bigint").UseIdentityColumn();
            builder.Property(c => c.Position).IsRequired().HasColumnName("Position").HasColumnType("varchar(50)").HasMaxLength(50);
        }
    }
}
