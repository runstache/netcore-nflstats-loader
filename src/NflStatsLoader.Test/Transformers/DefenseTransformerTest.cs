using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NflStats.Data.DataObjects;
using NflStats.Loader.Transformers;
using NflStats.Loader.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using FluentAssertions;

namespace NflStatsLoader.Test.Transformers
{
    public class DefenseTransformerTest
    {
        private ITransformer<DefenseModel, DefensiveStat> transformer;

        [Test]
        public void TestTransform()
        {
            transformer = new DefenseTransformer();

            var model = new DefenseModel()
            {
                PassesDefended = "1",
                QbHits = "2",
                Sacks = "3",
                SoloTackles = "4",
                TacklesForLoss = "1",
                TotalTackles = "5",
                Touchdowns = "1"
            };

            var result = transformer.Transform(model);
            result.PassesDefended.Should().Be(1);
            result.QbHits.Should().Be(2);
            result.Sacks.Should().Be(3);
            result.SoloTackles.Should().Be(4);
            result.TacklesForLoss.Should().Be(1);
            result.TotalTackles.Should().Be(5);
            result.Touchdowns.Should().Be(1);

        }

        [Test]
        public void TestTransformFromJson()
        {
            string json = "{\"totalTackles\": \"5\",\"soloTackles\": \"4\",\"sacks\": \"0\",\"tacklesForLoss\": \"0\",\"qbHits\":\"0\",\"touchdowns\": \"0\",\"passesDefended\": \"1\"}";

            var settings = new JsonSerializerSettings()
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore
            };

            var model = JsonConvert.DeserializeObject<DefenseModel>(json, settings);

            var result = transformer.Transform(model);

            result.PassesDefended.Should().Be(1);
            result.QbHits.Should().Be(0);
            result.Sacks.Should().Be(0);
            result.SoloTackles.Should().Be(4);
            result.TacklesForLoss.Should().Be(0);
            result.TotalTackles.Should().Be(5);
            result.Touchdowns.Should().Be(0);
        }

    }
}
