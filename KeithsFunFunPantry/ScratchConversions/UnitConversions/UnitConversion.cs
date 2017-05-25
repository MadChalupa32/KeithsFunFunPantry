using KeithsFunFunPantry.CS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScratchConversions.UnitConversions
{
	public static class UnitConversion
	{
		public static void Convert(this Measurement original, Unit unit)
		{
			//Validation
			//If the measurement is not already in the target unit
			if(original.UnitOfMeasurement != unit)
			{
				//If the measurement can be translated into the target unit
				//switch (unit)
				//{
				//	case Unit.Count
				//	case Unit.Cup
				//	case Unit.FluidOunce
				//	case Unit.Gallon
				//	case Unit.Gram
				//	case Unit.Kilogram
				//	case Unit.Liter
				//	case Unit.Milliliter
				//	case Unit.Ounce
				//	case Unit.Pint
				//	case Unit.Pound
				//	case Unit.Quart
				//	case Unit.Tablespoon
				//	case Unit.Teaspoon
				//	case Unit.TotalUnits
				//	default
				//}

				//Conversion
				//Change the original measurement
			}
		}

		//Private methods for each conversion
		#region Dry

		#endregion
		#region Liquid
		private static float FluidOuncesToCups(float fluidOunceAmt)
		{
			float cupAmt = fluidOunceAmt / 8;
			return cupAmt;
		}
		private static float PintsToCups(float pintAmt)
		{
			float cupAmt = pintAmt * 2;
			return cupAmt;
		}
		private static float QuartsToCups(float quartAmt)
		{
			float cupAmt = quartAmt * 4;
			return cupAmt;
		}
		private static float GallonsToCups(float gallonAmt)
		{
			float cupAmt = gallonAmt * 16;
			return cupAmt;
		}
		private static float CupsToFluidOunces(float cupAmt)
		{
			float fluidOunceAmt = cupAmt * 8;
			return fluidOunceAmt;
		}
		private static float CupsToPints(float cupAmt)
		{
			float pintAmt = cupAmt / 2;
			return pintAmt;
		}
		private static float CupsToQuarts(float cupAmt)
		{
			float quartAmt = cupAmt / 4;
			return quartAmt;
		}
		private static float CupsToGallons(float cupAmt)
		{
			float gallonAmt = cupAmt / 16;
			return gallonAmt;
		}

		public static void LiquidConversionTest()
		{
			Console.WriteLine("Fluid Ounces to Cups");
			Console.WriteLine(FluidOuncesToCups(33f) == 4.125f ? "passed" : "*failed*");
			Console.WriteLine("Pints to Cups");
			Console.WriteLine(PintsToCups(33f) == 66f ? "passed" : "*failed*");
			Console.WriteLine("Quarts to Cups");
			Console.WriteLine(QuartsToCups(23f) == 92f ? "passed" : "*failed*");
			Console.WriteLine("Gallons to Cups");
			Console.WriteLine(GallonsToCups(13f) == 208f ? "passed" : "*failed*");
			Console.WriteLine("Cups to Fluid Ounces");
			Console.WriteLine(CupsToFluidOunces(13f) == 104f ? "passed" : "*failed*");
			Console.WriteLine("Cups to Pints");
			Console.WriteLine(CupsToPints(23f) == 11.5f ? "passed" : "*failed*");
			Console.WriteLine("Cups to Quarts");
			Console.WriteLine(CupsToQuarts(23f) == 5.75f ? "passed" : "*failed*");
			Console.WriteLine("Cups to Gallons");
			Console.WriteLine(CupsToGallons(33f) == 2.0625f ? "passed" : "*failed*");

		}
		#endregion
		#region Metric

		#endregion
	}
}
