using FluentAssertions;
using Newtonsoft.Json;
using NflStats.Data.DataObjects;
using NflStats.Loader.Models;
using NflStats.Loader.Transformers;
using NUnit.Framework;

namespace NflStatsLoader.Test.Transformers
{
    public class ReturnTransformerTest
    {
        private ITransformer<ReturnModel, ReturnStat> transformer;

        [SetUp]
        public void Setup()
        {
            transformer = new ReturnTransformer();
        }

        [Test]
        public void TestTransform()
        {
            var model = new ReturnModel()
            {
                AverageReturn = "25.6",
                KickReturns = "2",
                LongReturn = "31",
                Touchdowns = "2",
                Yards = "31"
            };

            var result = transformer.Transform(model);
            result.AverageReturn.Should().Be(25.6);
            result.KickReturns.Should().Be(2);
            result.LongReturn.Should().Be(31);
            result.Touchdowns.Should().Be(2);
            result.Yards.Should().Be(31);

        }

        [Test]
        public void TestTransformFromJson()
        {
            string json = "{\"kickReturns\": \"1\",\"yards\": \"31\",\"averageReturn\": \"31.0\",\"longReturn\": \"31\",\"touchdowns\": \"0\"}";

            var settings = new JsonSerializerSettings()
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore
            };

            var model = JsonConvert.DeserializeObject<ReturnModel>(json, settings);

            var result = transformer.Transform(model);

            result.AverageReturn.Should().Be(31);
            result.KickReturns.Should().Be(1);
            result.LongReturn.Should().Be(31);
            result.Touchdowns.Should().Be(0);
            result.Yards.Should().Be(31);
        }
    }
}
