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

		private static float OunceToGrams(float amount)
		{
			return (float)(amount * 28);
		}
		private static float PoundToGrams(float amount)
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
		private static float LiterToQuarts(float amount)
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
		private static float KilogramToPounds(float amount)
		{
			return (float)(amount * 2.205);
		}
		public static void MetricConversionTest()
		{
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
			Console.WriteLine(OunceToGrams(2f) == 56f ? "\tpassed" : "\t*failed*");
			Console.WriteLine("Pound to Grams");
			Console.WriteLine(PoundToGrams(5f) == 2270f ? "\tpassed" : "\t*failed*");
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
			Console.WriteLine(LiterToQuarts(3f) == 3.18f ? "\tpassed" : "\t*failed*");
			Console.WriteLine("Gram to Ounce");
			Console.WriteLine(GramToOunce(9f) == .315f ? "\tpassed" : "\t*failed*");
			Console.WriteLine("Gram to Pounds");
			Console.WriteLine(GramToPound(10f) == .02f ? "\tpassed" : "\t*failed*");
			Console.WriteLine("Kilogram to Ounce");
			Console.WriteLine(KilogramToOunce(6f) == 210f ? "\tpassed" : "\t*failed*");
			Console.WriteLine("Kilogram to Pounds");
			Console.WriteLine(KilogramToPounds(9f) == 19.845f ? "\tpassed" : "\t*failed*");
		}
		#endregion


		public static void ValidateStuffs(this Measurement originalMeasure, Unit targetUnit)
		{
			Dictionary<Unit, Dictionary<Unit, Func<float, float>>> conversions = new Dictionary<Unit, Dictionary<Unit, Func<float, float>>>()
			{
				{
					//Target unit is Cup
					Unit.Cup,
					new Dictionary<Unit, Func<float,float>>()
					{
						//Original measure is in Fluid Ounces
						{ Unit.FluidOunce, FluidOuncesToCups },
						//Original measure is in Pints
						{ Unit.Pint, PintsToCups },
						//Original measure is in Quarts
						{ Unit.Quart, QuartsToCups },
						//Original measure is in Gallons
						{ Unit.Gallon, GallonsToCups },
						//Original measure is in Teaspoon
						{ Unit.Teaspoon, TeaspoonToCup }
					}
				},
				{
					//Target unit is Fluid Ounce
					Unit.FluidOunce,
					new Dictionary<Unit, Func<float,float>>()
					{
						{ Unit.Cup, CupsToFluidOunces },
						{ Unit.Pint, (origAmt)=>{ float retVal = CupsToFluidOunces(PintsToCups(origAmt)); return retVal; } }
					}
				},
				{
					//Target unit is Gallon
					Unit.Gallon,
					new Dictionary<Unit, Func<float,float>>()
					{
						{ Unit,  }
					}
				},
				{
					//Target unit is Gram
					Unit.Gram,
					new Dictionary<Unit, Func<float,float>>()
					{
						{ Unit,  }
					}
				},
				{
					//Target unit is Kilogram
					Unit.Kilogram,
					new Dictionary<Unit, Func<float,float>>()
					{
						{ Unit,  }
					}
				},
				{
					//Target unit is Liter
					Unit.Liter,
					new Dictionary<Unit, Func<float,float>>()
					{
						{ Unit,  }
					}
				},
				{
					//Target unit is Milliliter
					Unit.Milliliter,
					new Dictionary<Unit, Func<float,float>>()
					{
						{ Unit,  }
					}
				},
				{
					//Target unit is Ounce
					Unit.Ounce,
					new Dictionary<Unit, Func<float,float>>()
					{
						{ Unit,  }
					}
				},
				{
					//Target unit is Pint
					Unit.Pint,
					new Dictionary<Unit, Func<float,float>>()
					{
						{ Unit,  }
					}
				},
				{
					//Target unit is Pound
					Unit.Pound,
					new Dictionary<Unit, Func<float,float>>()
					{
						{ Unit,  }
					}
				},
				{
					//Target unit is Quart
					Unit.Quart,
					new Dictionary<Unit, Func<float,float>>()
					{
						{ Unit,  }
					}
				},
				{
					//Target unit is Tablespoon
					Unit.Tablespoon,
					new Dictionary<Unit, Func<float,float>>()
					{
						{ Unit,  }
					}
				},
				{
					//Target unit is Teaspoon
					Unit.Teaspoon,
					new Dictionary<Unit, Func<float,float>>()
					{
						{ Unit,  }
					}
				}
			};
			
		}
	}
}
