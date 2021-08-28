using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NflStats.Data.Contexts;
using NflStats.Data.DataObjects;
using NflStats.Data.Repositories;
using NUnit.Framework;

namespace NflStatsLoader.Test.Repositories
{
    /// <summary>
    /// Tests that the Entity Type Configurations are working
    /// as Expected with the Inheritance.
    /// This is not an exhaustive test of the DAL to the SQL Server Database.
    /// </summary>
    public class SqlRespositoryAddTest
    {
        private SqlContext ctx;
        private IRepository repo;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder().UseInMemoryDatabase("TestDb");
            ctx = new SqlContext(options.Options);
            repo = new SqlRespository(ctx);
        }

        [Test]
        public void TestAddDefenseStat()
        {
            var stat = new DefensiveStat()
            {
                Id = 1,
                Sacks = 2,

            };

            repo.Save(stat);
            var result = repo.GetDefensiveStat(1);

            result.Id.Should().Be(1);
            result.Sacks.Should().Be(2);
        }

        [Test]
        public void TestAddFumbleStat()
        {
            var stat = new FumbleStat()
            {
                Id = 1,
                Fumbles = 2
            };
            repo.Save(stat);
            var result = repo.GetFumbleStat(1);

            result.Id.Should().Be(1);
            result.Fumbles.Should().Be(2);
        }

        [Test]
        public void TestAddInterceptionStat()
        {
            var stat = new InterceptionStat()
            {
                Id = 1,
                Interceptions = 2
            };
            repo.Save(stat);

            var result = repo.GetInterceptionStat(1);
            result.Id.Should().Be(1);
            result.Interceptions.Should().Be(2);
        }

        [Test]
        public void TestAddKickingStat()
        {
            var stat = new KickingStat()
            {
                Id = 1,
                Attempts = 2,
                FieldGoals = 3
            };
            repo.Save(stat);

            var result = repo.GetKickingStat(1);
            result.Id.Should().Be(1);
            result.Attempts.Should().Be(2);
            result.FieldGoals.Should().Be(3);
        }

        [Test]
        public void TestAddPassingStat()
        {
            var stat = new PassingStat()
            {
                Id = 1,
                Attempts = 25,
                Completions = 20
            };
            repo.Save(stat);
            var result = repo.GetPassingStat(1);
            result.Id.Should().Be(1);
            result.Attempts.Should().Be(25);
            result.Completions.Should().Be(20);
        }

        [Test]
        public void TestAddPlayer()
        {
            var player = new Player()
            {
                Name = "Jeff Smith",
                Id = 1
            };

            repo.Save(player);

            var result = repo.GetPlayer(1);
            result.Id.Should().Be(1);
            result.Name.Should().Be("Jeff Smith");
        }

        [Test]
        public void TestAddReceivingStat()
        {
            var stat = new ReceivingStat()
            {
                Id = 1,
                Receptions = 5
            };

            repo.Save(stat);
            var result = repo.GetReceivingStat(1);
            result.Id.Should().Be(1);
            result.Receptions.Should().Be(5);               
        }

        [Test]
        public void TestAddReturnStat()
        {
            var stat = new ReturnStat()
            {
                Id = 1,
                KickReturns = 5
            };
            repo.Save(stat);
            var result = repo.GetReturnStat(1);
            result.Id.Should().Be(1);
            result.KickReturns.Should().Be(5);                
        }

        [Test]
        public void TestAddRushingStat()
        {
            var stat = new RushingStat()
            {
                Id = 1,
                Carries = 10
            };
            repo.Save(stat);

            var result = repo.GetRushingStat(1);
            result.Id.Should().Be(1);
            result.Carries.Should().Be(10);
        }

        [Test]
        public void TestAddScheduleItem()
        {
            var item = new ScheduleItem()
            {
                Id = 1,
                TeamId = 1,
                OpponentId = 2,
                GameId = 1234
            };
            repo.Save(item);

            var result = repo.GetScheduleItem(1);
            result.Id.Should().Be(1);
            result.TeamId.Should().Be(1);
            result.OpponentId.Should().Be(2);
            result.GameId.Should().Be(1234);
        }

        [Test]
        public void TestAddTeam()
        {
            var team = new Team()
            {
                Id = 1,
                Name = "LA RAMS",
                Code = "LAR"
            };

            repo.Save(team);

            var result = repo.GetTeam(1);

            result.Id.Should().Be(1);
            result.Code.Should().Be("LAR");
            result.Name.Should().Be("LA RAMS");                
        }

        [Test]
        public void TestAddTeamStat()
        {
            var stat = new TeamStat()
            {
                Id = 1,
                TeamId = 2,
                TotalYards = 450
            };
            repo.Save(stat);

            var result = repo.GetTeamStat(1);
            result.Id.Should().Be(1);
            result.TeamId.Should().Be(2);
            result.TotalYards.Should().Be(450);
        }

        [Test]
        public void TestAddTypeCode()
        {
            var code = new TypeCode()
            {
                Id = 1,
                Code = "HM",
                Description = "Home"
            };

            repo.Save(code);
            var result = repo.GetTypeCode(1);
            result.Id.Should().Be(1);
            result.Code.Should().Be("HM");
            result.Description.Should().Be("Home");
        }

    }
}
