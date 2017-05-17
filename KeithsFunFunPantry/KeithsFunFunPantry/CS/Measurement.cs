using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KeithsFunFunPantry.CS
{
    [Serializable()]
    public class Measurement
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private float amount;
        private Unit unitOfMeasurement;

        public float Amount
        {
            get { return amount; }
            set
            {
                amount = value;
                FieldChanged();
            }
        }

        public Unit UnitOfMeasurement
        {
            get { return unitOfMeasurement; }
            set
            {
                unitOfMeasurement = value;
                FieldChanged();
            }
        }

        public Measurement(float a, Unit u)
        {
            Amount = a;
            UnitOfMeasurement = u;
        }

        protected void FieldChanged([CallerMemberName] string field = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(field));
            }
        }
    }

    public enum Unit
    {
        teaspoon, tablespoon, cup,
        ounce, pound,
        pint, quart, gallon,
        milliliter, liter,
        gram, kilogram
    }
}
