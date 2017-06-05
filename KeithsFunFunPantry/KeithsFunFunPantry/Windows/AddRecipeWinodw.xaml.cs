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
using System.Windows.Shapes;

namespace KeithsFunFunPantry.Windows
{
    /// <summary>
    /// Interaction logic for AddRecipeWinodw.xaml
    /// </summary>
    public partial class AddRecipeWinodw : Window
    {
        RecipeView rv;
        public AddRecipeWinodw(RecipeView rv)
        {
            InitializeComponent();
            TagDisplayer.ItemsSource = Enum.GetValues(typeof(Tag));
            IngredientDisplayer.ItemsSource = Pantry.Ingredients;
            this.rv = rv;
            TextBoxOptions();
            this.Focus();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            List<Tag> selectedTags = new List<Tag>();
            foreach (Object obj in TagDisplayer.SelectedItems)
            {
                selectedTags.Add((Tag)obj);
            }

            List<Ingredient> selectedIngredients = new List<Ingredient>();
            foreach (Object obj in IngredientDisplayer.SelectedItems)
            {
                selectedIngredients.Add((Ingredient)obj);
            }

            Recipe r = new Recipe(selectedTags, selectedIngredients, TitleEntryTB.Text, DirectionsEntryTB.Text, NotesEntryTB.Text);
            RecipeBook book = RecipeBook.Instance;
            book.Recipes.Add(r);
            rv.ListBox_RecipeView.ItemsSource = null;
            rv.ListBox_RecipeView.ItemsSource = book.Recipes;
            this.Close();
            RecipeBook.Instance.Recipes.Sort();
        }



        private string TitleDefault = "Example Title";
        private string DirectionsDefault = "Please Enter Directions";
        private string NotesDefault = "Please enter notes and/or ingredient quantities";
        private void TextBoxOptions()
        {
            TitleEntryTB.GotFocus += RemoveTitleText;
            TitleEntryTB.LostFocus += AddTitleText;

            DirectionsEntryTB.GotFocus += RemoveDirectionsText;
            DirectionsEntryTB.LostFocus += AddDirectionsText;

            NotesEntryTB.GotFocus += RemoveNotesText;
            NotesEntryTB.LostFocus += AddNotesText;

            TitleEntryTB.Text = TitleDefault;
            DirectionsEntryTB.Text = DirectionsDefault;
            NotesEntryTB.Text = NotesDefault;
        }

        public void RemoveTitleText(object sender, EventArgs e)
        {
            if (TitleEntryTB.Text == TitleDefault)
                TitleEntryTB.Text = "";
        }
        public void RemoveDirectionsText(object sender, EventArgs e)
        {
            if (DirectionsEntryTB.Text == DirectionsDefault)
                DirectionsEntryTB.Text = "";
        }
        public void RemoveNotesText(object sender, EventArgs e)
        {
            if (NotesEntryTB.Text == NotesDefault)
                NotesEntryTB.Text = "";
        }

        public void AddTitleText(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TitleEntryTB.Text))
            {
                TitleEntryTB.Text = TitleDefault;
            }
        }
        public void AddDirectionsText(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(DirectionsEntryTB.Text))
            {
                DirectionsEntryTB.Text = DirectionsDefault;
            }
        }
        public void AddNotesText(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(NotesEntryTB.Text))
            {
                NotesEntryTB.Text = NotesDefault;

            }
        }

    }
}
