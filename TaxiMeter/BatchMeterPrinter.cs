using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TaxiMeter
{
    /// <summary>
    /// 集成计价打印
    /// </summary>
    public class BatchMeterPrinter
    {
        InputParse parse;

        public BatchMeterPrinter( string arg )
        {
            var testFile = string.Format("resources/{0}", arg);
            if ( File.Exists(testFile) )
            {
                var content = File.ReadAllText(testFile, Encoding.UTF8);
                this.parse = new InputParse(content);
            }
            else
            {
                throw new FileNotFoundException("can not find test data file:" + arg);    
            }
            
        }

        /// <summary>
        /// 打印计价
        /// </summary>
        /// <returns></returns>
        public string Print()
        {
            var retValue = this.parse.Journeys.Select(t => new FeeMeter(t.distance, t.minute).Calculate())
                           .Aggregate("", (a, b) => a + "收费" + b + "元\n");
            return retValue;
        }
    }
}
