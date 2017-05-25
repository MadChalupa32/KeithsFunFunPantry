using KeithsFunFunPantry.AppControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for RecipeView.xaml
    /// </summary>
    public partial class RecipeView : Page
    {
        public RecipeView()
        {
            InitializeComponent();
            TextBoxOptions();
            RecipeBook book = RecipeBook.Instance;
			ListRecipes(book.Recipes);
        }

        private string searchBar = "Search Recipes";
        private void TextBoxOptions()
        {
            TextBox_RecipeSearch.GotFocus += RemoveText;
            TextBox_RecipeSearch.LostFocus += AddText;
            TextBox_RecipeSearch.Text = searchBar;
        }

        public void RemoveText(object sender, EventArgs e)
        {
            if (TextBox_RecipeSearch.Text == searchBar)
                TextBox_RecipeSearch.Text = "";
        }

        public void AddText(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TextBox_RecipeSearch.Text))
            {
                TextBox_RecipeSearch.Text = searchBar;
            }
        }

		public void ListRecipes(List<Recipe> displayList)
		{
			StackPanel_RecipeView.Children.Clear();


			foreach (Recipe recipe in displayList)
			{
				RecipeViewItem rvi = new RecipeViewItem(recipe);
				StackPanel_RecipeView.Children.Add(rvi);
                
			}

			if (displayList.Count == 0)
			{
				Label noResults = new Label();
				noResults.Content = "No results found";
				StackPanel_RecipeView.Children.Add(noResults);
			}

		}

		private void SearchButton_ClickHandler(object sender, RoutedEventArgs e)
        {
			string query = TextBox_RecipeSearch.Text.ToLower();

			//Compile a list<string> of the check box values (advanced searching)

			RecipeBook book = RecipeBook.Instance;

			StackPanel_RecipeView.Children.Clear();
			if (!query.Equals("search recipes"))
			{
				ListRecipes(book.RecipeSearchController(query));
			}
			else
			{
				ListRecipes(book.Recipes);
			}
		}

        private void RecipeAddButton_Click(object sender, RoutedEventArgs e)
        {
            
            Window w = new Window();
            w.Height = 400;
            w.Width = 500;
            StackPanel sp = new StackPanel();
            w.Content = sp;
            sp.Children.Add(new AddRecipeWindow(this));
            w.Show();


            //StackPanel_RecipeView.Children.Add(p);

        }
    }
}
