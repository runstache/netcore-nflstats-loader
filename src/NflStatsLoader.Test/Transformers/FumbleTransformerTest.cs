using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NflStats.Data.DataObjects;
using NflStats.Loader.Models;
using NflStats.Loader.Transformers;
using Newtonsoft.Json;
using NUnit.Framework;
using FluentAssertions;

namespace NflStatsLoader.Test.Transformers
{
    public class FumbleTransformerTest
    {
        private ITransformer<FumbleModel, FumbleStat> transformer;

        [SetUp]
        public void Setup()
        {
            transformer = new FumbleTransformer();
        }

        [Test]
        public void TestTransform()
        {
            var model = new FumbleModel()
            {
                FumblesRecovered = "1",
                FumblesLost = "2",
                Fumbles = "2"
            };
            var result = transformer.Transform(model);

            result.Fumbles.Should().Be(2);
            result.FumblesLost.Should().Be(2);
            result.FumblesRecovered.Should().Be(1);
        }

        [Test]
        public void TestTransformFromJson()
        {
            string json = "{\"fumbles\": \"2\",\"fumblesLost\": \"2\",\"fumblesRecovered\": \"0\"}";
            var settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            var model = JsonConvert.DeserializeObject<FumbleModel>(json, settings);

            var result = transformer.Transform(model);

            result.Fumbles.Should().Be(2);
            result.FumblesLost.Should().Be(2);
            result.FumblesRecovered.Should().Be(0);
        }

    }
}
