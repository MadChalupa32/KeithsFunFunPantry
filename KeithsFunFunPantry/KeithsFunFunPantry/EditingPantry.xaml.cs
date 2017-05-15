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
    /// Interaction logic for EditingPantry.xaml
    /// </summary>
    public partial class EditingPantry : Page
    {
        public EditingPantry()
        {
            InitializeComponent();
            TextBoxOptions();
            TB2();
            TB3();

        }

        private string searchTB = "Search Recipes";
        private string amountTB = "Amount";
        private string nameTB = "Name";
        private void TextBoxOptions()
        {
            TextBox_IngredientSearch.GotFocus += RemoveISText;
            TextBox_IngredientSearch.LostFocus += AddISText;
            TextBox_IngredientSearch.Text = searchTB;
        }

        private void TB2()
        {
            TextBox_Amount.GotFocus += RemoveAText;
            TextBox_Amount.LostFocus += AddAText;
            TextBox_Amount.Text = amountTB;
        }

        private void TB3()
        {
            TextBox_Name.GotFocus += RemoveIText;
            TextBox_Name.LostFocus += AddIText;
            TextBox_Name.Text = nameTB;
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

        private void RemoveAText(object sender, EventArgs e)
        {
            if(String.IsNullOrWhiteSpace(TextBox_Amount.Text))
            {
                TextBox_Amount.Text = amountTB;     
            }
        }

        private void AddAText(object sender, EventArgs e)
        {
            if(TextBox_Amount.Text == amountTB)
            {
                TextBox_Amount.Text = "";
            }
        }

        public void RemoveIText(object sender, EventArgs e)
        {
            if(String.IsNullOrWhiteSpace(TextBox_Name.Text))
            {
                TextBox_Name.Text = nameTB;
            }
        }

        private void AddIText(object sender, EventArgs e)
        {
            if(TextBox_Name.Text == nameTB)
            {
                TextBox_Name.Text = "";
            }
        }

    }
}

