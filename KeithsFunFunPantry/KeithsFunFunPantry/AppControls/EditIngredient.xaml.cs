using KeithsFunFunPantry.CS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using KeithsFunFunPantry.Xaml;

namespace KeithsFunFunPantry.AppControls
{
    /// <summary>
    /// Interaction logic for EditIngredient.xaml
    /// </summary>
    public partial class EditIngredient : UserControl
    {
        string addSubTB = "Amount";
        public EditIngredient()
        {
            InitializeComponent();
            FillUnits();
            TextBoxAdd();
            TextBoxSubtract();
        }
        private void FillUnits()
        {
            foreach (Unit units in Unit.TotalUnits)
            {

                ComboBox_1.Items.Add(units.LongHand);
            }
        }

        private void TextBoxAdd()
        {
            TextBox_Add.GotFocus += RemoveAddText;
            TextBox_Add.LostFocus += AddAddText;
            TextBox_Add.Text = addSubTB;
        }
        private void TextBoxSubtract()
        {
            TextBox_Subtract.GotFocus += RemoveSubText;
            TextBox_Subtract.LostFocus += AddSubtractText;
            TextBox_Subtract.Text = addSubTB;
        }
        private void RemoveAddText(object sender, EventArgs e)
        {
            if (TextBox_Add.Text == addSubTB)
            {
                TextBox_Add.Text = "";
            }
        }
        private void RemoveSubText(object sender, EventArgs e)
        {
            if (TextBox_Subtract.Text == addSubTB)
            {
                TextBox_Subtract.Text = "";
            }
        }
        private void AddAddText(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TextBox_Add.Text))
            {
                TextBox_Add.Text = addSubTB;
            }
        }
        private void AddSubtractText(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TextBox_Subtract.Text))
            {
                TextBox_Subtract.Text = addSubTB;
            }
        }
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            float addAmount;
            float.TryParse(TextBox_Add.Text, out addAmount);
            for(int x = 0; x < Pantry.Ingredients.Count(); x++)
            {
                if (Pantry.Ingredients[x].Name.ToLower() == TextBox_Ingredient.Text.ToLower())
                {
                    Pantry.Ingredients[x].IngredientMeasurement.Amount += addAmount;
                }
            }
            TextBox_Add.Text = "";
            TextBoxAdd();
        }
        private void ButtonSubtract_Click(object sender, EventArgs e)
        {
            float subAmount;
            float.TryParse(TextBox_Subtract.Text, out subAmount);
            for(int x = 0; x < Pantry.Ingredients.Count(); x++)
            {
                if(Pantry.Ingredients[x].Name.ToLower() == TextBox_Ingredient.Text.ToLower())
                {
                    Pantry.Ingredients[x].IngredientMeasurement.Amount -= subAmount;
                }
            }
            TextBox_Subtract.Text = "";
            TextBoxSubtract();
        }

        private void ComboBox_1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Unit targetUnit = ComboBox_1.SelectedItem as Unit;
            Unit targetUnit = null;
            switch (ComboBox_1.SelectedItem.ToString().ToLower())
            {
                case "teaspoon":
                    targetUnit = Unit.Teaspoon;
                    break;
                case "tablespoon":
                    targetUnit = Unit.Tablespoon;
                    break;
                case "cup":
                    targetUnit = Unit.Cup;
                    break;
                case "ounce":
                    targetUnit = Unit.Ounce;
                    break;
                case "fluid ounce":
                    targetUnit = Unit.FluidOunce;
                    break;
                case "pound":
                    targetUnit = Unit.Pound;
                    break;
                case "pint":
                    targetUnit = Unit.Pint;
                    break;
                case "quart":
                    targetUnit = Unit.Quart;
                    break;
                case "gallon":
                    targetUnit = Unit.Gallon;
                    break;
                case "milliliter":
                    targetUnit = Unit.Milliliter;
                    break;
                case "liter":
                    targetUnit = Unit.Liter;
                    break;
                case "gram":
                    targetUnit = Unit.Gram;
                    break;
                case "kilogram":
                    targetUnit = Unit.Kilogram;
                    break;
                case "count":
                    targetUnit = Unit.Count;
                    break;
            }

            Ingredient targetIngredient = (Ingredient)this.DataContext;
            
            targetIngredient.IngredientMeasurement.Convert(targetUnit);
        }
    }

}
