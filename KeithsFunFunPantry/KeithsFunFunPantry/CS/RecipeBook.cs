using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KeithsFunFunPantry
{
    
    //find way to serialize the RecipeBook, potentially inhereting a List<Recipe>       SINGLETON
    [Serializable]
    public class RecipeBook : List<Recipe>
    {
        private static RecipeBook instance;
        private RecipeBook()
        {
            using (var file = File.Open("recipeBook.txt", FileMode.OpenOrCreate))
            {
                try
                {
                    var recipesInTheFile = format.Deserialize(file);
                    if (recipesInTheFile != null)
                    {
                        instance = (RecipeBook)recipesInTheFile;
                        Recipes = instance.Recipes;
                    }
                }
                catch (SerializationException e)
                {

                }
            };
        }
        public static RecipeBook Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new RecipeBook();
                }
                return instance;
            }
        }
        static IFormatter format = new BinaryFormatter();
        private List<Recipe> recipes = new List<Recipe>();

        public List<Recipe> Recipes
        {
            get { return recipes; }
            set { recipes = value; }
        }

        

        public void SaveRecipes()
        {
            try
            {
                if (Instance != null)
                {
                    using (FileStream file = File.Open("recipeBook.txt", FileMode.OpenOrCreate))
                    {
                        format.Serialize(file, Instance);
                        file.Close();
                    };

                }
                
            }
            catch ( Exception e) 
                {
                MessageBox.Show(e.ToString());
                } 

        }
    }
}
