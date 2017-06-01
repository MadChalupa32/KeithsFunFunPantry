using System;
using System.Collections.Generic;

namespace KeithsFunFunPantry.CS
{
    [Serializable]
    //singleton Unit class
    public class Unit
    {
        public string LongHand { get; private set; }
        public string ShortHand { get; private set; }

        public static Unit Teaspoon = new Unit()
        {
            LongHand = "Teaspoon",
            ShortHand = "tsp"
        };

        public static Unit Tablespoon = new Unit()
        {
            LongHand = "Tablespoon",
            ShortHand = "Tbsp"
        };

        public static Unit Cup = new Unit()
        {
            LongHand = "Cup",
            ShortHand = "c"
        };

        public static Unit Ounce = new Unit()
        {
            LongHand = "Ounce",
            ShortHand = "oz"
        };

        public static Unit FluidOunce = new Unit()
        {
            LongHand = "Fluid Ounce",
            ShortHand = "fl oz"
        };

        public static Unit Pound = new Unit()
        {
            LongHand = "Pound",
            ShortHand = "lb"
        };

        public static Unit Pint = new Unit()
        {
            LongHand = "Pint",
            ShortHand = "pt"
        };

        public static Unit Quart = new Unit()
        {
            LongHand = "Quart",
            ShortHand = "qt"
        };

        public static Unit Gallon = new Unit()
        {
            LongHand = "Gallon",
            ShortHand = "G"
        };

        public static Unit Milliliter = new Unit()
        {
            LongHand = "Milliliter",
            ShortHand = "ml"
        };

        public static Unit Liter = new Unit()
        {
            LongHand = "Liter",
            ShortHand = "l"
        };

        public static Unit Gram = new Unit()
        {
            LongHand = "Gram",
            ShortHand = "g"
        };

        public static Unit Kilogram = new Unit()
        {
            LongHand = "Kilogram",
            ShortHand = "kg"
        };

        public static Unit Count = new Unit()
        {
            LongHand = "Count",
            ShortHand = "Count"
        };

        public static Unit[] TotalUnits = { Teaspoon, Tablespoon, Cup, Ounce, FluidOunce, Pound, Pint, Quart, Gallon, Milliliter, Liter, Gram, Kilogram, Count };

        private Unit()
        {
        }

		public override bool Equals(object obj)
		{
			bool same = LongHand == (obj as Unit).LongHand;
			return same;
		}

        public override string ToString()
        {
            return LongHand;
        }
    }
}
