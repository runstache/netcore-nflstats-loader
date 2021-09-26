using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NflStats.Data.DataObjects;

namespace NflStats.Data.Configuration
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.ToTable("tblTeams");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Code).IsRequired().HasColumnName("Code").HasColumnType("varchar(3)").HasMaxLength(3);
            builder.Property(c => c.Id).IsRequired().HasColumnName("Id").HasColumnType("int");
            builder.Property(c => c.Name).IsRequired().HasColumnName("Name").HasColumnType("varchar(100)");
        }
    }
}
