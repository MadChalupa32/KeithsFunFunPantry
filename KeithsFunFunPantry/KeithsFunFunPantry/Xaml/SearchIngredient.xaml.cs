using KeithsFunFunPantry.AppControls;
using KeithsFunFunPantry.CS;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace KeithsFunFunPantry
{
    /// <summary>
    /// Interaction logic for SearchIngredient.xaml
    /// </summary>
    public partial class SearchIngredient : Page
    {
        public SearchIngredient()
        {
            InitializeComponent();
            TextBoxOptions();
            RecipeBook book = RecipeBook.Instance;

            TagListBox.ItemsSource = Enum.GetNames(typeof(Tag));

            ListBox_SearchIngredient.ItemsSource = book.Recipes;
        }

        private string searchBar = "Search by Ingredient";
        private void TextBoxOptions()
        {
            TextBox_ByIngredientSearch.GotFocus += RemoveText;
            TextBox_ByIngredientSearch.LostFocus += AddText;
            TextBox_ByIngredientSearch.Text = searchBar;
        }

        public void RemoveText(object sender, EventArgs e)
        {
            if (TextBox_ByIngredientSearch.Text == searchBar)
                TextBox_ByIngredientSearch.Text = "";
        }

        public void AddText(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TextBox_ByIngredientSearch.Text))
            {
                TextBox_ByIngredientSearch.Text = searchBar;
            }
        }

        public void ListIngredients(ObservableCollection<Ingredient> displayList){}

		/// <summary>
		/// Event handler that will search the pantry for ingredient objects whose name contains the query found in the ingredient search text box.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        /// 
        private void Search()
        {
            string query = TextBox_ByIngredientSearch.Text.ToLower();

            if (!query.Equals("search by ingredient") || (bool)TagSearchVisibilityCheckBox.IsChecked)
            {
				List<Tag> tags = new List<Tag>();
				if ((bool)TagSearchVisibilityCheckBox.IsChecked)
				{
					foreach (Tag t in TagListBox.SelectedItems)
					{
						tags.Add(t);
					}
				}

				if (query == "search recipes")
				{
					query = "";
				}

				//ListIngredients(Pantry.IngredientSearchController(query, tags));
            }
            else
            {
                //ListIngredients(Pantry.Ingredients);
            }
        }
		private void SearchButton_ClickHandler(object sender, RoutedEventArgs e)
        {
            Search();
		}

        private void TextBox_ByIngredientSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                Search();
            }
        }
    }
}
