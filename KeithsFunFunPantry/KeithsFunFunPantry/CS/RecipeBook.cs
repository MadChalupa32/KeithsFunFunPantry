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
    public class RecipeBook
    {
        private static RecipeBook instance;

        public static RecipeBook Instance
        {
            get
            {
                if (instance == null)
                {
                    using (var file = File.Open("RecipeBook.txt", FileMode.OpenOrCreate))
                    {
                        try
                        {
                            var recipesInTheFile = format.Deserialize(file) as RecipeBook;
                            if (recipesInTheFile != null)
                            {
                                instance = recipesInTheFile;
                            }
                            else
                            {
                                instance = new RecipeBook();
                            }

                        }
                        catch (SerializationException e)
                        {
                            instance = new RecipeBook();
                            //MessageBox.Show("Failed to load or create the Recipebook!\n" + e.ToString());
                        }
                    };


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
                    };
                }
            }
            catch ( Exception e) 
                {
                MessageBox.Show(e.ToString());
            } 
        }


		#region Search Function

		//Controls recipe-specific search function
		public void RecipeSearchController(string query/*, List<string> checkBoxValuesToFilter*/)
		{
			List<Recipe> nameSearchResults = RecipeNameSearch(query);

			//Leave until check box search is ready to be implemented
			//List<Recipe> finalSearchResults = RecipeCheckBoxFilter(nameSearchResults, checkBoxValuesToFilter);
		}

		//Executes name search and returns the results
		public List<Recipe> RecipeNameSearch(string query)
		{
			List<Recipe> queryResults = (List<Recipe>)recipes.Where(recipe => recipe.Title.ToLower().Contains(query));

			return queryResults;
		}

		//See checkbox filtering in Pantry class for checkBoxFiltering

		#endregion
	}
}
