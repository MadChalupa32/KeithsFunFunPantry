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
using KeithsFunFunPantry.AppControls;

namespace KeithsFunFunPantry
{
    /// <summary>
    /// Interaction logic for EditingPantry.xaml
    /// </summary>
    public partial class EditingPantry : Page
    {
        List<Ingredient> pantryList = new List<Ingredient>() { };

        private string searchTB = "Search Recipes";
        public EditingPantry()
        {
            InitializeComponent();
            TextBoxOptions();
            ShowPantry();
        }

        private void ShowPantry()
        {
            pantryList.Add(new Ingredient ( Name = "brocolli", 2 ));
            pantryList.Add(new Ingredient ( Name = "Chicken", 16 ));
            pantryList.Add(new Ingredient ( Name = "Radishes", 3 ));
            pantryList.Add(new Ingredient ( Name = "brocolli",2 ));
            pantryList.Add(new Ingredient ( Name = "Chicken",16 ));
            pantryList.Add(new Ingredient ( Name = "Radishes",3 ));
            foreach (Ingredient ingredient in pantryList)
            {
                PantryEdit pe = new PantryEdit();
                pe.DataContext = ingredient;
                StackPanel_PantryList.Children.Add(pe);
            }
        }

        private void TextBoxOptions()
        {
            TextBox_IngredientSearch.GotFocus += RemoveISText;
            TextBox_IngredientSearch.LostFocus += AddISText;
            TextBox_IngredientSearch.Text = searchTB;
        }
    

        private void RemoveISText(object sender, EventArgs e)
        {
            if (TextBox_IngredientSearch.Text == searchTB)
            {
                TextBox_IngredientSearch.Text = "";
            }
        }

        private void AddISText(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TextBox_IngredientSearch.Text))
            {
                TextBox_IngredientSearch.Text = searchTB;
            }
        }
    }
}

