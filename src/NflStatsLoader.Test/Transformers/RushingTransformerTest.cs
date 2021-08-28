using FluentAssertions;
using Newtonsoft.Json;
using NflStats.Data.DataObjects;
using NflStats.Loader.Models;
using NflStats.Loader.Transformers;
using NUnit.Framework;

namespace NflStatsLoader.Test.Transformers
{
    public class RushingTransformerTest
    {

        private ITransformer<RushingModel, RushingStat> transformer;

        [SetUp]
        public void Setup()
        {
            transformer = new RushingTransformer();
        }

        [Test]
        public void TestTransform()
        {
            var model = new RushingModel()
            {
                RushingAverage = "4.1",
                LongRush = "14",
                Carries = "16",
                Touchdowns = "1",
                Yards = "57"
            };

            var result = transformer.Transform(model);

            result.AveragePerCarry.Should().Be(4.1);
            result.Carries.Should().Be(16);
            result.LongestCarry.Should().Be(14);
            result.Touchdowns.Should().Be(1);
            result.Yards.Should().Be(57);
        }

        [Test]
        public void TestTransformFromJson()
        {
            string json = "{\"yards\": \"57\",\"rushingAverage\": \"4.1\",\"touchdowns\": \"1\",\"carries\": \"14\",\"longrush\":\"16\"}";

            var settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            var model = JsonConvert.DeserializeObject<RushingModel>(json, settings);

            var result = transformer.Transform(model);

            result.AveragePerCarry.Should().Be(4.1);
            result.Carries.Should().Be(14);
            result.LongestCarry.Should().Be(16);
            result.Touchdowns.Should().Be(1);
            result.Yards.Should().Be(57);

        }

    }
}
