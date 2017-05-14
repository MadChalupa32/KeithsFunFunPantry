using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeithsFunFunPantry
{
    [Serializable()]
    class Ingredient : Pantry
    {
        private string name;
        private int amount;

        //Name of the ingredient
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }
        //Amount of ingredient currently in pantry
        public int Amount
        {
            get { return amount; }
            set
            {
                amount = value;
            }
        }
    }
}
