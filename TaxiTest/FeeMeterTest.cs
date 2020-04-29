using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using TaxiMeter;
using Xunit.Abstractions;
using System.Linq;

namespace TaxiTest
{
    public class FeeMeterTest
    {
        private readonly ITestOutputHelper output;
        public FeeMeterTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [InlineData(1, 0, 6)]
        [InlineData(3, 0, 7)]
        [InlineData(10, 0, 13)]
        [InlineData(2, 3, 7)]
        public void ComposeFeeTest( int distance , int minute , double expectFee )
        {
            FeeMeter meter = new FeeMeter(distance, minute);
            Assert.Equal(expectFee, meter.Calculate());
        }

        [Theory]
        [InlineData(1, 0)]
        [InlineData(3, 0.8)]
        [InlineData(10, 4.8)]
        public void NormalFeeTest(int distance, double expectFee)
        {
            NormalFee normalFee = new NormalFee();
            var fee = normalFee.GetFee(distance);
            Assert.Equal(expectFee, fee, 2);
        }


        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 6)]
        [InlineData(3, 6)]
        [InlineData(10, 6)]
        public void BaseFeeTest(int distance, double expectFee)
        {
            BaseFee baseFee = new BaseFee();
            var fee = baseFee.GetFee(distance);
            Assert.Equal(expectFee, fee);
        }


        [Theory]
        [InlineData(1, 0)]
        [InlineData(3, 0)]
        [InlineData(10, 2.4)]
        public void LongDistanceFeeTest( int distance , double expectFee )
        {
            LongDistanceFee longDistanceFee = new LongDistanceFee();
            var fee = longDistanceFee.GetFee(distance);
            Assert.Equal(expectFee, fee);
        }
    }
}
