using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NflStats.Data.DataObjects;

namespace NflStats.Data.Configuration
{
    public class TeamStatConfiguration : IEntityTypeConfiguration<TeamStat>
    {
        public void Configure(EntityTypeBuilder<TeamStat> builder)
        {
            builder.ToTable("tblTeamStats");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.DefensiveTouchdowns).IsRequired().HasColumnName("DefensiveTouchdowns").HasColumnType("int");
            builder.Property(c => c.FourthDownAttempt).IsRequired().HasColumnName("FourthDownAttempt").HasColumnType("int");
            builder.Property(c => c.FourthDownConverted).IsRequired().HasColumnName("FourthDownConverted").HasColumnType("int");
            builder.Property(c => c.FumblesLost).IsRequired().HasColumnName("FumblesLost").HasColumnType("int");
            builder.Property(c => c.Id).IsRequired().HasColumnName("Id").HasColumnType("bigint").UseIdentityColumn();
            builder.Property(c => c.Interceptions).IsRequired().HasColumnName("Interceptions").HasColumnType("int");
            builder.Property(c => c.OpponentId).IsRequired().HasColumnName("OpponentId").HasColumnType("int");
            builder.Property(c => c.PassingAttempts).IsRequired().HasColumnName("PassingAttempts").HasColumnType("int");
            builder.Property(c => c.PassingCompletions).IsRequired().HasColumnName("PassingCompletions").HasColumnType("int");
            builder.Property(c => c.PassingFirstDowns).IsRequired().HasColumnName("PassingFirstDowns").HasColumnType("int");
            builder.Property(c => c.PassingYards).IsRequired().HasColumnName("PassingYards").HasColumnType("int");
            builder.Property(c => c.PassOverFifteen).IsRequired().HasColumnName("PassOverFifteen").HasColumnType("int");
            builder.Property(c => c.PenaltyFirstDowns).IsRequired().HasColumnName("PenaltyFirstDowns").HasColumnType("int");
            builder.Property(c => c.PointsAllowed).IsRequired().HasColumnName("PointsAllowed").HasColumnType("int");
            builder.Property(c => c.PointsScored).IsRequired().HasColumnName("PointsScored").HasColumnType("int");
            builder.Property(c => c.RedzoneAttempts).IsRequired().HasColumnName("RedzoneAttempts").HasColumnType("int");
            builder.Property(c => c.RedzoneConverted).IsRequired().HasColumnName("RedzoneConverted").HasColumnType("int");
            builder.Property(c => c.RushingAttempts).IsRequired().HasColumnName("RushingAttempts").HasColumnType("int");
            builder.Property(c => c.RushingFirstDowns).IsRequired().HasColumnName("RushingFirstDowns").HasColumnType("int");
            builder.Property(c => c.RushingYards).IsRequired().HasColumnName("RushingYards").HasColumnType("int");
            builder.Property(c => c.RushOverTen).IsRequired().HasColumnName("RushOverTen").HasColumnType("int");
            builder.Property(c => c.ScheduleId).IsRequired().HasColumnName("ScheduleId").HasColumnType("bigint");
            builder.Property(c => c.TeamId).IsRequired().HasColumnName("TeamId").HasColumnType("int");
            builder.Property(c => c.ThirdDowns).IsRequired().HasColumnName("ThirdDowns").HasColumnType("int");
            builder.Property(c => c.ThirdDownsConverted).IsRequired().HasColumnName("ThirdDownsConverted").HasColumnType("int");
            builder.Property(c => c.TimeOfPossession).IsRequired().HasColumnName("TimeOfPossession").HasColumnType("bigint");
            builder.Property(c => c.TotalDrives).IsRequired().HasColumnName("TotalDrives").HasColumnType("int");
            builder.Property(c => c.TotalPlays).IsRequired().HasColumnName("TotalPlays").HasColumnType("int");
            builder.Property(c => c.TotalTurnovers).IsRequired().HasColumnName("TotalTurnovers").HasColumnType("int");
            builder.Property(c => c.TotalYards).IsRequired().HasColumnName("TotalYards").HasColumnType("int");
            builder.Property(c => c.YardsPerPass).IsRequired().HasColumnName("YardsPerPass").HasColumnType("float");
            builder.Property(c => c.YardsPerPlay).IsRequired().HasColumnName("YardsPerPlay").HasColumnType("float");
            builder.Property(c => c.YardsPerRush).IsRequired().HasColumnName("YardsPerRush").HasColumnType("float");
        }
    }
}
