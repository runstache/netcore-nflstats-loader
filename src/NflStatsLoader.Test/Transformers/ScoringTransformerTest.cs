using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using NflStats.Data.DataObjects;
using NflStats.Loader.Models;
using NflStats.Loader.Transformers;
using NUnit.Framework;

namespace NflStatsLoader.Test.Transformers
{
    public class ScoringTransformerTest
    {
        private ITransformer<ScoreValueModel, ScoringStat> transformer;

        [SetUp]
        public void Setup()
        {
            transformer = new ScoringTransformer();
        }

        [Test]
        public void TestTransform()
        {
            var model = new ScoreValueModel()
            {
                Quarter = 2,
                Points = "42"
            };

            var result = transformer.Transform(model);

            result.Quarter.Should().Be(2);
            result.Points.Should().Be(42);
        }

        public void TestTransformFromJson()
        {
            string json = "{\"quarter\": 1,\"points\": \"14\"}";
            var settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            var model = JsonConvert.DeserializeObject<ScoreValueModel>(json, settings);

            var result = transformer.Transform(model);

            result.Quarter.Should().Be(1);
            result.Points.Should().Be(14);

        }


    }
}
