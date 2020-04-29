using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TaxiMeter
{
    /// <summary>
    /// 费用计价
    /// </summary>
    public class FeeMeter
    {
        private int distance;
        private int minute;
        private static readonly IEnumerable<IDistanceFee> distanceFees;

        static FeeMeter()
        {
            distanceFees = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.IsClass && typeof(IDistanceFee).IsAssignableFrom(t))
                .Select( t => Activator.CreateInstance(t) )
                .Cast<IDistanceFee>();
        }
            
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="distance">距离</param>
        /// <param name="minute">等待分钟</param>
        public FeeMeter( int distance , int minute )
        {
            this.distance = distance;
            this.minute = minute;
        }
        /// <summary>
        /// 计价
        /// </summary>
        /// <returns>费用</returns>
        public double Calculate()
        {
            var distanceFee = distanceFees.Sum( t=>t.GetFee(distance) );
            var timeFee = minute * 0.25;
            var retValue = Math.Round(distanceFee + timeFee);
            return retValue;
        }
    }
}
