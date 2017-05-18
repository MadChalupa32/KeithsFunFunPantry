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

namespace KeithsFunFunPantry
{
    /// <summary>
    /// Interaction logic for EditingPantry.xaml
    /// </summary>
    public partial class EditingPantry : Page
    {
        private string searchTB = "Search Ingredient";
        public EditingPantry()
        {
            InitializeComponent();
            TextBoxOptions();
            ShowPantry();
        }

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

        private void TextBoxOptions()
        {
            TextBox_IngredientSearch.GotFocus += RemoveISText;
            TextBox_IngredientSearch.LostFocus += AddISText;
            TextBox_IngredientSearch.Text = searchTB;
        }


        private void RemoveISText(object sender, EventArgs e)
        {
            if (TextBox_IngredientSearch.Text == searchTB)
            {
                TextBox_IngredientSearch.Text = "";
            }
        }

        private void AddISText(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TextBox_IngredientSearch.Text))
            {
                TextBox_IngredientSearch.Text = searchTB;
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Boi");
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
