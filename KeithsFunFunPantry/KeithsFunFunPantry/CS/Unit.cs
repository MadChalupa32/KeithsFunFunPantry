using System;

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
            LongHand = "teaspoon",
            ShortHand = "tsp"
        };

        public static Unit Tablespoon = new Unit()
        {
            LongHand = "tablespoon",
            ShortHand = "Tbsp"
        };

        public static Unit Cup = new Unit()
        {
            LongHand = "cup",
            ShortHand = "c"
        };

        public static Unit Ounce = new Unit()
        {
            LongHand = "ounce",
            ShortHand = "oz"
        };

        public static Unit FluidOunce = new Unit()
        {
            LongHand = "fluid ounce",
            ShortHand = "fl oz"
        };

        public static Unit Pound = new Unit()
        {
            LongHand = "pound",
            ShortHand = "lb"
        };

        public static Unit Pint = new Unit()
        {
            LongHand = "pint",
            ShortHand = "pt"
        };

        public static Unit Quart = new Unit()
        {
            LongHand = "quart",
            ShortHand = "qt"
        };

        public static Unit Gallon = new Unit()
        {
            LongHand = "gallon",
            ShortHand = "G"
        };

        public static Unit Milliliter = new Unit()
        {
            LongHand = "milliliter",
            ShortHand = "ml"
        };

        public static Unit Liter = new Unit()
        {
            LongHand = "liter",
            ShortHand = "l"
        };

        public static Unit Gram = new Unit()
        {
            LongHand = "gram",
            ShortHand = "g"
        };

        public static Unit Kilogram = new Unit()
        {
            LongHand = "kilogram",
            ShortHand = "kg"
        };

        public static Unit Count = new Unit()
        {
            LongHand = "count",
            ShortHand = "count"
        };

        private Unit()
        {

        }
    }
}
