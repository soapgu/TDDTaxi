using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiMeter
{
    /// <summary>
    /// 起步费
    /// </summary>
    public class BaseFee : IDistanceFee
    {
        public double GetFee(int distance)
        {
            return distance > 0 ? 6 : 0;
        }
    }
}
