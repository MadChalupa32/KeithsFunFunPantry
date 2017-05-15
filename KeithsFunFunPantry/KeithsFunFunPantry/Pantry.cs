using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace KeithsFunFunPantry
{
    class Pantry
    {
        private List<Ingredient> ingredients;

        //Will create a new ingredient, add to list, and export to file.
        private void AddNewIngredient(string name, int amount)
        {
            Ingredient ingredient = new Ingredient(name, amount);
            ingredients.Add(ingredient);
            try
            {
                using (Stream stream = File.Open("ingredients.xml", FileMode.OpenOrCreate))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, ingredients);
                }
            }
            catch (IOException)
            {
                Console.WriteLine("File has failed to open");
            }
        }
        //Will import all ingredients from file to list
        private void ReadIngredientsFromFile()
        {
            try
            {
                using (Stream stream = File.Open("ingredients.xml", FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    var ingredient = (List<Ingredient>)bin.Deserialize(stream);
                    var sortedIngredients = ingredient.OrderBy(a => a.Name);
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
    }
}
