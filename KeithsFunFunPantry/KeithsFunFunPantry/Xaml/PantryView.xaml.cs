using System;
using System.Collections.Generic;
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

namespace KeithsFunFunPantry
{
    /// <summary>
    /// Interaction logic for PantryView.xaml
    /// </summary>
    public partial class PantryView : Page
    {
        public PantryView()
        {
            InitializeComponent();
            TextBoxOptions();
            ListIngredients();
        }

        private string searchBar = "Search Ingredients";
        private void TextBoxOptions()
        {

            TextBox_PantrySearch.GotFocus += RemoveText;
            TextBox_PantrySearch.LostFocus += AddText;
            TextBox_PantrySearch.Text = searchBar;
        }

        public void RemoveText(object sender, EventArgs e)
        {
            if (TextBox_PantrySearch.Text == searchBar)
                TextBox_PantrySearch.Text = "";
        }

        public void AddText(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TextBox_PantrySearch.Text))
            {
                TextBox_PantrySearch.Text = searchBar;
            }
        }
        public void ListIngredients()
        {
            Pantry.AddNewIngredient("Salt", new Measurement(20f, Unit.gram));
            Pantry.AddNewIngredient("Apple Slices", new Measurement(5f, Unit.cup));
            foreach (Ingredient ingredient in Pantry.Ingredients)
            {
                //PantryView pv = new PantryView();
                //    pv.DataContext = ingredient.Name;
                //    pv.DataContext = ingredient.IngredientMeasurement.ToString();
                //    StackPanel_PantryView.Children.Add(pv);
                //    Label label = new Label();
                //    label.Content = "Name: " + ingredient.Name + " Amount: " + ingredient.IngredientMeasurement.ToString();
                //    StackPanel_PantryView.Children.Add(label);
            }
    }

    private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("boi");
        }
    }
}
