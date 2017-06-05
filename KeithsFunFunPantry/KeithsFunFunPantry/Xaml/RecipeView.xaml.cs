using KeithsFunFunPantry.AppControls;
using KeithsFunFunPantry.Windows;
using KeithsFunFunPantry.CS;
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
        private RecipeBook book = RecipeBook.Instance;
        public RecipeView()
        {
            InitializeComponent();
            TextBoxOptions();
            ListBox_RecipeView.ItemsSource = book.Recipes;
            TagListBox.ItemsSource = Enum.GetValues(typeof(Tag));
            
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

        private void Search()
        {
            string query = TextBox_RecipeSearch.Text.ToLower();

            //Compile the list of selected tags
            
            if (!query.Equals("search recipes") || (bool)TagSearchVisibilityCheckBox.IsChecked)
            {
				List<Tag> tags =  new List<Tag>();
				if ((bool)TagSearchVisibilityCheckBox.IsChecked)
				{
					foreach(Tag t in TagListBox.SelectedItems)
					{
						tags.Add(t);
					}
				}

				if(query == "search recipes")
				{
					query = "";
				}

				ListBox_RecipeView.ItemsSource = RecipeBook.Instance.RecipeSearchController(query, tags);
            }
            else
            {
                ListBox_RecipeView.ItemsSource = RecipeBook.Instance.Recipes;
            }
        }
		private void SearchButton_ClickHandler(object sender, RoutedEventArgs e)
        {
            Search();
		}
        private void SearchButton_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                Search();
            }
        }

        private void RecipeAddButton_Click(object sender, RoutedEventArgs e)
        {
            bool isWindowOpen = false;
            foreach (Window w in Application.Current.Windows)
            {
                if (w is AddRecipeWinodw)
                {
                    isWindowOpen = true;
                    w.Activate();
                }
            }
            if (!isWindowOpen)
            {
                AddRecipeWinodw w = new AddRecipeWinodw(this);
                w.Topmost = true;
                w.Show();
                w.Focus();
            }
        }

        private void RecipeRemoveButton_Click(object sender, RoutedEventArgs e)
        {
            book.Recipes.Remove((Recipe)ListBox_RecipeView.SelectedItem);
            ListBox_RecipeView.ItemsSource = null;
            ListBox_RecipeView.ItemsSource = book.Recipes;
        }


        private void RecipeViewItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                CreateRecipeViewWindow();
            }
        }

        private void ListBox_RecipeView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            CreateRecipeViewWindow();
            e.Handled = true;
        }

        private void CreateRecipeViewWindow()
        {
            bool isWindowOpen = false;
            foreach(Window w in Application.Current.Windows)
            {
                if (w is ViewAndEditRecipeWindow)
                {
                    isWindowOpen = true;
                    w.Activate();
                }
            }
            if (!isWindowOpen)
            {
                ViewAndEditRecipeWindow w = new ViewAndEditRecipeWindow(this);
                w.Topmost = true;
                w.Show();
                w.Focus();
            }
        }
    }
}
