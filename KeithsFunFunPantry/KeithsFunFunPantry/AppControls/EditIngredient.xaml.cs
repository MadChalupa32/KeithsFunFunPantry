﻿using KeithsFunFunPantry.CS;
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
using KeithsFunFunPantry.Xaml;

namespace KeithsFunFunPantry.AppControls
{
    /// <summary>
    /// Interaction logic for EditIngredient.xaml
    /// </summary>
    public partial class EditIngredient : UserControl
    {
        string addSubTB = "Amount";
        public EditIngredient()
        {
            InitializeComponent();
            FillUnits();
            TextBoxAdd();
            TextBoxSubtract();
        }
        private void FillUnits()
        {
			ComboBox_1.ItemsSource = Unit.TotalUnits;
			//foreach (Unit units in Unit.TotalUnits)
			//{
			//	ComboBox_1.Items.Add(units.LongHand);
			//}
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
            float addAmount;
            float.TryParse(TextBox_Add.Text, out addAmount);
            for(int x = 0; x < Pantry.Ingredients.Count(); x++)
            {                
                if (Pantry.Ingredients[x].Name.ToLower() == TextBox_Ingredient.Text.ToLower())
                {
                    if ((Pantry.Ingredients[x].IngredientMeasurement.Amount + addAmount) < Pantry.Ingredients[x].IngredientMeasurement.Amount)
                    {
                        Logging.WriteLog(LogLevel.Warning, "Can't add a negative number");
                    }
                    else
                    {
                        Pantry.Ingredients[x].IngredientMeasurement.Amount += addAmount;
                    }
                }
            }
            TextBox_Add.Text = "";
            TextBoxAdd();
        }
        private void ButtonSubtract_Click(object sender, EventArgs e)
        {
            float subAmount;
            float.TryParse(TextBox_Subtract.Text, out subAmount);
            for(int x = 0; x < Pantry.Ingredients.Count(); x++)
            {
                if(Pantry.Ingredients[x].Name.ToLower() == TextBox_Ingredient.Text.ToLower())
                {
                    if ((Pantry.Ingredients[x].IngredientMeasurement.Amount - subAmount) < 0)
                    {
                        Logging.WriteLog(LogLevel.Warning, "Can't subtract more than you have");
                    }
                    else
                    {
                        Pantry.Ingredients[x].IngredientMeasurement.Amount -= subAmount;                    
                    }
                }
            }
            TextBox_Subtract.Text = "";
            TextBoxSubtract();
        }

        private void ComboBox_1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Unit targetUnit = ComboBox_1.SelectedItem as Unit;

            Ingredient targetIngredient = DataContext as Ingredient;

			try
			{
				targetIngredient.IngredientMeasurement.Convert(targetUnit);
			}
			catch(Exception)
			{
				//Conversion failed
				ComboBox_1.SelectedItem = targetIngredient.IngredientMeasurement.UnitOfMeasurement;
			}
        }
    }

}
