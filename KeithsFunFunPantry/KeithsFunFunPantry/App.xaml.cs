using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace KeithsFunFunPantry
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {

            RecipeBook book = RecipeBook.Instance;
            MessageBox.Show(book.Recipes.Count.ToString());

            List<Ingredient> ingreds = new List<Ingredient> { new Ingredient("Turkey", new CS.Measurement(7, CS.Unit.Gallon)) };
            Recipe test = new Recipe(ingreds, "Turkeys");
            //book.Recipes.Add(test);
            MessageBox.Show(book.Recipes.Count.ToString());

        }
    }
}
