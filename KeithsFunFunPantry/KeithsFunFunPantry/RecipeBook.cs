using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeithsFunFunPantry
{
    public static class RecipeBook
    {
        IFormatter format = new BinaryFormatter();
        private List<Recipe> recipes;

        public List<Recipe> Recipes
        {
            get { return recipes; }
            set { recipes = value; }
        }



        public static void LoadRecipes()
        {

            using(var file = File.Open("recipeBook.txt", FileMode.OpenOrCreate))
            {
                var recipesInTheFile = format.Deserialize(file);
                foreach(var recipe in (Recipes) recipesInTheFile)
                {
                    Recipes.Add(recipe);
                }
            };
        }

        public static void SaveRecipes()
        {
            
            //MessageBox.Show("gonna save");
            using (FileStream file = File.Open("recipeBook.txt", FileMode.OpenOrCreate))
            {
                format.Serialize(file, Recipes);
            };
        }
    }
}
