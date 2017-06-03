using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeithsFunFunPantry.CS
{
    public class GenerateIngredients
    {
        Measurement measure;
        public GenerateIngredients()
        {
           measure = new Measurement(2f, Unit.Cup);

                new Ingredient("Salt", measure);
                new Ingredient("Ground Beef", measure);
                new Ingredient("Oil", measure);
            
        }

        public static ObservableCollection<Ingredient> Ingredients { get; set; }

    }
}
