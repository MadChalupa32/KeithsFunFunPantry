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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace KeithsFunFunPantry
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Window
    {
        private PantryView pantryView = new PantryView();
        //private RecipeView recipeView = new RecipeView();
        //private SearchIngredient searchIngredient = new SearchIngredient();
        //private SearchRecipe searchRecipe = new SearchRecipe();

        
        public HomePage()
        {
            InitializeComponent();
            this.Closed += new EventHandler(HomePage_Closed);
        }
        private void HomePage_Closed(object sender, EventArgs e)
        {
           // Pantry.AddNewIngredient();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void PantryView_Click(object sender, RoutedEventArgs e)
        {
            Frame_HomePage.Content = new PantryView();
        }

        private void RecipeView_Click(object sender, RoutedEventArgs e)
        {
            Frame_HomePage.Content = new RecipeView();
        }

        private void SearchIngredient_Click(object sender, RoutedEventArgs e)
        {
            Frame_HomePage.Content = new SearchIngredient();
        }
        private void SearchRecipe_Click(object sender, RoutedEventArgs e)
        {
            Frame_HomePage.Content = new SearchRecipe();
        }

        private void EditPantry_Click(object sender, RoutedEventArgs e)
        {
            Frame_HomePage.Content = new EditingPantry();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (Frame_HomePage.NavigationService.CanGoBack)
            {
                Frame_HomePage.NavigationService.GoBack();
            }
        }
        private void ForwardButton_Click(object sender, RoutedEventArgs e)
        {
            if (Frame_HomePage.NavigationService.CanGoForward)
            {
                Frame_HomePage.NavigationService.GoForward();
            }
        }
    }
}
