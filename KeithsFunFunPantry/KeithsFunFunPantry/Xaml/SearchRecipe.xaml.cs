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
    /// Interaction logic for SearchRecipe.xaml
    /// </summary>
    public partial class SearchRecipe : Page
    {
        public SearchRecipe()
        {
            InitializeComponent();
            TextBoxOptions();
        }

        private string searchBar = "Search by Recipe";
        private void TextBoxOptions()
        {
            TextBox_ByRecipeSearch.GotFocus += RemoveText;
            TextBox_ByRecipeSearch.LostFocus += AddText;
            TextBox_ByRecipeSearch.Text = searchBar;
        }

        public void RemoveText(object sender, EventArgs e)
        {
            if (TextBox_ByRecipeSearch.Text == searchBar)
                TextBox_ByRecipeSearch.Text = "";
        }

        public void AddText(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TextBox_ByRecipeSearch.Text))
            {
                TextBox_ByRecipeSearch.Text = searchBar;
            }
        }

		/// <summary>
		/// Event handler that will search the recipe list for recipe objects whose title contains the query found in the recipe search text box.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void RecipeSearchButton_ClickHandler(object sender, RoutedEventArgs e)
		{
			string query = TextBox_ByRecipeSearch.Text;
			//RecipeBook.Recipes.Where(recipe => recipe.Title.Contains(query));
			MessageBox.Show("Inside recipe search handler\nQuery: {0}", query);
		}
    }
}
