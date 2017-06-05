using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KeithsFunFunPantry.CS
{
    public class GenerateIngredients
    {
        private ObservableCollection<Ingredient> ingredients;
        Measurement measure;
        Measurement measure1;
        Measurement measure2;
        Measurement measure3;
        public GenerateIngredients()
        {

        }
        public void Gen()
        {
            measure = new Measurement(2f, Unit.Cup);
            measure1 = new Measurement(3f, Unit.Pound);
            measure2 = new Measurement(4f, Unit.Tablespoon);
            measure3 = new Measurement(5f, Unit.Count);
            ingredients = new ObservableCollection<Ingredient>();

            ingredients.Add(new Ingredient("Salt", measure));
            ingredients.Add(new Ingredient("Beef", measure1));
            ingredients.Add(new Ingredient("Oil", measure2));
            ingredients.Add(new Ingredient("Egg", measure3));

            foreach (Ingredient ingredient in ingredients)
            {
                bool doesntExist = true;
                foreach(Ingredient existing in Pantry.Ingredients)
                {
                    if (existing.Name == ingredient.Name)
                    {
                        doesntExist = false;
                    }
                }
                if (doesntExist)
                {
                    Pantry.Ingredients.Add(ingredient);
                }
            }
        }
        public ObservableCollection<Ingredient> Ingredients { get; set; }

    }
}
