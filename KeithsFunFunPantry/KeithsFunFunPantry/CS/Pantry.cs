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
using System.Windows;

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
            bool foundMatch = false;
            int count = Ingredients.Count();
            Ingredient i = new Ingredient(name, m);
            while (!foundMatch && count >= 0)
            {
                if (count == 0)
                {
                    Ingredients.Add(i);
                    Logging.WriteLog(LogLevel.Info, "Ingredient ' " + name + " ' added to list");
                    foundMatch = true;
                    break;
                }
                else if (Ingredients.ElementAt(count-1).Name == i.Name)
                {
                    Logging.WriteLog(LogLevel.Info, "Ingredient already exists in list");
                    Logging.WriteLog(LogLevel.Info, "Increasing the amount");
                    IncrementAmount(i);
                    foundMatch = true;
                }
                else
                {
                    count--;
                }
            }
        }
        private static void IncrementAmount(Ingredient i)
        {
            float addedAmount = i.IngredientMeasurement.Amount;
            for(int x = 0; x < Ingredients.Count(); x++)
            {
                if(i.Name == Ingredients[x].Name)
                {
                    Ingredients[x].IngredientMeasurement.Amount += addedAmount;
                    Logging.WriteLog(LogLevel.Info, "Ingredient " + Ingredients[x].Name + " amount incremented by " + i.IngredientMeasurement.Amount);
                }
            }
        }
        //Will export to file.
        public static void SaveIngredient()
        {
            try
            {
                using (Stream stream = File.Open(@"C:\Users\Brian Walsh\Source\Repos\KeithsFunFunPantry\KeithsFunFunPantry\KeithsFunFunPantry\bin\Debug\ingredients.xml", FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, Ingredients);
                }
            }
            catch (IOException)
            {
                Logging.WriteLog(LogLevel.Error, "File has failed to open");
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
                    Ingredients.Clear();
                    foreach(Ingredient ingredient1 in sortedIngredients)
                    {
                        if (!Ingredients.Contains(ingredient1))
                        {
                        Ingredients.Add(ingredient1);
                        Logging.WriteLog(LogLevel.Info, ingredient1 + "imported");
                        }
                    }
                }
                Pantry.DisplayIngredients(Ingredients);
            }
            catch (IOException)
            {
                Logging.WriteLog(LogLevel.Error, "File has failed to open or doesn't exist");
            }
        }
        public static void RemoveIngredients(Ingredient i)
        {
            Ingredients.Remove(i);
            Logging.WriteLog(LogLevel.Info, "Ingredient " + i.Name + " Removed");
        }

        public static void DisplayIngredients(List<Ingredient> i)
        {
            foreach (Ingredient ingredient in i)
            {
                Logging.WriteLog(LogLevel.Info, "Ingredient " + ingredient.Name + " added");
            }
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
			List<Ingredient> queryResults = Ingredients.Where(ingredient => ingredient.Name.ToLower().Contains(query)).ToList();
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
