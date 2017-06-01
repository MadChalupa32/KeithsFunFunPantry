using KeithsFunFunPantry.CS;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
                bool genRecipes = false;
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
                                Logging.WriteLog(LogLevel.Info, "RecipeBook successfully loaded from the saved file");
                            }
                            else
                            {
                                instance = new RecipeBook();
                                Logging.WriteLog(LogLevel.Warning, "New RecipeBook created due deserialized file not registering as a RecipeBook");
                                genRecipes = true;
                            }

                        }
                        catch (SerializationException)
                        {

                            instance = new RecipeBook();
                            Logging.WriteLog(LogLevel.Info, "New RecipeBook created due to serialization error.");
                            genRecipes = true;
                            //MessageBox.Show("Failed to load or create the Recipebook!\n" + e.ToString());
                        }
                    };


                }
                if (genRecipes)
                {
                    GenRecipes();
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


        private static void GenRecipes()
        {
            CS.Measurement measure = new CS.Measurement(5, CS.Unit.Count);
            List<Ingredient> testList = new List<Ingredient> { new Ingredient("fish", measure), new Ingredient("fish", measure) };
            List<Ingredient> testList2 = new List<Ingredient> { new Ingredient("notfish", measure), new Ingredient("nptfish", measure) };
            Recipe r1 = new Recipe(testList, "fish");
            Recipe r2 = new Recipe(testList2, "notfish");
            Instance.Recipes.Add(r1);
            Instance.Recipes.Add(r2);
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
                        Logging.WriteLog(LogLevel.Info, "RecipeBook Succesfully saved.");
                    };
                }
            }
            catch ( Exception e) 
                {
                Logging.WriteLog(LogLevel.Error, "RecipeBook Failed to save properly error follows:\n" + e.ToString());
            } 
        }


		#region Search Function

		//Controls recipe-specific search function
		public List<Recipe> RecipeSearchController(string query/*, List<string> checkBoxValuesToFilter*/)
		{
			List<Recipe> nameSearchResults = RecipeNameSearch(query);
            return nameSearchResults;
			//Leave until check box search is ready to be implemented
			//List<Recipe> finalSearchResults = RecipeCheckBoxFilter(nameSearchResults, checkBoxValuesToFilter);
		}

		//Executes name search and returns the results
		public List<Recipe> RecipeNameSearch(string query)
		{
			List<Recipe> queryResults = recipes.Where(recipe => recipe.Title.ToLower().Contains(query)).ToList();

			return queryResults;
		}

		//See checkbox filtering in Pantry class for checkBoxFiltering

		#endregion
	}
}
