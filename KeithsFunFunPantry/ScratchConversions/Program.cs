using KeithsFunFunPantry.CS;
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
			//Console.WriteLine("\tDry Conversion Tests");
			//UnitConversion.DryConversionTest();

			//Console.WriteLine();
			//Console.WriteLine();

			//Console.WriteLine("\tLiquid Conversion Tests");
			//UnitConversion.LiquidConversionTest();

			//Console.WriteLine();
			//Console.WriteLine();

			//Console.WriteLine("\tMetric Conversion Tests");

			//Console.WriteLine("Metric Conversion Tests");
			//UnitConversion.MetricConversionTest();

			//Console.ReadLine();

			Measurement m = new Measurement(1f, Unit.Gallon);
			m.Convert(Unit.Gallon);
			Console.WriteLine(m.ToString());
        }
    }
}
