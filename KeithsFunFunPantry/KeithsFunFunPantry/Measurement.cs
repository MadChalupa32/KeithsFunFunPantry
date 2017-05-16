using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeithsFunFunPantry
{
    public class Measurement
    {
        enum units { tsp, Tbsp, cup, lb, oz, fluid_oz, pint, quart, gallon, ml, liter, gram, kilogram, count};
        float amount;
        public units Units { get; set; }
        public float Amount { get; set; }
    }
}
