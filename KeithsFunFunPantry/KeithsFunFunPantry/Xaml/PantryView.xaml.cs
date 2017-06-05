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
            ListBox_PantryView.ItemsSource = Pantry.Ingredients;
            TagListBox.ItemsSource = Enum.GetNames(typeof(Tag));

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
            ListBox_PantryView.ItemsSource = null;
            ListBox_PantryView.ItemsSource = displayList;
            foreach (Ingredient ingredient in ListBox_PantryView.Items)
            {
                PantryViewItem pvi = new PantryViewItem();
                pvi.DataContext = ingredient;
            }


            if (displayList.Count == 0)
            {
                Label noResults = new Label();
                noResults.Content = "No results found";
            }

        }

        private void Search()
        {
            string query = TextBox_PantrySearch.Text.ToLower();
            if (!query.Equals("search ingredients"))
			{
				if (query == "search recipes")
				{
					query = "";
				}

				ListIngredients(Pantry.IngredientSearchController(query));
            }
            else
            {
                ListIngredients(Pantry.Ingredients);
            }
        }

        private void SearchButton_ClickHandler(object sender, RoutedEventArgs e)
        {
            Search();
		}

        private void TextBox_PantrySearch_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                Search();
            }
        }
    }
}
