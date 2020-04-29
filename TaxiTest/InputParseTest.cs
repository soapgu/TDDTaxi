using System;
using Xunit;
using TaxiMeter;

namespace TaxiTest
{
    public class InputParseTest
    {
        [Theory]
        [InlineData("1����,�ȴ�0����\n3����,�ȴ�0����", 2 )]
        public void TestMutiLineInput( string arg , int expectCount)
        {
            InputParse parse = new InputParse(arg);
            Assert.Equal(expectCount, parse.Journeys.Count);
        }

        [Theory]
        [InlineData("1����,�ȴ�0����", 1,0)]
        [InlineData("2����,�ȴ�3����", 2,3)]
        public void TestArgInput(string arg,int expectDistance,int expectMinute)
        {
            InputParse parse = new InputParse(arg);
            Assert.Single(parse.Journeys);
            Assert.Equal(expectDistance, parse.Journeys[0].distance);
            Assert.Equal(expectMinute, parse.Journeys[0].minute);
        }

        [Theory]
        [InlineData("01����,�ȴ�0����")]
        [InlineData("01����,12345�ȴ�0����")]
        [InlineData("1����")]
        public void InvildArgInput( string arg )
        {
            Assert.Throws<ArgumentException>(() => new InputParse(arg));
        }
    }
}
