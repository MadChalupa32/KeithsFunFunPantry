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


		private static float CupToTablespoon(float amount)
		{
			return TeaspoonToTablespoon(CupToTeaspoon(amount));
		}

		private static float OunceToTablespoon(float amount)
		{
			return TeaspoonToTablespoon(OunceToTeaspoon(amount));
		}

		private static float PoundToTablespoon(float amount)
		{
			return TeaspoonToTablespoon(PoundToTeaspoon(amount));
		}


		private static float TablespoonToCup(float amount)
		{
			return TeaspoonToCup(TablespoonToTeaspoon(amount));
		}

		private static float TablespoonToOunce(float amount)
		{
			return TeaspoonToOunce(TablespoonToTeaspoon(amount));
		}

		private static float TablespoonToPound(float amount)
		{
			return TeaspoonToPound(TablespoonToTeaspoon(amount));
		}


		private static float OunceToCup(float amount)
		{
			return TeaspoonToCup(OunceToTeaspoon(amount));
		}

		private static float PoundToCup(float amount)
		{
			return TeaspoonToCup(PoundToTeaspoon(amount));
		}


		private static float CupToOunce(float amount)
		{
			return TeaspoonToOunce(CupToTeaspoon(amount));
		}

		private static float CupToPound(float amount)
		{
			return TeaspoonToPound(CupToTeaspoon(amount));
		}


		private static float PoundToOunce(float amount)
		{
			return TeaspoonToOunce(PoundToTeaspoon(amount));
		}


		private static float OunceToPound(float amount)
		{
			return TeaspoonToPound(OunceToTeaspoon(amount));
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
			Console.WriteLine("Tablespoon to Cup");
			Console.WriteLine(TablespoonToCup(50f) == 3.125f ? "\tpassed" : "\t*failed*");
			Console.WriteLine("Tablespoon To Ounce");
			Console.WriteLine(TablespoonToOunce(1f) == 0.5f ? "\tpassed" : "\t*failed*");
			Console.WriteLine("Tablespoon to Pound");
			Console.WriteLine(TablespoonToPound(20f) == .625f ? "\tpassed" : "\t*failed*");
			Console.WriteLine("Ounce to Tablespoon");
			Console.WriteLine(OunceToTablespoon(20f) == 40f ? "\tpassed" : "\t*failed*");
			Console.WriteLine("Ounce To Pound");
			Console.WriteLine(OunceToPound(20f) == 1.25f ? "\tpassed" : "\t*failed*");
			Console.WriteLine("Ounce To Cup");
			Console.WriteLine(OunceToCup(20f) == 2.5f ? "\tpassed" : "\t*failed*");
			Console.WriteLine("Pound to Ounce");
			Console.WriteLine(PoundToOunce(20f) == 320f ? "\tpassed" : "\t*failed*");
			Console.WriteLine("Pound To Tablespoon");
			Console.WriteLine(PoundToTablespoon(20f) == 640f ? "\tpassed" : "\t*failed*");
			Console.WriteLine("Pound To Cup");
			Console.WriteLine(PoundToCup(20f) == 40f ? "\tpassed" : "\t*failed*");
			Console.WriteLine("Cup to Ounce");
			Console.WriteLine(CupToOunce(20f) == 160f ? "\tpassed" : "\t*failed*");
			Console.WriteLine("Cup To Pound");
			Console.WriteLine(CupToPound(20f) == 10f ? "\tpassed" : "\t*failed*");

		}
		#endregion

		#region Liquid
		private static float FluidOuncesToCups(float fluidOunceAmt)
		{
			float cupAmt = fluidOunceAmt / 8;
			return cupAmt;
		}
		private static float CupsToFluidOunces(float cupAmt)
		{
			float fluidOunceAmt = cupAmt * 8;
			return fluidOunceAmt;
		}
		private static float FluidOuncesToPints(float fluidOunceAmt)
		{
			float pintAmt = CupsToPints(FluidOuncesToCups(fluidOunceAmt));
			return pintAmt;
		}
		private static float FluidOuncesToQuarts(float fluidOunceAmt)
		{
			float quartAmt = CupsToFluidOunces(QuartsToCups(fluidOunceAmt));
			return quartAmt;
		}
		private static float FluidOuncesToGallons(float fluidOunceAmt)
		{
			float gallonAmt = CupsToFluidOunces(GallonsToCups(fluidOunceAmt));
			return gallonAmt;
		}


		private static float PintsToFluidOunces(float pintAmt)
		{
			float fluidOunceAmt = CupsToFluidOunces(PintsToCups(pintAmt));
			return fluidOunceAmt;
		}
		private static float PintsToCups(float pintAmt)
		{
			float cupAmt = pintAmt * 2;
			return cupAmt;
		}
		private static float CupsToPints(float cupAmt)
		{
			float pintAmt = cupAmt / 2;
			return pintAmt;
		}
		private static float PintsToQuarts(float pintAmt)
		{
			float quartAmt = CupsToQuarts(PintsToCups(pintAmt));
			return quartAmt;
		}
		private static float PintsToGallons(float pintAmt)
		{
			float gallonAmt = CupsToGallons(PintsToCups(pintAmt));
			return gallonAmt;
		}


		private static float QuartsToFluidOunces(float quartAmt)
		{
			float fluidOunceAmt = CupsToFluidOunces(QuartsToCups(quartAmt));
			return fluidOunceAmt;
		}
		private static float QuartsToCups(float quartAmt)
		{
			float cupAmt = quartAmt * 4;
			return cupAmt;
		}
		private static float CupsToQuarts(float cupAmt)
		{
			float quartAmt = cupAmt / 4;
			return quartAmt;
		}
		private static float QuartsToPints(float quartAmt)
		{
			float pintAmt = CupsToPints(QuartsToCups(quartAmt));
			return pintAmt;
		}
		private static float QuartsToGallons(float quartAmt)
		{
			float gallonAmt = CupsToGallons(QuartsToCups(quartAmt));
			return gallonAmt;
		}


		private static float GallonsToFluidOunces(float gallonAmt)
		{
			float fluidOunceAmt = CupsToFluidOunces(GallonsToCups(gallonAmt));
			return fluidOunceAmt;
		}
		private static float GallonsToCups(float gallonAmt)
		{
			float cupAmt = gallonAmt * 16;
			return cupAmt;
		}
		private static float CupsToGallons(float cupAmt)
		{
			float gallonAmt = cupAmt / 16;
			return gallonAmt;
		}
		private static float GallonsToPints(float gallonAmt)
		{
			float pintAmt = CupsToPints(GallonsToCups(gallonAmt));
			return pintAmt;
		}
		private static float GallonsToQuarts(float gallonAmt)
		{
			float quartAmt = CupsToQuarts(GallonsToCups(gallonAmt));
			return quartAmt;
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

		private static float TeaspoonToMilliliter(float amount)
		{
			return (float)(amount * 5);
		}

		private static float TableSpoonToMilliliter(float amount)
		{
			return (float)(amount * 15);
		}
		private static float FluidOunceToMilliliter(float amount)
		{
			return (float)(amount * 30);
		}
		private static float CupToMilliliter(float amount)
		{
			return (float)(amount * 240);
		}
		private static float PintToMilliliter(float amount)
		{
			return (float)(amount * 470);
		}

		private static float QuartToLiter(float amount)
		{
			return (float)(amount * .95);
		}
		private static float GallonToLiter(float amount)
		{
			return (float)(amount * 3.8);
		}

		private static float OunceToGram(float amount)
		{
			return (float)(amount * 28);
		}
		private static float PoundToGram(float amount)
		{
			return (float)(amount * 454);
		}
		private static float MilliliterToTeaspoon(float amount)
		{
			return (float)(amount * .2);
		}
		private static float MilliliterToTablespoon(float amount)
		{
			return (float)(amount * .067);
		}
		private static float MilliliterToOunce(float amount)
		{
			return (float)(amount * .033);
		}
		private static float MilliliterToCup(float amount)
		{
			return (float)(amount * .004);
		}
		private static float LiterToOunce(float amount)
		{
			return (float)(amount * 34);
		}
		private static float LiterToCup(float amount)
		{
			return (float)(amount * 4.2);
		}
		private static float LiterToPint(float amount)
		{
			return (float)(amount * 2.1);
		}
		private static float LiterToQuart(float amount)
		{
			return (float)(amount * 1.06);
		}
		private static float LiterToGallon(float amount)
		{
			return (float)(amount * .26);
		}
		private static float GramToOunce(float amount)
		{
			return (float)(amount * .035);
		}
		private static float GramToPound(float amount)
		{
			return (float)(amount * .002);
		}
		private static float KilogramToOunce(float amount)
		{
			return (float)(amount * 35);
		}
		private static float KilogramToPound(float amount)
		{
			return (float)(amount * 2.205);
		}
		private static float KilogramToGram(float amount)
		{
			return (float)(amount * 1000);
		}
        private static float CupToLiter(float amount)
		{
			return (float)(amount * .236);
		}
        private static float PintToLiter(float amount)
		{
			return (float)(amount * .473);
		}
        private static float QuartToLiter(float amount)
		{
			return (float)(amount * .946);
		}
        private static float GallonToLiter(float amount)
		{
			return (float)(amount * 3.78);
		}
        private static float GramToKilogram(float amount)
		{
			return (float)(amount * .001);
		}
        private static float OunceToKilogram(float amount)
		{
			return (float)(amount * .028);
		}
         private static float PoundToKilogram(float amount)
		{
			return (float)(amount * .453);
		}

		public static void MetricConversionTest()
		{
			Console.WriteLine("Kilogram To Gram");
			Console.WriteLine(KilogramToGram(1f) == 1000f ? "\tpassed" : "\t*failed*");
			Console.WriteLine("Teaspoon to Milliliter");
			Console.WriteLine(TeaspoonToMilliliter(5f) == 25f ? "\tpassed" : "\t*failed*");
			Console.WriteLine("Tablespoon to Milliliter");
			Console.WriteLine(TableSpoonToMilliliter(3f) == 45f ? "\tpassed" : "\t*failed*");
			Console.WriteLine("Fluid Ounce to Milliter");
			Console.WriteLine(FluidOunceToMilliliter(2f) == 60f ? "\tpassed" : "\t*failed*");
			Console.WriteLine("Cups to Milliliter");
			Console.WriteLine(CupToMilliliter(1f) == 240f ? "\tpassed" : "\t*failed*");
			Console.WriteLine("Pints to Milliliter");
			Console.WriteLine(PintToMilliliter(4f) == 1880 ? "\tpassed" : "\t*failed*");
			Console.WriteLine("Quarts to Liters");
			Console.WriteLine(QuartToLiter(70f) == 66.5f ? "\tpassed" : "\t*failed*");
			Console.WriteLine("Gallon to Liters");
			Console.WriteLine(GallonToLiter(6f) == 22.8f ? "\tpassed" : "\t*failed*");
			Console.WriteLine("Ounce to Grams");
			Console.WriteLine(OunceToGram(2f) == 56f ? "\tpassed" : "\t*failed*");
			Console.WriteLine("Pound to Grams");
			Console.WriteLine(PoundToGram(5f) == 2270f ? "\tpassed" : "\t*failed*");
			Console.WriteLine("Milliliter to Teaspoon");
			Console.WriteLine(MilliliterToTeaspoon(2f) == .4f ? "\tpassed" : "\t*failed*");
			Console.WriteLine("Milliliter to Tablespoon");
			Console.WriteLine(MilliliterToTablespoon(2f) == .134f ? "\tpassed" : "\t*failed*");
			Console.WriteLine("Milliliter to Ounce ");
			Console.WriteLine(MilliliterToOunce(2f) == .066f ? "\tpassed" : "\t*failed*");
			Console.WriteLine("Milliliter to Cup");
			Console.WriteLine(MilliliterToCup(4f) == .016f ? "\tpassed" : "\t*failed*");
			Console.WriteLine("Liters to Ounce");
			Console.WriteLine(LiterToOunce(10f) == 340f ? "\tpassed" : "\t*failed*");
			Console.WriteLine("Liter to Cup");
			Console.WriteLine(LiterToCup(6f) == 25.2f ? "\tpassed" : "\t*failed*");
			Console.WriteLine("Liter to Gallons");
			Console.WriteLine(LiterToGallon(2f) == .52f ? "\tpassed" : "\t*failed*");
			Console.WriteLine("Liter to Quarts");
			Console.WriteLine(LiterToQuart(3f) == 3.18f ? "\tpassed" : "\t*failed*");
			Console.WriteLine("Gram to Ounce");
			Console.WriteLine(GramToOunce(9f) == .315f ? "\tpassed" : "\t*failed*");
			Console.WriteLine("Gram to Pounds");
			Console.WriteLine(GramToPound(10f) == .02f ? "\tpassed" : "\t*failed*");
			Console.WriteLine("Kilogram to Ounce");
			Console.WriteLine(KilogramToOunce(6f) == 210f ? "\tpassed" : "\t*failed*");
			Console.WriteLine("Kilogram to Pounds");
			Console.WriteLine(KilogramToPound(9f) == 19.845f ? "\tpassed" : "\t*failed*");
            Console.WriteLine("Cup To Liter");
			Console.WriteLine(CupToLiter(1f) == .236f ? "\tpassed" : "\t*failed*");
            Console.WriteLine("Pint To Liter");
			Console.WriteLine(PintToLiter(1f) == .473f ? "\tpassed" : "\t*failed*");
            Console.WriteLine("Quart to Liter");
			Console.WriteLine(QuartToLiter(1f) == .946f ? "\tpassed" : "\t*failed*");
            Console.WriteLine("Gallon To Liter");
			Console.WriteLine(GallonToLiter(1f) == 3.78f ? "\tpassed" : "\t*failed*");
            Console.WriteLine("Ounce To Liter");
			Console.WriteLine(GallonToLiter(1f) == .029f ? "\tpassed" : "\t*failed*");
            Console.WriteLine("Gram To Kilogram");
			Console.WriteLine(GramToKilogram(1f) == .001f ? "\tpassed" : "\t*failed*");
            Console.WriteLine("Ounce To Kilogram");
			Console.WriteLine(OunceToKilogram(2f) == .906f ? "\tpassed" : "\t*failed*");

		}
		#endregion


		public static void validatestuffs(this measurement originalmeasure, unit targetunit)
		{
			dictionary<unit, dictionary<unit, func<float, float>>> conversions = new dictionary<unit, dictionary<unit, func<float, float>>>()
			{
				{
					//target unit is cup
					unit.cup,
					new dictionary<unit, func<float,float>>()
					{
						{ unit.fluidounce, fluidouncestocups },
						{ unit.pint, pintstocups },
						{ unit.quart, quartstocups },
						{ unit.gallon, gallonstocups },
						{ unit.teaspoon, teaspoontocup },
						{ unit.tablespoon, tablespoontocup },
						{ unit.ounce, ouncetocup },
						{ unit.pound, poundtocup },
						{ unit.liter, litertocup }
					}
				},
				{
					//target unit is fluid ounce
					unit.fluidounce,
					new dictionary<unit, func<float,float>>()
					{
						{ unit.cup, cupstofluidounces },
						{ unit.pint, pintstofluidounces },
						{ unit.quart, quartstofluidounces },
						{ unit.gallon, gallonstofluidounces }
					}
				},
				{
					//target unit is gallon
					unit.gallon,
					new dictionary<unit, func<float,float>>()
					{
						{ unit.fluidounce, fluidouncestogallons },
						{ unit.cup, cupstogallons },
						{ unit.pint, pintstogallons },
						{ unit.quart, quartstogallons }
					}
				},
				{
					//target unit is gram
					unit.gram,
					new dictionary<unit, func<float,float>>()
					{
						{ unit.kilogram, KilogramToGram },
						{ unit.ounce, OunceToGram },
						{ unit.pound, PoundToGram }
					}
				},
				{
					//target unit is kilogram
					unit.kilogram,
					new dictionary<unit, func<float,float>>()
					{
						{ unit.gram, GramToKilogram  },
						{ unit.ounce, OunceToKilogram },
						{ unit.pound, PoundToKilogram}
					}
				},
				{
					//target unit is liter
					unit.liter,
					new dictionary<unit, func<float,float>>()
					{
						{ unit.cup, CupToLiter },
						{ unit.pint, PintToLiter },
						{ unit.quart, QuartToLiter },
						{ unit.gallon, GallonToLiter},
						{ unit.ounce, OunceToLiter  }
					}
				},
				{
					//target unit is milliliter
					unit.milliliter,
					new dictionary<unit, func<float,float>>()
					{
						{ unit.cup, CupToMilliliter},
                        { unit.teaspoon, TeaspoonToMilliliter},
                        { unit.tablespoon, TableSpoonToMilliliter},
                        { unit.pint, PintToMilliliter},
                        { unit.cup, CupToMilliliter},
                        { unit.fluidounce, FluidOunceToMilliliter}
					}
				},
				{
					//target unit is ounce
					unit.ounce,
					new dictionary<unit, func<float,float>>()
					{
						{ unit.teaspoon, TeaspoonToOunce },
						{ unit.tablespoon, TablespoonToOunce },
						{ unit.cup, CupToOunce },
						{ unit.pound, PoundToOunce }
					}
				},
				{
					//target unit is pint
					unit.pint,
					new dictionary<unit, func<float,float>>()
					{
						{ unit.fluidounce, FluidOuncesToPints },
						{ unit.cup, CupsToPints },
						{ unit.quart, QuartsToPints },
						{ unit.gallon, GallonsToPints }
					}
				},
				{
					//target unit is pound
					unit.pound,
					new dictionary<unit, func<float,float>>()
					{
						{ unit.teaspoon, TeaspoonToPound },
						{ unit.tablespoon, TablespoonToPound },
						{ unit.cup, CupToPound },
						{ unit.ounce, OunceToPound }
					}
				},
				{
					//target unit is quart
					unit.quart,
					new dictionary<unit, func<float,float>>()
					{
						{ unit.fluidounce, FluidOuncesToQuarts },
						{ unit.cup, CupsToQuarts },
						{ unit.pint, PintsToQuarts },
						{ unit.gallon, GallonsToQuarts }
					}
				},
				{
					//target unit is tablespoon
					unit.tablespoon,
					new dictionary<unit, func<float,float>>()
					{
						{ unit.teaspoon, TablespoonToTeaspoon },
						{ unit.cup, CupToTablespoon },
						{ unit.ounce, OunceToTablespoon },
						{ unit.pound, PoundToTablespoon }
					}
				},
				{
					//target unit is teaspoon
					unit.teaspoon,
					new dictionary<unit, func<float,float>>()
					{
						{ unit.tablespoon, TablespoonToTeaspoon },
						{ unit.cup, CupToTeaspoon },
						{ unit.ounce, OunceToTeaspoon },
						{ unit.pound, PoundToTeaspoon }
					}
				}
			};

			conversions[unit.cup][unit.gallon].invoke(12);
		}
	}
}

