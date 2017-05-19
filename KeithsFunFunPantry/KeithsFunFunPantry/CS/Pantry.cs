using KeithsFunFunPantry.CS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace KeithsFunFunPantry
{
    [Serializable()]
    public static class Pantry
    {
        //public event PropertyChangedEventHandler PropertyChanged;
        private static List<Ingredient> ingredients = new List<Ingredient>();
        public static List<Ingredient> Ingredients
        {
            get { return ingredients; }
            set
            {
                ingredients = value;
            }
        }
        public static void AddNewIngredient(string name, Measurement m)
        {
            Ingredient i = new Ingredient(name, m);
            Ingredients.Add(i);
        }

        //Will export to file.
        public static void SaveIngredient()
        {
            try
            {
                using (Stream stream = File.Open("ingredients.xml", FileMode.CreateNew))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, Ingredients);
                }
            }
            catch (IOException)
            {
                Console.WriteLine("File has failed to open");
            }
        }
        //Will import all ingredients from file to list
        public static void ReadIngredientsFromFile()
        {
            try
            {
                using (Stream stream = File.Open("ingredients.xml", FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    var ingredient = (List<Ingredient>)bin.Deserialize(stream);
                    var sortedIngredients = ingredient.OrderBy(a => a.Name);
                    ingredients.Clear();
                    foreach(Ingredient ingredient1 in sortedIngredients)
                    {
                        ingredients.Add(ingredient1);
                    }
                }
            }
            catch (IOException)
            {
                Console.WriteLine("File has failed to open or doesn't exist");
            }
        }
        public static void RemoveIngredients()
        {
            //Ingredients.Remove();
        }


		#region Search Function

		//Controls ingredient-specific search function
		public static void IngredientSearchController(string query/*, List<string> checkBoxValuesToFilter*/)
		{
			List<Ingredient> nameSearchResults = IngredientNameSearch(query);

			//Leave until check box search is ready to be implemented
			//List<Ingredient> finalSearchResults = IngredientCheckBoxFilter(nameSearchResults, checkBoxValuesToFilter);
		}

		//Executes name search and returns the results
		public static List<Ingredient> IngredientNameSearch(string query)
		{
			List<Ingredient> queryResults = (List<Ingredient>)Ingredients.Where(ingredient => ingredient.Name.ToLower().Contains(query));

			return queryResults;
		}

		/*
		//Filters the given list based on the check box values and returns the filtered list
			//Narrow down nameSearchResults based on check boxes
		public static List<Ingredient> IngredientCheckBoxFilter(List<Ingredient> ingredientList, List<string> checkBoxValuesToFilter)
		{
			//for each String checkBoxValue, (linq) where ingredient.tags.contains(checkBoxValue)
			
			//Don't forget to check for duplicates
		}
		*/
		#endregion
	}
}
