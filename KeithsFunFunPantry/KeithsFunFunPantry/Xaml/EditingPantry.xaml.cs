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
            ListIngredients(Pantry.Ingredients);
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

        private void SearchButton_ClickHandler(object sender, RoutedEventArgs e)
        {
			string query = TextBox_IngredientSearch.Text;

			Pantry.IngredientSearchController(query);
        }

        //Logic for the Add Button (eventually adds the ingredient to the pantry list
        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            //Pantry.AddNewIngredient(TextBox_Name.Text, new CS.Measurement(float.Parse(TextBox_Amount.Text, CultureInfo.InvariantCulture.NumberFormat), CS.Unit.Tablespoon));
            MessageBox.Show("Adds Item to List and Clears the Boxes");
            float amount;
            float.TryParse(TextBox_Amount.Text, out amount);
            string unit = ComboBox_Units.Text.ToLower();
            switch (unit)
            {
                case "teaspoon":
                    Ingredient i = new Ingredient(TextBox_Name.Text, new Measurement(amount, Unit.Teaspoon));
                    Pantry.Ingredients.Add(i);
                    break;
                case "tablespoon":
                    Ingredient i2 = new Ingredient(TextBox_Name.Text, new Measurement(amount, Unit.Tablespoon));
                    Pantry.Ingredients.Add(i2);
                    break;
                case "cup":
                    Ingredient i3 = new Ingredient(TextBox_Name.Text, new Measurement(amount, Unit.Cup));
                    Pantry.Ingredients.Add(i3);
                    break;
                case "ounce":
                    Ingredient i4 = new Ingredient(TextBox_Name.Text, new Measurement(amount, Unit.Ounce));
                    Pantry.Ingredients.Add(i4);
                    break;
                case "fluidounce":
                    Ingredient i5 = new Ingredient(TextBox_Name.Text, new Measurement(amount, Unit.FluidOunce));
                    Pantry.Ingredients.Add(i5);
                    break;
                case "pound":
                    Ingredient i6 = new Ingredient(TextBox_Name.Text, new Measurement(amount, Unit.Pound));
                    Pantry.Ingredients.Add(i6);
                    break;
                case "pint":
                    Ingredient i7 = new Ingredient(TextBox_Name.Text, new Measurement(amount, Unit.Pint));
                    Pantry.Ingredients.Add(i7);
                    break;
                case "quart":
                    Ingredient i8 = new Ingredient(TextBox_Name.Text, new Measurement(amount, Unit.Quart));
                    Pantry.Ingredients.Add(i8);
                    break;
                case "gallon":
                    Ingredient i9 = new Ingredient(TextBox_Name.Text, new Measurement(amount, Unit.Gallon));
                    Pantry.Ingredients.Add(i9);
                    break;
                case "milliliter":
                    Ingredient i10 = new Ingredient(TextBox_Name.Text, new Measurement(amount, Unit.Milliliter));
                    Pantry.Ingredients.Add(i10);
                    break;
                case "liter":
                    Ingredient i11 = new Ingredient(TextBox_Name.Text, new Measurement(amount, Unit.Liter));
                    Pantry.Ingredients.Add(i11);
                    break;
                case "gram":
                    Ingredient i12 = new Ingredient(TextBox_Name.Text, new Measurement(amount, Unit.Gram));
                    Pantry.Ingredients.Add(i12);
                    break;
                case "kilogram":
                    Ingredient i13 = new Ingredient(TextBox_Name.Text, new Measurement(amount, Unit.Kilogram));
                    Pantry.Ingredients.Add(i13);
                    break;
                case "count":
                    Ingredient i14 = new Ingredient(TextBox_Name.Text, new Measurement(amount, Unit.Count));
                    Pantry.Ingredients.Add(i14);
                    break;
            }
            ListIngredients(Pantry.Ingredients);

        }

        public void ListIngredients(List<Ingredient> displayList)
        {
            StackPanel_EditPantry.Children.Clear();


            foreach (Ingredient ingredient in displayList)
            {
                PantryViewItem pvi = new PantryViewItem();
                pvi.DataContext = ingredient;
                StackPanel_EditPantry.Children.Add(pvi);
            }

            

        }

        //Saves the Current pantry
        private void SavePantry_Click(object sender, RoutedEventArgs e)
        {
            Pantry.SaveIngredient();
            MessageBox.Show("Saves Current Pantry");
        }
    }
}
