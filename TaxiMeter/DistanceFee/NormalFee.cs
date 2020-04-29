using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiMeter
{
    /// <summary>
    /// 标准计价
    /// </summary>
    public class NormalFee : IDistanceFee
    {
        public double GetFee(int distance)
        {
            if( distance > 2 )
                return Math.Min( 6 , (distance - 2) )  * 0.8;
            return 0;
        }
    }
}
