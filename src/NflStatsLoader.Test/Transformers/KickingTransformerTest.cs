using FluentAssertions;
using Newtonsoft.Json;
using NflStats.Data.DataObjects;
using NflStats.Loader.Models;
using NflStats.Loader.Transformers;
using NUnit.Framework;

namespace NflStatsLoader.Test.Transformers
{
    public class KickingTransformerTest
    {
        private ITransformer<KickingModel, KickingStat> transformer;

        [SetUp]
        public void Setup()
        {
            transformer = new KickingTransformer();
        }

        [Test]
        public void TestTransform()
        {
            var model = new KickingModel()
            {
                Points = "20",
                FieldGoalAttempts = "4",
                FieldGoalMade = "2",
                LongFieldGoal = "35",
                XpAttempted = "3",
                XpMade = "2"
            };

            var result = transformer.Transform(model);

            result.FieldGoals.Should().Be(2);
            result.LongFieldGoal.Should().Be(35);
            result.Attempts.Should().Be(4);
            result.ExtraPointAttempts.Should().Be(3);
            result.ExtraPoints.Should().Be(2);
            result.Points.Should().Be(20);
        }

        [Test]
        public void TestTransformFromJson()
        {
            string json = "{\"fieldGoalMade\": \"2\",\"fieldGoalAttempts\": \"4\",\"xpMade\": \"3\",\"xpAttempted\": \"3\",\"longFieldGoal\": \"22\",\"points\": \"9\"}";

            var settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            var model = JsonConvert.DeserializeObject<KickingModel>(json, settings);

            var result = transformer.Transform(model);

            result.FieldGoals.Should().Be(2);
            result.LongFieldGoal.Should().Be(22);
            result.Attempts.Should().Be(4);
            result.ExtraPointAttempts.Should().Be(3);
            result.ExtraPoints.Should().Be(3);
            result.Points.Should().Be(9);
        }
    }
}
