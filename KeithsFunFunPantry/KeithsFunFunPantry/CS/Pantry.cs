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
    public class Pantry : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public List<Ingredient> ingredients = new List<Ingredient>();
        public List<Ingredient> Ingredients
        {
            get { return ingredients; }
            set
            {
                ingredients = value;
                FieldChanged();
            }

        }

        //Will create a new ingredient, add to list, and export to file.
        public void AddNewIngredient(string name, int amount)
        {
            Ingredient ingredient = new Ingredient(name, amount);
            ingredients.Add(ingredient);
            try
            {
                using (Stream stream = File.Open("ingredients.xml", FileMode.Create))
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
        public void ReadIngredientsFromFile()
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
        protected void FieldChanged([CallerMemberName] string field = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(field));
            }
        }
    }
}
