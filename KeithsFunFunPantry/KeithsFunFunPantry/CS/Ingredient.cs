using KeithsFunFunPantry.CS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeithsFunFunPantry
{
    [Serializable()]
    public class Ingredient
    {
        private string name = "";
        private Measurement ingredientMeasurement;

        //Name of the ingredient
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }

        public Measurement IngredientMeasurement
        {
            get { return ingredientMeasurement; }
            set { ingredientMeasurement = value; }
        }

        //Amount of ingredient currently in pantry
        public Ingredient(string name, Measurement m)
        {
            Name = name;
            IngredientMeasurement = m;
        }
    }
}
