using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TaxiMeter
{
    /// <summary>
    /// 输入解析类
    /// </summary>
    public class InputParse
    {
        private const string linePattern = @"^([1-9]\d*|0)公里,等待([1-9]\d*|0)分钟$";
        private const string valuePattern = @"([1-9]\d*|0)";
       
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="arg">传入参数</param>
        public InputParse( string arg )
        {
            var lines = arg.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            if( lines.All(t => Regex.IsMatch(t, linePattern)) )
            {
                Journeys = lines.Select(t =>
                {
                    var matches = Regex.Matches(t, valuePattern);
                    var distance = int.Parse(matches[0].Value );
                    var minute = int.Parse(matches[1].Value );
                    return (distance, minute);
                }).ToList();
            }
            else
            {
                throw new ArgumentException("非法输入");
            }
        }

        /// <summary>
        /// 旅程记录集合 
        /// </summary>
        public List<(int distance, int minute)> Journeys
        {
            get;
            private set;
        }
    }
}
