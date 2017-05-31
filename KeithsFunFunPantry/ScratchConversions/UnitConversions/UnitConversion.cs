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
		private static Dictionary<Unit, Dictionary<Unit, Func<float, float>>> conversions = new Dictionary<Unit, Dictionary<Unit, Func<float, float>>>()
		{
			{
				//Target unit is Cup
				Unit.Cup,
				new Dictionary<Unit, Func<float,float>>()
				{
					{ Unit.FluidOunce, FluidOuncesToCups },
					{ Unit.Pint, PintsToCups },
					{ Unit.Quart, QuartsToCups },
					{ Unit.Gallon, GallonsToCups },
					{ Unit.Teaspoon, TeaspoonToCup },
					{ Unit.Tablespoon, TablespoonToCup },
					{ Unit.Ounce, OunceToCup },
					{ Unit.Pound, PoundToCup },
					{ Unit.Liter, LiterToCup }
				}
			},
			{
				//Target unit is Fluid Ounce
				Unit.FluidOunce,
				new Dictionary<Unit, Func<float,float>>()
				{
					{ Unit.Cup, CupsToFluidOunces },
					{ Unit.Pint, PintsToFluidOunces },
					{ Unit.Quart, QuartsToFluidOunces },
					{ Unit.Gallon, GallonsToFluidOunces }
				}
			},
			{
				//Target unit is Gallon
				Unit.Gallon,
				new Dictionary<Unit, Func<float,float>>()
				{
					{ Unit.FluidOunce, FluidOuncesToGallons },
					{ Unit.Cup, CupsToGallons },
					{ Unit.Pint, PintsToGallons },
					{ Unit.Quart, QuartsToGallons }
				}
			},
			{
				//Target unit is Gram
				Unit.Gram,
				new Dictionary<Unit, Func<float,float>>()
				{
					{ Unit.Kilogram, KilogramToGram },
					{ Unit.Ounce, OunceToGram },
					{ Unit.Pound, PoundToGram }
				}
			},
			{
				//Target unit is Kilogram
				Unit.Kilogram,
				new Dictionary<Unit, Func<float,float>>()
				{
					{ Unit.Gram, GramToKilogram },
					{ Unit.Ounce, OunceToKilogram  },
					{ Unit.Pound, PoundToKilogram}
				}
			},
			{
				//Target unit is Liter
				Unit.Liter,
				new Dictionary<Unit, Func<float,float>>()
				{
					{ Unit.Cup, CupToLiter},
					{ Unit.Pint, PintToLiter },
				    { Unit.Quart, QuartToLiter },
					{ Unit.Gallon, GallonToLiter  }
					
				}
			},
			{
				//Target unit is Milliliter
				Unit.Milliliter,
				new Dictionary<Unit, Func<float,float>>()
				{
					{ Unit.Cup, CupToMilliliter},
                        { Unit.Tablespoon, TableSpoonToMilliliter},
                        { Unit.FluidOunce, FluidOunceToMilliliter},
                        { Unit.Teaspoon, TeaspoonToMilliliter},
                        { Unit.Pint, PintToMilliliter}
				}
			},
			{
				//Target unit is Ounce
				Unit.Ounce,
				new Dictionary<Unit, Func<float,float>>()
				{
					{ Unit.Teaspoon, TeaspoonToOunce },
					{ Unit.Tablespoon, TablespoonToOunce },
					{ Unit.Cup, CupToOunce },
					{ Unit.Pound, PoundToOunce }
				}
			},
			{
				//Target unit is Pint
				Unit.Pint,
				new Dictionary<Unit, Func<float,float>>()
				{
					{ Unit.FluidOunce, FluidOuncesToPints },
					{ Unit.Cup, CupsToPints },
					{ Unit.Quart, QuartsToPints },
					{ Unit.Gallon, GallonsToPints }
				}
			},
			{
				//Target unit is Pound
				Unit.Pound,
				new Dictionary<Unit, Func<float,float>>()
				{
					{ Unit.Teaspoon, TeaspoonToPound },
					{ Unit.Tablespoon, TablespoonToPound },
					{ Unit.Cup, CupToPound },
					{ Unit.Ounce, OunceToPound }
				}
			},
			{
				//Target unit is Quart
				Unit.Quart,
				new Dictionary<Unit, Func<float,float>>()
				{
					{ Unit.FluidOunce, FluidOuncesToQuarts },
					{ Unit.Cup, CupsToQuarts },
					{ Unit.Pint, PintsToQuarts },
					{ Unit.Gallon, GallonsToQuarts }
				}
			},
			{
				//Target unit is Tablespoon
				Unit.Tablespoon,
				new Dictionary<Unit, Func<float,float>>()
				{
					{ Unit.Teaspoon, TeaspoonToTablespoon },
					{ Unit.Cup, CupToTablespoon },
					{ Unit.Ounce, OunceToTablespoon },
					{ Unit.Pound, PoundToTablespoon }
				}
			},
			{
				//Target unit is Teaspoon
				Unit.Teaspoon,
				new Dictionary<Unit, Func<float,float>>()
				{
					{ Unit.Tablespoon, TablespoonToTeaspoon },
					{ Unit.Cup, CupToTeaspoon },
					{ Unit.Ounce, OunceToTeaspoon },
					{ Unit.Pound, PoundToTeaspoon }
				}
			}
		};

		public static void Convert(this Measurement original, Unit targetUnit)
		{
			//Validation & Conversion
			try
			{
				if (original.UnitOfMeasurement == targetUnit)
					throw new ArgumentException("The units are the same!");

				//Attempt to convert the measurement into the target unit
				float convertedAmount = conversions[targetUnit][original.UnitOfMeasurement].Invoke(original.Amount);

				//Truncate the Amount measurement to three places
				convertedAmount = (float)Math.Truncate(convertedAmount);
				//Change original measurement
				original.Amount = convertedAmount;
				original.UnitOfMeasurement = targetUnit;

			}
			catch (KeyNotFoundException)
			{
				//Catches failure cases where the units are not compatible
				Console.WriteLine("Cannot convert " + original.UnitOfMeasurement + " to " + targetUnit + " because the conversion is invalid.");
			}
			catch (ArgumentException)
			{
				//Catches the failure cases where the units are the same
				Console.WriteLine("The measurement unit and the target unit are the same: \'" + targetUnit + "\'.");
			}
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
         private static float OunceToLiter(float amount)
		{
		   	return (float)(amount * .029);
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
            Console.WriteLine("Gram To Kilogram");
			Console.WriteLine(GramToKilogram(1f) == .001f ? "\tpassed" : "\t*failed*");
            Console.WriteLine("Ounce To Kilogram");
			Console.WriteLine(OunceToKilogram(2f) == .906f ? "\tpassed" : "\t*failed*");
            Console.WriteLine("Ounce To Liter");
			Console.WriteLine(OunceToKilogram(2f) == .058f ? "\tpassed" : "\t*failed*");

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
						{ Unit.FluidOunce, FluidOuncesToCups },
						{ Unit.Pint, PintsToCups },
						{ Unit.Quart, QuartsToCups },
						{ Unit.Gallon, GallonsToCups },
						{ Unit.Teaspoon, TeaspoonToCup },
						{ Unit.Tablespoon, TablespoonToCup },
						{ Unit.Ounce, OunceToCup },
						{ Unit.Pound, PoundToCup },
						{ Unit.Liter, LiterToCup }
					}
				},
				{
					//Target unit is Fluid Ounce
					Unit.FluidOunce,
					new Dictionary<Unit, Func<float,float>>()
					{
						{ Unit.Cup, CupsToFluidOunces },
						{ Unit.Pint, PintsToFluidOunces },
						{ Unit.Quart, QuartsToFluidOunces },
						{ Unit.Gallon, GallonsToFluidOunces }
					}
				},
				{
					//Target unit is Gallon
					Unit.Gallon,
					new Dictionary<Unit, Func<float,float>>()
					{
						{ Unit.FluidOunce, FluidOuncesToGallons },
						{ Unit.Cup, CupsToGallons },
						{ Unit.Pint, PintsToGallons },
						{ Unit.Quart, QuartsToGallons }
					}
				},
				{
					//Target unit is Gram
					Unit.Gram,
					new Dictionary<Unit, Func<float,float>>()
					{
						{ Unit.Kilogram, KilogramToGram },
						{ Unit.Ounce, OunceToGrams },
						{ Unit.Pound, PoundToGrams }
					}
				},
				{
					//Target unit is Kilogram
					Unit.Kilogram,
					new Dictionary<Unit, Func<float,float>>()
					{
						{ Unit.Gram, GramToKilogram },
						{ Unit.Ounce, OunceToKilogram  },
						{ Unit.Pound, PoundToKilogram}
					}
				},
				{
					//Target unit is Liter
					Unit.Liter,
					new Dictionary<Unit, Func<float,float>>()
					{
						{ Unit.Cup, CupToLiter},
						{ Unit.Pint, PintToLiter  },
						{ Unit.Quart, QuartToLiter  },
						{ Unit.Gallon, GallonToLiter },
						{ Unit.Ounce, OunceToLiter }
					}
				},
				{
					//Target unit is Milliliter
					Unit.Milliliter,
					new Dictionary<Unit, Func<float,float>>()
					{
						{ Unit.Cup, CupToMilliliter},
                        { Unit.Tablespoon, TableSpoonToMilliliter},
                        { Unit.FluidOunce, FluidOunceToMilliliter},
                        { Unit.Teaspoon, TeaspoonToMilliliter},
                        { Unit.Pint, PintToMilliliter}
					}
				},
				{
					//Target unit is Ounce
					Unit.Ounce,
					new Dictionary<Unit, Func<float,float>>()
					{
						{ Unit.Teaspoon, TeaspoonToOunce },
						{ Unit.Tablespoon, TablespoonToOunce },
						{ Unit.Cup, CupToOunce },
						{ Unit.Pound, PoundToOunce }
					}
				},
				{
					//Target unit is Pint
					Unit.Pint,
					new Dictionary<Unit, Func<float,float>>()
					{
						{ Unit.FluidOunce, FluidOuncesToPints },
						{ Unit.Cup, CupsToPints },
						{ Unit.Quart, QuartsToPints },
						{ Unit.Gallon, GallonsToPints }
					}
				},
				{
					//Target unit is Pound
					Unit.Pound,
					new Dictionary<Unit, Func<float,float>>()
					{
						{ Unit.Teaspoon, TeaspoonToPound },
						{ Unit.Tablespoon, TablespoonToPound },
						{ Unit.Cup, CupToPound },
						{ Unit.Ounce, OunceToPound }
					}
				},
				{
					//Target unit is Quart
					Unit.Quart,
					new Dictionary<Unit, Func<float,float>>()
					{
						{ Unit.FluidOunce, FluidOuncesToQuarts },
						{ Unit.Cup, CupsToQuarts },
						{ Unit.Pint, PintsToQuarts },
						{ Unit.Gallon, GallonsToQuarts }
					}
				},
				{
					//Target unit is Tablespoon
					Unit.Tablespoon,
					new Dictionary<Unit, Func<float,float>>()
					{
						{ Unit.Teaspoon, TeaspoonToTablespoon },
						{ Unit.Cup, CupToTablespoon },
						{ Unit.Ounce, OunceToTablespoon },
						{ Unit.Pound, PoundToTablespoon }
					}
				},
				{
					//Target unit is Teaspoon
					Unit.Teaspoon,
					new Dictionary<Unit, Func<float,float>>()
					{
						{ Unit.Tablespoon, TablespoonToTeaspoon },
						{ Unit.Cup, CupToTeaspoon },
						{ Unit.Ounce, OunceToTeaspoon },
						{ Unit.Pound, PoundToTeaspoon }
					}
				}
			};
			conversions[Unit.Cup][Unit.Gallon].Invoke(12);
		}
	}
}

