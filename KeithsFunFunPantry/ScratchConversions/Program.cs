using ScratchConversions.UnitConversions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScratchConversions
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Dry Conversion Tests");
            UnitConversion.DryConversionTest();

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Liquid Conversion Tests");
			UnitConversion.LiquidConversionTest();

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Metric Conversion Tests");
            UnitConversion.MetricConversionTest();
        }
    }
}
