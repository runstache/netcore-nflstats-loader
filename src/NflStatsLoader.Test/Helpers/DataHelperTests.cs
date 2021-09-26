using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NflStats.Loader.Helpers;
using NUnit.Framework;
using FluentAssertions;


namespace NflStatsLoader.Test.Helpers
{
    public class DataHelperTests
    {
        [Test]
        public void ParseIntTest()
        {
            var result = DataHelper.ParseInt("25");
            result.Should().Be(25);
        }

        [Test]
        public void ParseLongTest()
        {
            var result = DataHelper.ParseLong("568");
            result.Should().Be(568L);
        }

        [Test]
        public void ParseDoubleTest()
        {
            var result = DataHelper.ParseDouble("55.6");
            result.Should().Be(55.6);
        }

        [Test]
        public void ParseDateTimeTest()
        {
            var result = DataHelper.ParseDateTime("20200506", "yyyyMMdd");
            result.Should().Be(new DateTime(2020, 5, 6));
        }

        [Test]
        public void ParseIntFailureTest()
        {
            var result = DataHelper.ParseInt("jeff");
            result.Should().Be(0);
        }

        [Test]
        public void ParseLongFailureTest()
        {
            var result = DataHelper.ParseLong("jeff");
            result.Should().Be(0);
        }

        [Test]
        public void ParseDoubleFailureTest()
        {
            var result = DataHelper.ParseDouble("jeff");
            result.Should().Be(0);
        }

        [Test]
        public void ParseDateTimeFailureTest()
        {
            var result = DataHelper.ParseDateTime("jeff", "yyyyMMdd");
            result.Should().BeNull();
        }

        [Test]
        public void ParseDateTimeNoFormatTest()
        {
            var result = DataHelper.ParseDateTime("5/6/2020", "");
            result.Should().Be(new DateTime(2020, 5, 6));
        }

        [Test]
        public void ParseDateTimeNoFormatFailure()
        {
            var result = DataHelper.ParseDateTime("20200506", "");
            result.Should().BeNull();
        }

        [Test]
        public void TestSplitInt()
        {
            var result = DataHelper.SplitInteger("2-4", "-", 1);
            result.Should().Be(4);
        }

        [Test]
        public void TestSplitLong()
        {
            var result = DataHelper.SplitLong("2-7", "-", 0);
            result.Should().Be(2);
        }

        [Test]
        public void TestSplitDouble()
        {
            var result = DataHelper.SplitDouble("2-6.8", "-", 1);
            result.Should().Be(6.8);
        }

        [Test]
        public void TestSplitIntNoIndex()
        {
            var result = DataHelper.SplitInteger("2-4", "-", 2);
            result.Should().Be(0);
        }

        [Test]
        public void TestSplitLongNoIndex()
        {
            var result = DataHelper.SplitLong("2-6.8", "-", 2);
            result.Should().Be(0);
        }

        [Test]
        public void TestSplitDoubleNoIndex()
        {
            var result = DataHelper.SplitDouble("2-6.8", "-", 3);
            result.Should().Be(0);
        }

        [Test]
        public void TestSplitIntNullValue()
        {
            var result = DataHelper.SplitInteger(null, "-", 2);
            result.Should().Be(0);
        }

        [Test]
        public void TestSplitLongNullValue()
        {
            var result = DataHelper.SplitLong(null, "-", 2);
            result.Should().Be(0);
        }

        [Test]
        public void TestSplitDoubleNullValue()
        {
            var result = DataHelper.SplitDouble(null, "-", 3);
            result.Should().Be(0);
        }
    }
}
