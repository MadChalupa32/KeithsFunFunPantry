using KeithsFunFunPantry.CS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace KeithsFunFunPantry
{
    [Serializable()]
    public class Ingredient
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string name = "";
        private Measurement ingredientMeasurement;

        //Name of the ingredient
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                FieldChanged();
            }
        }

        //Measurement of the ingredient
        public Measurement IngredientMeasurement
        {
            get { return ingredientMeasurement; }
            set
            {
                ingredientMeasurement = value;
                FieldChanged();
            }
        }

        public Ingredient(string name, Measurement m)
        {
            Name = name;
            IngredientMeasurement = m;
        }

        public override string ToString()
        {
            return Name + " " + IngredientMeasurement;
        }

        protected void FieldChanged([CallerMemberName] string field = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(field));
            }
        }
    }
}
