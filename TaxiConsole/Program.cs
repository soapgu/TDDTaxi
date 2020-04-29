using System;
using TaxiMeter;

namespace TaxiConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args != null && args.Length > 0)
            {
                var print = new BatchMeterPrinter(args[0]);
                Console.WriteLine(print.Print());
            }
            else
            {
                Console.WriteLine("invaild arg input!");
            }
            Console.ReadLine();
        }
    }
}
