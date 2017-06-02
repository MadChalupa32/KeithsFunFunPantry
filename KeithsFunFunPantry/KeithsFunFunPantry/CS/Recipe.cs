using KeithsFunFunPantry.CS;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeithsFunFunPantry
{
    [Serializable]
    public class Recipe : IComparable<Recipe>, IEquatable<Recipe>
    {
        public Recipe(List<Tag> tagList, List<Ingredient> ingredientList, String title, string directions = "", string notes = "")
        {
            TagList = tagList;
            IngredientList = ingredientList;
            Directions = directions;
            Title = title;
            Notes = notes;
        }

        private List<Ingredient> ingredientList;
        private string directions;
        private string title;
        private string notes;
        private List<Tag> tagList;

        public List<Tag> TagList
        {
            get { return tagList; }
            set { tagList = value; }
        }

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

        public List<Ingredient> IngredientList
        {
            get { return ingredientList; }
            set { ingredientList = value; }
        }

        public int CompareTo(Recipe other)
        {
            if (this.Title == other.Title) return 0;
            return this.Title.CompareTo(other.Title);            
        }

        public bool Equals(Recipe other)
        {
            if (this.Title.Equals(other.Title)) return true;
            return false;            
        }
    }
}
