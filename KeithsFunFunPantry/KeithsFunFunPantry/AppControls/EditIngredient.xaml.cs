using KeithsFunFunPantry.CS;
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

namespace KeithsFunFunPantry.AppControls
{
    /// <summary>
    /// Interaction logic for EditIngredient.xaml
    /// </summary>
    public partial class EditIngredient : UserControl
    {
        string ingredientTB = "Enter Ingredient Name";
        string addSubTB = "Amount";
        public EditIngredient()
        {
            InitializeComponent();
            FillUnits();
            TextBoxIngredient();
            TextBoxAdd();
            TextBoxSubtract();

        }
        private void FillUnits()
        {
            foreach (Unit units in Unit.TotalUnits)
            {
                ComboBox_1.Items.Add(units.LongHand);
            }
        }

        private void TextBoxIngredient()
        {
            TextBox_Ingredient.GotFocus += RemoveIngredientText;
            TextBox_Ingredient.LostFocus += AddIngredientText;
            TextBox_Ingredient.Text = ingredientTB;
        }
        private void TextBoxAdd()
        {
            TextBox_Add.GotFocus += RemoveAddText;
            TextBox_Add.LostFocus += AddAddText;
            TextBox_Add.Text = addSubTB;
        }
        private void TextBoxSubtract()
        {
            TextBox_Subtract.GotFocus += RemoveSubText;
            TextBox_Subtract.LostFocus += AddSubtractText;
            TextBox_Subtract.Text = addSubTB;
        }
        private void RemoveIngredientText(object sender, EventArgs e)
        {
            if (TextBox_Ingredient.Text == ingredientTB)
            {
                TextBox_Ingredient.Text = "";
            }
        }
        private void RemoveAddText(object sender, EventArgs e)
        {
            if (TextBox_Add.Text == addSubTB)
            {
                TextBox_Add.Text = "";
            }
        }
        private void RemoveSubText(object sender, EventArgs e)
        {
            if (TextBox_Subtract.Text == addSubTB)
            {
                TextBox_Subtract.Text = "";
            }
        }
        private void AddIngredientText(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TextBox_Ingredient.Text))
            {
                TextBox_Ingredient.Text = ingredientTB;
            }
        }
        private void AddAddText(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TextBox_Add.Text))
            {
                TextBox_Add.Text = addSubTB;
            }
        }
        private void AddSubtractText(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TextBox_Subtract.Text))
            {
                TextBox_Subtract.Text = addSubTB;
            }
        }
        private void ButtonAdd_Click(object sender, EventArgs e)
        {

        }
        private void ButtonSubtract_Click(object sender, EventArgs e)
        {

        }
    }

}
