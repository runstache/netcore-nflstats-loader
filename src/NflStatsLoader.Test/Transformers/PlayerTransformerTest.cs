using FluentAssertions;
using NflStats.Data.DataObjects;
using NflStats.Loader.Models;
using NflStats.Loader.Transformers;
using NUnit.Framework;
using System;

namespace NflStatsLoader.Test.Transformers
{
    public class PlayerTransformerTest
    {
        private ITransformer<PlayerModel, Player> transformer;

        [SetUp]
        public void Setup()
        {
            transformer = new PlayerTransformer();

        }

        [Test]
        public void TransformTest()
        {
            var model = new PlayerModel()
            {
                Url = "www.google.com",
                Name = "Jim Smith"
            };
            model.Bio.Add("Position", "Quarterback");
            model.Bio.Add("DOB", "5/21/1996 (25)");

            var result = transformer.Transform(model);
            
            result.Dob.Should().Be(new DateTime(1996, 5, 21));
            result.Name.Should().Be("Jim Smith");
            result.Position.Should().Be("Quarterback");
            result.Url.Should().Be("www.google.com");
        }

        [Test]
        public void TransformBadDob()
        {
            var model = new PlayerModel()
            {
                Url = "www.google.com",
                Name = "Jim Smith"
            };
            model.Bio.Add("Position", "Quarterback");
            model.Bio.Add("DOB", "5/21/1996(25)");

            var result = transformer.Transform(model);

            result.Dob.Should().BeNull();
            result.Name.Should().Be("Jim Smith");
            result.Position.Should().Be("Quarterback");
            result.Url.Should().Be("www.google.com");
        }

        [Test]
        public void TransformNoPosition()
        {
            var model = new PlayerModel()
            {
                Url = "www.google.com",
                Name = "Jim Smith"
            };
            model.Bio.Add("DOB", "5/21/1996(25)");

            var result = transformer.Transform(model);

            result.Dob.Should().BeNull();
            result.Name.Should().Be("Jim Smith");
            result.Position.Should().BeNull();
            result.Url.Should().Be("www.google.com");
        }

        [Test]
        public void TransformNoDob()
        {
            var model = new PlayerModel()
            {
                Url = "www.google.com",
                Name = "Jim Smith"
            };
            model.Bio.Add("Position", "Quarterback");

            var result = transformer.Transform(model);

            result.Dob.Should().BeNull();
            result.Name.Should().Be("Jim Smith");
            result.Position.Should().Be("Quarterback");
            result.Url.Should().Be("www.google.com");
        }

    }
}
