using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScratchConversions.US_to_Metric
{
    public class TestingMetrics
    { 
        private static float TeaspoonToMilliliter(float amount)
        {
            return (float)(amount *5);
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
            return (float)(amount / .2);
        }
        private static float MilliliterToTablespoon(float amount)
        {
            return (float)(amount / 15);
        }
        private static float MilliliterToOunce(float amount)
        {
            return (float)(amount / 30);
        }
        private static float MilliliterToCup(float amount)
        {
            return (float)(amount / 240);
        }
        private static float LiterToOunce(float amount)
        {
            return (float)(amount / 34);
        }
        private static float LiterToCup(float amount)
        {
            return (float)(amount / 4.2);
        }
        private static float LiterToPint(float amount)
        {
            return (float)(amount / 2.1);
        }
        private static float LiterToQuarts(float amount)
        {
            return (float)(amount / 1.06);
        }
        private static float LiterToGallon(float amount)
        {
            return (float)(amount / .26);
        }
        private static float GramToOunce(float amount)
        {
            return (float)(amount / .035);
        }
        private static float GramToPound(float amount)
        {
            return (float)(amount / .002);
        }
        private static float KilogramToOunce(float amount)
        {
            return (float)(amount / 35);
        }
        private static float KilogramToPounds(float amount)
        {
            return (float)(amount / 2.205);
        }
    }
}
