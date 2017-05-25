using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeithsFunFunPantry
{
    [Serializable]
    public class Recipe
    {
        public Recipe(ObservableCollection<Ingredient> ingredientList, String title, string directions = "", string notes = "")
        {
            IngredientList = ingredientList;
            Directions = directions;
            Title = title;
        }

        public static ObservableCollection<Ingredient> ingredientList;
        private string directions;
        private string title;
        private string notes;

        public string Notes
        {
            get { return notes; }
            set { notes = value; }
        }


        public string Title
        {
            get { return title; }
            set { title = value; }
        }


        public string Directions
        {
            get { return directions; }
            set { directions = value; }
        }

        public ObservableCollection<Ingredient> IngredientList
        {
            get { return ingredientList; }
            set { ingredientList = value; }
        }
    }
}
