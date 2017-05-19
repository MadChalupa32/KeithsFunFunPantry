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
using KeithsFunFunPantry.AppControls;
using KeithsFunFunPantry.CS;
using System.Globalization;

namespace KeithsFunFunPantry
{
    /// <summary>
    /// Interaction logic for EditingPantry.xaml
    /// </summary>
    public partial class EditingPantry : Page
    {

        private string searchTB = "Search Ingredient";
        private string amountTB = "Amount";
        private string nameTB = "Name";
        
        public EditingPantry()
        {
            InitializeComponent();
            TextBoxOptions();
            TextBoxOptions1();
            TextBoxOptions2();
            FillUnits();
            ShowPantry();
        }

        //Shows the ingredients in the pantry
        private void ShowPantry()
        {
            Pantry.AddNewIngredient("Brocolli", new CS.Measurement(2f, CS.Unit.Cup));
            Pantry.AddNewIngredient("Chicken", new CS.Measurement(16f, CS.Unit.Pound));
            Pantry.AddNewIngredient("Radishes", new CS.Measurement(3f, CS.Unit.Cup));
            Pantry.AddNewIngredient("Sugar", new CS.Measurement(4f, CS.Unit.Cup));
            Pantry.AddNewIngredient("Steak", new CS.Measurement(16f, CS.Unit.Pound));
            Pantry.AddNewIngredient("Milk", new CS.Measurement(2f, CS.Unit.Gallon));
            foreach (Ingredient ingredient in Pantry.Ingredients)
            {
                PantryEdit pe = new PantryEdit();
                pe.DataContext = ingredient;
                StackPanel_EditPantry.Children.Add(pe);
            }
        }

        //Removes text when it has focus, add text when it is empty and has lost focus (Search box)
        private void TextBoxOptions()
        {
            TextBox_IngredientSearch.GotFocus += RemoveISText;
            TextBox_IngredientSearch.LostFocus += AddISText;
            TextBox_IngredientSearch.Text = searchTB;
        }
        //" (Amount Box)
        private void TextBoxOptions1()
        {
            TextBox_Amount.GotFocus += RemoveASText;
            TextBox_Amount.LostFocus += AddASText;
            TextBox_Amount.FontFamily = new FontFamily("Georgia");
            TextBox_Amount.Text = amountTB;
        }
        //" (Name Box)
        private void TextBoxOptions2()
        {
            TextBox_Name.GotFocus += RemoveNSText;
            TextBox_Name.LostFocus += AddNSText;
            TextBox_Name.FontFamily = new FontFamily("Georgia");
            TextBox_Name.Text = nameTB;
        }
        // Removes Text when it has focus (Search)
        private void RemoveISText(object sender, EventArgs e)
        {
            if (TextBox_IngredientSearch.Text == searchTB)
            {
                TextBox_IngredientSearch.Text = "";
            }
        }
        //" (Amount)
        private void RemoveASText(object sender, EventArgs e)
        {
            if (TextBox_Amount.Text == amountTB)
            {
                TextBox_Amount.Text = "";
            }
        }
        //" (Name)
        private void RemoveNSText(object sender, EventArgs e)
        {
            if (TextBox_Name.Text == nameTB)
            {
                TextBox_Name.Text = "";
            }
        }
        //Adds Text when empty (Search)
        private void AddISText(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TextBox_IngredientSearch.Text))
            {
                TextBox_IngredientSearch.Text = searchTB;
            }
        }
        //Add
        private void AddASText(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TextBox_Amount.Text))
            {
                TextBox_Amount.Text = amountTB;
            }
        }
        private void AddNSText(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TextBox_Name.Text))
            {
                TextBox_Name.Text = nameTB;
            }
        }

        //Fills the ComboBox with the list of Units
        private void FillUnits()
        {

            foreach (Unit units in Unit.TotalUnits)
            {
                ComboBox_Units.Items.Add(units.LongHand);
            }
            //ComboBox_Units.Items.Add(Unit.Teaspoon.LongHand);
            //ComboBox_Units.Items.Add(Unit.Tablespoon.LongHand);
            //ComboBox_Units.Items.Add(Unit.Cup.LongHand);
            //ComboBox_Units.Items.Add(Unit.Ounce.LongHand);
            //ComboBox_Units.Items.Add(Unit.FluidOunce.LongHand);
            //ComboBox_Units.Items.Add(Unit.Pound.LongHand);
            //ComboBox_Units.Items.Add(Unit.Pint.LongHand);
            //ComboBox_Units.Items.Add(Unit.Quart.LongHand);
            //ComboBox_Units.Items.Add(Unit.Gallon.LongHand);
            //ComboBox_Units.Items.Add(Unit.Milliliter.LongHand);
            //ComboBox_Units.Items.Add(Unit.Liter.LongHand);
            //ComboBox_Units.Items.Add(Unit.Gram.LongHand);
            //ComboBox_Units.Items.Add(Unit.Kilogram.LongHand);
            //ComboBox_Units.Items.Add(Unit.Count.LongHand);


        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Searched for Entry" + "\n" + TextBox_IngredientSearch.Text);
        }

        //Logic for the Add Button (eventually adds the ingredient to the pantry list
        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            //Pantry.AddNewIngredient(TextBox_Name.Text, new CS.Measurement(float.Parse(TextBox_Amount.Text, CultureInfo.InvariantCulture.NumberFormat), CS.Unit.Tablespoon));
            MessageBox.Show("Adds Item to List and Clears the Boxes");
            TextBox_Name.Text = "Name";
            TextBox_Amount.Text = "Amount";
            ComboBox_Units.Text = "Unit";
        }

        //Saves the Current pantry
        private void SavePantry_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Saves Current Pantry");
        }
    }
}
