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

		public void SearchButtonClick_Handler(object sender, RoutedEventArgs e)
		{
			string query = TextBox_ByRecipeSearch.Text;
			RecipeBook.recipes.Where(recipe => recipe.Title.Contains(query));
			//Randy
				//I spent most of the day trying to understan how the UI was already set up,
				//and a lot of time exploring the files that Cristian created so that I 
				//understood where data was stored.
		}
    }
}
