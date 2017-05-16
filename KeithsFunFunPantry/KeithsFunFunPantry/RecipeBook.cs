using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeithsFunFunPantry
{
    class RecipeBook
    {
        private List<Recipe> recipes;

        public List<Recipe> Recipes
        {
            get { return recipes; }
            set { recipes = value; }
        }
    }
}
