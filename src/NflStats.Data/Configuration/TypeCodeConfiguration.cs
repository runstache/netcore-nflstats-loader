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
    public class TypeCodeConfiguration : IEntityTypeConfiguration<DataObjects.TypeCode>
    {
        public void Configure(EntityTypeBuilder<DataObjects.TypeCode> builder)
        {
            builder.ToTable("tblTypeCodes");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Code).IsRequired().HasColumnName("Code").HasColumnType("varchar(10)").HasMaxLength(10);
            builder.Property(c => c.Description).IsRequired().HasColumnName("Description").HasColumnType("varchar(50)").HasMaxLength(50);
            builder.Property(c => c.Id).IsRequired().HasColumnName("Id").HasColumnType("int").UseIdentityColumn();
        }
    }
}
