using KeithsFunFunPantry.AppControls;
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
			ListIngredients(Pantry.Ingredients);
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

		public void ListIngredients(List<Ingredient> displayList)
		{
			StackPanel_SearchIngredients.Children.Clear();


			foreach (Ingredient ingredient in displayList)
			{
				PantryViewItem pvi = new PantryViewItem();
				pvi.DataContext = ingredient;
				StackPanel_SearchIngredients.Children.Add(pvi);
			}

			if (displayList.Count == 0)
			{
				Label noResults = new Label();
				noResults.Content = "No results found";
				StackPanel_SearchIngredients.Children.Add(noResults);
			}

		}

		/// <summary>
		/// Event handler that will search the pantry for ingredient objects whose name contains the query found in the ingredient search text box.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SearchButton_ClickHandler(object sender, RoutedEventArgs e)
        {
			StackPanel_SearchIngredients.Children.Clear();

			string query = TextBox_ByIngredientSearch.Text.ToLower();

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
