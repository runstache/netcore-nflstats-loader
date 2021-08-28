using FluentAssertions;
using System.Collections.Generic;
using NflStats.Data.DataObjects;
using NflStats.Loader.Models;
using NflStats.Loader.Transformers;
using NUnit.Framework;
using System;
using Newtonsoft.Json;

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
            
            model.Bio.Add(new KeyValuePair<string, string>("Position", "Quarterback"));
            model.Bio.Add(new KeyValuePair<string, string>("DOB", "5/21/1996 (25)"));

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
            model.Bio.Add(new KeyValuePair<string, string>("Position", "Quarterback"));
            model.Bio.Add(new KeyValuePair<string, string>("DOB", "5/21/1996(25)"));

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
            model.Bio.Add(new KeyValuePair<string, string>("DOB", "5/21/1996(25)"));

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
            model.Bio.Add(new KeyValuePair<string, string>("Position", "Quarterback"));

            var result = transformer.Transform(model);

            result.Dob.Should().BeNull();
            result.Name.Should().Be("Jim Smith");
            result.Position.Should().Be("Quarterback");
            result.Url.Should().Be("www.google.com");
        }

        [Test]
        public void TransformFromJson()
        {
            string json = "{\"url\": \"https://www.espn.com/nfl/player/_/id/3918298/josh-allen\",\"name\": \"Josh Allen\",\"bio\":[{\"key\": \"Position\",\"value\": \"Quarterback\"},{\"key\": \"DOB\",\"value\": \"5/21/1996 (25)\"}]}";
            var settings = new JsonSerializerSettings()
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore
            };

            var model = JsonConvert.DeserializeObject<PlayerModel>(json, settings);
            var result = transformer.Transform(model);

            result.Dob.Should().Be(new DateTime(1996, 5, 21));
            result.Name.Should().Be("Josh Allen");
            result.Position.Should().Be("Quarterback");
            result.Url.Should().Be("https://www.espn.com/nfl/player/_/id/3918298/josh-allen");
        }

    }
}
