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

        public void ListRecipes(List<Recipe> tempList)
        {
            foreach (Recipe recipe in tempList)
            {
                StackPanel_RecipeView.Children.Add(new RecipeViewItem(recipe));
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
    }
}
