using System;
using Xunit;
using TaxiMeter;

namespace TaxiTest
{
    public class InputParseTest
    {
        [Theory]
        [InlineData("1公里,等待0分钟\n3公里,等待0分钟", 2 )]
        public void TestMutiLineInput( string arg , int expectCount)
        {
            InputParse parse = new InputParse(arg);
            Assert.Equal(expectCount, parse.Journeys.Count);
        }

        [Theory]
        [InlineData("1公里,等待0分钟", 1,0)]
        [InlineData("2公里,等待3分钟", 2,3)]
        public void TestArgInput(string arg,int expectDistance,int expectMinute)
        {
            InputParse parse = new InputParse(arg);
            Assert.Single(parse.Journeys);
            Assert.Equal(expectDistance, parse.Journeys[0].distance);
            Assert.Equal(expectMinute, parse.Journeys[0].minute);
        }

        [Theory]
        [InlineData("01公里,等待0分钟")]
        [InlineData("01公里,12345等待0分钟")]
        [InlineData("1公里")]
        public void InvildArgInput( string arg )
        {
            Assert.Throws<ArgumentException>(() => new InputParse(arg));
        }
    }
}
