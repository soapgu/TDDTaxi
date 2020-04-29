using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiMeter
{
    /// <summary>
    /// 计程接口
    /// </summary>
    public interface IDistanceFee
    {
        /// <summary>
        /// 计程费用
        /// </summary>
        /// <param name="distance"></param>
        /// <returns></returns>
        public double GetFee(int distance);
    }
}
