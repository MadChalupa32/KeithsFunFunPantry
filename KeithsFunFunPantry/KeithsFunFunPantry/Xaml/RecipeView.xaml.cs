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
        private RecipeBook book = RecipeBook.Instance;
        public RecipeView()
        {
            InitializeComponent();
            TextBoxOptions();
            ListBox_RecipeView.ItemsSource = book.Recipes;
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


		private void SearchButton_ClickHandler(object sender, RoutedEventArgs e)
        {
			string query = TextBox_RecipeSearch.Text.ToLower();

			//Compile a list<string> of the check box values (advanced searching)

			RecipeBook book = RecipeBook.Instance;

			
			if (!query.Equals("search recipes"))
			{
				
                ListBox_RecipeView.ItemsSource = book.RecipeSearchController(query);

            }
			else
			{
                ListBox_RecipeView.ItemsSource = book.Recipes;
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

        private void RecipeRemoveButton_Click(object sender, RoutedEventArgs e)
        {
            book.Recipes.Remove((Recipe)ListBox_RecipeView.SelectedItem);
            ListBox_RecipeView.ItemsSource = null;
            ListBox_RecipeView.ItemsSource = book.Recipes;
        }


        private void RecipeViewItem_KeyDown(object sender, KeyEventArgs e)
        {



            MessageBox.Show(e.Key.ToString());
            if (e.Key == Key.Enter)
            {
                Window w = new Window();
                w.Height = 400;
                w.Width = 500;
                StackPanel sp = new StackPanel();
                w.Content = sp;
                sp.Children.Add(new ViewAndEditRecipe(this));
                w.Show();
            }
        }
        private void ListBox_RecipeView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MyPopup.IsOpen = true;
            RecipeView_Grid.DataContext = ListBox_RecipeView.SelectedItem;
        }

        private void HidePopUp_Click(object sender, RoutedEventArgs e)
        {
            MyPopup.IsOpen = false;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You can now Edit.");
            RecipeIngredients.IsReadOnly = false;
            RecipeInstructions.IsReadOnly = false;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            RecipeIngredients.IsReadOnly = true;
            RecipeInstructions.IsReadOnly = true;

        }
    }
}
