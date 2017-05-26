using KeithsFunFunPantry.CS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ScratchConversions.UnitConversions
{
	public static class UnitConversion
	{
		public static void Convert(this Measurement original, Unit unit)
		{
            //Validation
                //Conversion
            float convertedAmount = Validation(original, unit);
            //Truncate the Amount measurement to three places

            //Change the original measurement
            original.Amount = convertedAmount;
            original.UnitOfMeasurement = unit;
        }

        private static float Validation(Measurement original, Unit targetUnit)
        {
            float convertedAmount = 0;

            //If the measurement is not already in the target unit
            if (original.UnitOfMeasurement != targetUnit)
            {
                /* Lists of units contained in each Conversion type
                 * IF both the target & source unit are within the List, continue into the if statement
                 *      then have the individual If statements for each of the conversion types
                 */
                List<Unit> dryUnits = new List<Unit>() { Unit.Teaspoon, Unit.Tablespoon, Unit.Cup, Unit.Ounce, Unit.Pound };
                List<Unit> liquidUnits = new List<Unit>() { Unit.Cup, Unit.FluidOunce, Unit.Pint, Unit.Quart, Unit.Gallon };
                List<Unit> metricUnits = new List<Unit>() { Unit.Cup, Unit.FluidOunce, Unit.Gallon, Unit.Gram, Unit.Kilogram, Unit.Liter, Unit.Milliliter, Unit.Ounce, Unit.Pint, Unit.Pound, Unit.Quart, Unit.Tablespoon, Unit.Teaspoon };

                float origAmt = original.Amount;
                //If the measurement can be translated into the target 
                if (dryUnits.Contains(original.UnitOfMeasurement) && dryUnits.Contains(targetUnit))
                {

                } else if (liquidUnits.Contains(original.UnitOfMeasurement) && liquidUnits.Contains(targetUnit))
                {

                } else if (metricUnits.Contains(original.UnitOfMeasurement) && metricUnits.Contains(targetUnit))
                {

                }
            }
            else
            //If the measurement's Unit already IS the target unit
            {
                MessageBox.Show("Source Unit and Target Unit are the same.");
            }

            return convertedAmount;
        }

        //Private methods for each conversion
        #region Dry
        private static float TablespoonToTeaspoon(float amount)
        {
            return (float)(amount * 3);
        }

        private static float CupToTeaspoon(float amount)
        {
            return (float)(amount * 48);
        }

        private static float OunceToTeaspoon(float amount)
        {
            return (float)(amount * 6);
        }

        private static float PoundToTeaspoon(float amount)
        {
            return (float)(amount * 96);
        }

        private static float TeaspoonToTablespoon(float amount)
        {
            return (float)(amount / 3);
        }

        private static float TeaspoonToCup(float amount)
        {
            return (float)(amount / 48);
        }

        private static float TeaspoonToOunce(float amount)
        {
            return (float)(amount / 6);
        }

        private static float TeaspoonToPound(float amount)
        {
            return (float)(amount / 96);
        }

        public static void DryConversionTest()
        {
            Console.WriteLine("Tablespoon to Teaspoon");
            Console.WriteLine(TablespoonToTeaspoon(12f) == 36f ? "\tpassed" : "\t*failed*");
            Console.WriteLine("Cup to Teaspoon");
            Console.WriteLine(CupToTeaspoon(5f) == 240f ? "\tpassed" : "\t*failed*");
            Console.WriteLine("Ounce to Teaspoon");
            Console.WriteLine(OunceToTeaspoon(16f) == 96f ? "\tpassed" : "\t*failed*");
            Console.WriteLine("Pound to Teaspoon");
            Console.WriteLine(PoundToTeaspoon(3f) == 288f ? "\tpassed" : "\t*failed*");
            Console.WriteLine("Teaspoon to Tablespoon");
            Console.WriteLine(TeaspoonToTablespoon(45f) == 15f ? "\tpassed" : "\t*failed*");
            Console.WriteLine("Teaspoon to Cup");
            Console.WriteLine(TeaspoonToCup(705f) == 14.6875f ? "\tpassed" : "\t*failed*");
            Console.WriteLine("Teaspoon to Ounce");
            Console.WriteLine(TeaspoonToOunce(120f) == 20f ? "\tpassed" : "\t*failed*");
            Console.WriteLine("Teaspoon to Pound");
            Console.WriteLine(TeaspoonToPound(330f) == 3.4375f ? "\tpassed" : "\t*failed*");
        }
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
			Console.WriteLine(FluidOuncesToCups(33f) == 4.125f ? "\tpassed" : "\t*failed*");
			Console.WriteLine("Pints to Cups");
			Console.WriteLine(PintsToCups(33f) == 66f ? "\tpassed" : "\t*failed*");
			Console.WriteLine("Quarts to Cups");
			Console.WriteLine(QuartsToCups(23f) == 92f ? "\tpassed" : "\t*failed*");
			Console.WriteLine("Gallons to Cups");
			Console.WriteLine(GallonsToCups(13f) == 208f ? "\tpassed" : "\t*failed*");
			Console.WriteLine("Cups to Fluid Ounces");
			Console.WriteLine(CupsToFluidOunces(13f) == 104f ? "\tpassed" : "\t*failed*");
			Console.WriteLine("Cups to Pints");
			Console.WriteLine(CupsToPints(23f) == 11.5f ? "\tpassed" : "\t*failed*");
			Console.WriteLine("Cups to Quarts");
			Console.WriteLine(CupsToQuarts(23f) == 5.75f ? "\tpassed" : "\t*failed*");
			Console.WriteLine("Cups to Gallons");
			Console.WriteLine(CupsToGallons(33f) == 2.0625f ? "\tpassed" : "\t*failed*");

		}
		#endregion

		#region Metric
        public static void MetricConversionTest()
        {

        }
		#endregion
	}
}
