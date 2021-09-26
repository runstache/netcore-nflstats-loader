using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NflStats.Loader.Models;
using NflStats.Data.DataObjects;
using NflStats.Loader.Transformers;
using NUnit.Framework;
using Newtonsoft.Json;
using FluentAssertions;

namespace NflStatsLoader.Test.Transformers
{
    public class ReceivingTransformerTest
    {
        private ITransformer<ReceivingModel, ReceivingStat> transformer;

        [SetUp]
        public void Setup()
        {
            transformer = new ReceivingTransformer();
        }

        [Test]
        public void TestTransform()
        {
            var model = new ReceivingModel()
            {
                ReceivingAverage = "10.8",
                Receptions = "8",
                LongCatch = "22",
                Targets = "9",
                Touchdowns = "1",
                Yards = "86"
            };

            var result = transformer.Transform(model);

            result.AveragePerReception.Should().Be(10.8);
            result.LongestReception.Should().Be(22);
            result.Receptions.Should().Be(8);
            result.Targets.Should().Be(9);
            result.Touchdowns.Should().Be(1);
            result.Yards.Should().Be(86);
        }

        [Test]
        public void TestTransformFromJson()
        {
            string json = "{\"yards\": \"86\",\"receivingAverage\": \"10.8\",\"touchdowns\": \"0\",\"receptions\": \"8\",\"longcatch\": \"22\",\"targets\": \"9\"}";
            var settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            var model = JsonConvert.DeserializeObject<ReceivingModel>(json, settings);

            var result = transformer.Transform(model);

            result.AveragePerReception.Should().Be(10.8);
            result.LongestReception.Should().Be(22);
            result.Receptions.Should().Be(8);
            result.Targets.Should().Be(9);
            result.Touchdowns.Should().Be(0);
            result.Yards.Should().Be(86);
        }

    }
}
