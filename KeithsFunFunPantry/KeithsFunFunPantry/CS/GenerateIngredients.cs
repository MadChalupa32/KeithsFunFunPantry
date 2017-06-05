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
        public GenerateIngredients()
        {

        }
        public void Gen()
        {
            measure = new Measurement(2f, Unit.Cup);
            ingredients = new ObservableCollection<Ingredient>();

            ingredients.Add(new Ingredient("Salt", measure));
            ingredients.Add(new Ingredient("Beef", measure));
            ingredients.Add(new Ingredient("Oil", measure));
            foreach(Ingredient ingredient in ingredients)
            {
                Pantry.Ingredients.Add(ingredient);
            }
        }
        public ObservableCollection<Ingredient> Ingredients { get; set; }

    }
}
