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
using System.Collections.ObjectModel;

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
            StackPanel_EditPantry.Children.Clear();
            string query = TextBox_IngredientSearch.Text.ToLower();
            if (!query.Equals("search ingredient"))
            {
                ListIngredients(Pantry.IngredientSearchController(query));
            }
            else
            {
                ListIngredients(Pantry.Ingredients);
            }
        }

        //Logic for the Add Button (eventually adds the ingredient to the pantry list
        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            //Pantry.AddNewIngredient(TextBox_Name.Text, new CS.Measurement(float.Parse(TextBox_Amount.Text, CultureInfo.InvariantCulture.NumberFormat), CS.Unit.Tablespoon));
            string name = (string)TextBox_Name.Text;
            float amount;
            float.TryParse(TextBox_Amount.Text, out amount);
            string unit = ComboBox_Units.Text.ToLower();
            switch (unit)
            {
                case "teaspoon":
                    Pantry.AddNewIngredient(name, new Measurement(amount, Unit.Teaspoon));
                    break;
                case "tablespoon":
                    Pantry.AddNewIngredient(name, new Measurement(amount, Unit.Tablespoon));
                    break;
                case "cup":
                    Pantry.AddNewIngredient(name, new Measurement(amount, Unit.Cup));
                    break;
                case "ounce":
                    Pantry.AddNewIngredient(name, new Measurement(amount, Unit.Ounce));
                    break;
                case "fluidounce":
                    Pantry.AddNewIngredient(name, new Measurement(amount, Unit.FluidOunce));
                    break;
                case "pound":
                    Pantry.AddNewIngredient(name, new Measurement(amount, Unit.Pound));
                    break;
                case "pint":
                    Pantry.AddNewIngredient(name, new Measurement(amount, Unit.Pint));
                    break;
                case "quart":
                    Pantry.AddNewIngredient(name, new Measurement(amount, Unit.Quart));
                    break;
                case "gallon":
                    Pantry.AddNewIngredient(name, new Measurement(amount, Unit.Gallon));
                    break;
                case "milliliter":
                    Pantry.AddNewIngredient(name, new Measurement(amount, Unit.Milliliter));
                    break;
                case "liter":
                    Pantry.AddNewIngredient(name, new Measurement(amount, Unit.Liter));
                    break;
                case "gram":
                    Pantry.AddNewIngredient(name, new Measurement(amount, Unit.Gram));
                    break;
                case "kilogram":
                    Pantry.AddNewIngredient(name, new Measurement(amount, Unit.Kilogram));
                    break;
                case "count":
                    Pantry.AddNewIngredient(name, new Measurement(amount, Unit.Count));
                    break;
            }
            ListIngredients(Pantry.Ingredients);

        }

        public void ListIngredients(ObservableCollection<Ingredient> displayList)
        {
            StackPanel_EditPantry.Children.Clear();


            foreach (Ingredient ingredient in displayList)
            {
                PantryEdit pvi = new PantryEdit();
                pvi.DataContext = ingredient;
                pvi.amountLabel.Content = ingredient.IngredientMeasurement.Amount;
                StackPanel_EditPantry.Children.Add(pvi);
            }

            if (displayList.Count == 0)
            {
                Label noResults = new Label();
                noResults.Content = "No results found";
                StackPanel_EditPantry.Children.Add(noResults);
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
