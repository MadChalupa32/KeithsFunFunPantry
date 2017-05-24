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
using System.Collections.ObjectModel;

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


            //Pantry.AddNewIngredient("Salt", new Measurement(20f, Unit.Gram));
            //Pantry.AddNewIngredient("Apple Slices", new Measurement(5f, Unit.Cup));
            ListIngredients(Pantry.Ingredients);
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
        public void ListIngredients(ObservableCollection<Ingredient> displayList)
        {
            StackPanel_PantryView.Children.Clear();

            
            foreach (Ingredient ingredient in displayList)
            {
                PantryViewItem pvi = new PantryViewItem();
                pvi.DataContext = ingredient;
                StackPanel_PantryView.Children.Add(pvi);
            }
            
            if (displayList.Count == 0)
            {
                Label noResults = new Label();
                noResults.Content = "No results found";
                StackPanel_PantryView.Children.Add(noResults);
            }

        }

        private void SearchButton_ClickHandler(object sender, RoutedEventArgs e)
        {
            StackPanel_PantryView.Children.Clear();
            string query = TextBox_PantrySearch.Text.ToLower();
            if (!query.Equals("search ingredients"))
            {
                ListIngredients(Pantry.IngredientSearchController(query));   
            }
            else
            {
                ListIngredients(Pantry.Ingredients);
            }
		}
    }
}
