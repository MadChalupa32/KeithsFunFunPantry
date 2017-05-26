using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScratchConversions.US_Dry
{
    /*
     * Base Unit is teaspoons
     * 
     * NEED TO HANDLE OUTPUTING THE FINAL CONVERTED AMOUNT INTO A FRACTIONAL NUMBER
     * 
     * Start Unit -> Base
     * Base -> End Unit
     * 
     * private method   StartUnitToEndUnit(amount)
     *          return the converted amount
     *          
     * Dry Units:
     * teaspoon
     * tablespoon       1 Tbsp = 3 tsp
     * cup              1 c. = 16 Tbsp = 48 tsp
     * ounce            1 oz = 2 Tbsp = 6 tsp
     * pound            1 lb = 16 oz = 96 tsp
     * 
     * VALIDATION: ! ! ! IF THE UNITS ARE THE SAME, JUST DO THE MATH
     *          MAKE SURE TO RETURN A WARNING/MESSAGE IF THE UNITS ARE INCOMPATIBLE FOR CONVERSION
     *          
     *    INT CONTROLLER CLASS, CONVERT, TRUNCATE, CHANGE ASSOCIATED MEASUREMENT INSTANCE
     */

    public class DryConversions
    {
        //To Teaspoons
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

        //From Teaspoons
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

        //To Tablespoons
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

        //From Tablespoons
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

        //To Cups
        private static float OunceToCup(float amount)
        {
            return TeaspoonToCup(OunceToTeaspoon(amount));
        }

        private static float PoundToCup(float amount)
        {
            return TeaspoonToCup(PoundToTeaspoon(amount));
        }

        //From Cups
        private static float CupToOunce(float amount)
        {
            return TeaspoonToOunce(CupToTeaspoon(amount));
        }

        private static float CupToPound(float amount)
        {
            return TeaspoonToPound(CupToTeaspoon(amount));
        }

        //To Ounces
        private static float PoundToOunce(float amount)
        {
            return TeaspoonToOunce(PoundToTeaspoon(amount));
        }

        //From Ounces
        private static float OunceToPound(float amount)
        {
            return TeaspoonToPound(OunceToTeaspoon(amount));
        }
    }
}
