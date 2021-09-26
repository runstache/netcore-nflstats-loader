using FluentAssertions;
using Newtonsoft.Json;
using NflStats.Data.DataObjects;
using NflStats.Loader.Models;
using NflStats.Loader.Transformers;
using NUnit.Framework;

namespace NflStatsLoader.Test.Transformers
{
    public class PuntingTransformerTest
    {
        private ITransformer<PuntingModel, KickingStat> transformer;

        [SetUp]
        public void Setup()
        {
            transformer = new PuntingTransformer();                      
        }

        [Test]
        public void TestTransform()
        {
            var model = new PuntingModel()
            {
                AveragePunt = "23.4",
                InsideTwenty = "2",
                LongPunt = "54",
                Punts = "3",
                Touchbacks = "4",
                Yards = "250"
            };

            var result = transformer.Transform(model);
            result.Punts.Should().Be(3);
            result.PuntTotalYards.Should().Be(250);
            result.PuntInsideTwenty.Should().Be(2);
            result.AveragePunt.Should().Be(23.4);
            result.PuntLongest.Should().Be(54);
            result.Touchbacks.Should().Be(4);

        }

        [Test]
        public void TestTransformFromJson()
        {
            string json = "{\"punts\": \"1\",\"yards\": \"53\",\"averagePunt\": \"53.0\",\"insideTwenty\": \"0\",\"longPunt\": \"53\",\"touchbacks\": \"0\"}";

            var settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            var model = JsonConvert.DeserializeObject<PuntingModel>(json, settings);

            var result = transformer.Transform(model);

            result.Punts.Should().Be(1);
            result.PuntTotalYards.Should().Be(53);
            result.PuntInsideTwenty.Should().Be(0);
            result.AveragePunt.Should().Be(53);
            result.PuntLongest.Should().Be(53);
            result.Touchbacks.Should().Be(0);

        }
    }
}
