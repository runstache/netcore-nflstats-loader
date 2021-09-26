using FluentAssertions;
using Newtonsoft.Json;
using NflStats.Data.DataObjects;
using NflStats.Loader.Models;
using NflStats.Loader.Transformers;
using NUnit.Framework;


namespace NflStatsLoader.Test.Transformers
{
    public class PassingTransformerTest
    {

        private ITransformer<PassingModel, PassingStat> transformer;

        [SetUp]
        public void Setup()
        {


            transformer = new PassingTransformer();
        }

        [Test]
        public void TestTransform()
        {

            var model = new PassingModel()
            {
                Completions = "33",
                Attempts = "46",
                PassingAverage = "6.8",
                Interceptions = "1",
                Sacks = "2",
                QbRating = "66.8",
                Rating = "104.6",
                Touchdowns = "4",
                Yards = "250"
            };

            var result = transformer.Transform(model);

            result.Attempts.Should().Be(46);
            result.AveragePerAttempt.Should().Be(6.8);
            result.Completions.Should().Be(33);
            result.Interceptions.Should().Be(1);
            result.Qbr.Should().Be(66.8);
            result.Rating.Should().Be(104.6);
            result.Sacks.Should().Be(2);
            result.Touchdowns.Should().Be(4);
            result.Yards.Should().Be(250);
        }

        [Test]
        public void TestFromJson()
        {
            string json = "{\"completions\": \"33\",\"attempts\": \"46\",\"sacks\": \"3\",\"yards\": \"312\",\"passingAverage\":\"6.8\",\"touchdowns\": \"2\",\"interceptions\": \"0\",\"qbrating\": \"66.8\",\"rating\": \"104.6\"}";
            var settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            var model = JsonConvert.DeserializeObject<PassingModel>(json, settings);

            var result = transformer.Transform(model);

            result.Attempts.Should().Be(46);
            result.AveragePerAttempt.Should().Be(6.8);
            result.Completions.Should().Be(33);
            result.Interceptions.Should().Be(0);
            result.Qbr.Should().Be(66.8);
            result.Rating.Should().Be(104.6);
            result.Sacks.Should().Be(3);
            result.Touchdowns.Should().Be(2);
            result.Yards.Should().Be(312);
        }
    }
}
