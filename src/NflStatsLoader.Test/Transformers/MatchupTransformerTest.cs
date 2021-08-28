using FluentAssertions;
using Newtonsoft.Json;
using NflStats.Data.DataObjects;
using NflStats.Loader.Models;
using NflStats.Loader.Transformers;
using NUnit.Framework;
using System.IO;
using System.Linq;

namespace NflStatsLoader.Test.Transformers
{
    public class MatchupTransformerTest
    {
        private MatchupTransformer transformer;

        [SetUp]
        public void Setup()
        {
            transformer = new MatchupTransformer();
        }

        [Test]
        public void TestTransformFromJson()
        {
            string json = File.ReadAllText(TestContext.CurrentContext.TestDirectory + "\\TestData\\test-matchup.json");

            var settings = new JsonSerializerSettings()
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore
            };

            var model = JsonConvert.DeserializeObject<MatchupModel>(json, settings);

            var result = transformer.Transform(model);

            result.Count.Should().Be(2);

            result.TryGetValue("home", out TeamStat home).Should().BeTrue();
            home.PassingFirstDowns.Should().Be(8);
            home.RushingFirstDowns.Should().Be(4);
            home.PenaltyFirstDowns.Should().Be(3);
            home.ThirdDowns.Should().Be(11);
            home.ThirdDownsConverted.Should().Be(4);
            home.FourthDownAttempt.Should().Be(0);
            home.FourthDownConverted.Should().Be(0);
            home.TotalYards.Should().Be(254);
            home.TotalDrives.Should().Be(11);
            home.YardsPerPlay.Should().Be(4.8);
            home.PassingYards.Should().Be(202);
            home.PassingAttempts.Should().Be(35);
            home.PassingCompletions.Should().Be(21);
            home.YardsPerPass.Should().Be(5.3);
            home.RushingYards.Should().Be(52);
            home.RushingAttempts.Should().Be(15);
            home.YardsPerRush.Should().Be(3.5);
            home.RedzoneAttempts.Should().Be(2);
            home.RedzoneConverted.Should().Be(1);
            home.Penalties.Should().Be(9);
            home.PenaltyYards.Should().Be(95);
            home.TotalTurnovers.Should().Be(2);
            home.FumblesLost.Should().Be(1);
            home.Interceptions.Should().Be(1);
            home.DefensiveTouchdowns.Should().Be(0);
            home.TimeOfPossession.Should().Be(1123);

            result.TryGetValue("away", out TeamStat away).Should().BeTrue();
            away.PassingFirstDowns.Should().Be(17);
            away.RushingFirstDowns.Should().Be(8);
            away.PenaltyFirstDowns.Should().Be(6);
            away.ThirdDowns.Should().Be(14);
            away.ThirdDownsConverted.Should().Be(7);
            away.FourthDownAttempt.Should().Be(1);
            away.FourthDownConverted.Should().Be(1);
            away.TotalYards.Should().Be(404);
            away.TotalDrives.Should().Be(11);
            away.YardsPerPlay.Should().Be(5);
            away.PassingYards.Should().Be(306);
            away.PassingAttempts.Should().Be(46);
            away.PassingCompletions.Should().Be(33);
            away.YardsPerPass.Should().Be(6.2);
            away.RushingYards.Should().Be(98);
            away.RushingAttempts.Should().Be(32);
            away.YardsPerRush.Should().Be(3.1);
            away.RedzoneAttempts.Should().Be(8);
            away.RedzoneConverted.Should().Be(3);
            away.Penalties.Should().Be(7);
            away.PenaltyYards.Should().Be(79);
            away.TotalTurnovers.Should().Be(2);
            away.FumblesLost.Should().Be(2);
            away.Interceptions.Should().Be(0);
            away.DefensiveTouchdowns.Should().Be(1);
            away.TimeOfPossession.Should().Be(2477);
        }
    }
}
