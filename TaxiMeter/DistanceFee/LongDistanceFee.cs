using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiMeter
{
    /// <summary>
    /// 长途费
    /// </summary>
    public class LongDistanceFee : IDistanceFee
    {
        public double GetFee(int distance)
        {
            if( distance  > 8 )
            {
                return (distance - 8) * 1.2;
            }
            return 0;
        }
    }
}
