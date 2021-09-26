using FluentAssertions;
using Newtonsoft.Json;
using NflStats.Data.DataObjects;
using NflStats.Loader.Models;
using NflStats.Loader.Transformers;
using NUnit.Framework;

namespace NflStatsLoader.Test.Transformers
{
    public class InterceptionTransformerTest
    {
        private ITransformer<InterceptionModel, InterceptionStat> transformer;

        [SetUp]
        public void Setup()
        {
            transformer = new InterceptionTransformer();
        }

        [Test]
        public void TestTransform()
        {
            var model = new InterceptionModel()
            {
                Interceptions = "1",
                Touchdowns = "2",
                Yards = "50"
            };

            var result = transformer.Transform(model);

            result.Interceptions.Should().Be(1);
            result.Touchdowns.Should().Be(2);
            result.Yards.Should().Be(50);
        }

        [Test]
        public void TestTransformFromJson()
        {
            string json = "{\"interceptions\": \"1\",\"yards\": \"0\",\"touchdowns\": \"0\"}";

            var settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            var model = JsonConvert.DeserializeObject<InterceptionModel>(json, settings);

            var result = transformer.Transform(model);

            result.Interceptions.Should().Be(1);
            result.Yards.Should().Be(0);
            result.Touchdowns.Should().Be(0);
        }
    }
}
