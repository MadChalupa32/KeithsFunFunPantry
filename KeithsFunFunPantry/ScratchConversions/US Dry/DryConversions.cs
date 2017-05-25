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
     * cup              1 c. = 16 Tbsp
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
    }
}
