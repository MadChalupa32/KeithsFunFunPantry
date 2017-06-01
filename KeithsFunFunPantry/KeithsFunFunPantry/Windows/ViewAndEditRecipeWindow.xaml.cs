using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace KeithsFunFunPantry.Windows
{
    /// <summary>
    /// Interaction logic for ViewAndEditRecipeWindow.xaml
    /// </summary>
    public partial class ViewAndEditRecipeWindow : Window, INotifyPropertyChanged
    {
        RecipeView rv;
        public event PropertyChangedEventHandler PropertyChanged;
        private bool enabled = true;

        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; FieldChanged(); }
        }
        public ViewAndEditRecipeWindow(RecipeView rv)
        {
            InitializeComponent();
            TextBoxOptions();
            ParentPanel.DataContext = this;
            IngredientDisplayer.ItemsSource = Pantry.Ingredients;
            foreach (Object obj in IngredientDisplayer.Items)
            {
                foreach (Ingredient i in ((rv.ListBox_RecipeView.SelectedItem as Recipe).IngredientList))
                {
                    if (i.Name == ((Ingredient)obj).Name)
                    {
                        IngredientDisplayer.SelectedItems.Add(obj);
                    }
                }
            }
            IngredientDisplayer.SelectedItems.Add(IngredientDisplayer.Items);
            TitleEntryTB.Text = ((Recipe)rv.ListBox_RecipeView.SelectedItem).Title;
            DirectionsEntryTB.Text = ((Recipe)rv.ListBox_RecipeView.SelectedItem).Directions;
            NotesEntryTB.Text = ((Recipe)rv.ListBox_RecipeView.SelectedItem).Notes;
            this.rv = rv;
            Enabled = false;
        }
        
        public void FieldChanged([CallerMemberName] string fieldName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(fieldName));
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            List<Ingredient> selectedIngredients = new List<Ingredient>();
            foreach (Object obj in IngredientDisplayer.SelectedItems)
            {
                selectedIngredients.Add((Ingredient)obj);
            }
            Recipe r = new Recipe(selectedIngredients, TitleEntryTB.Text, DirectionsEntryTB.Text, NotesEntryTB.Text);
            RecipeBook book = RecipeBook.Instance;
            foreach (Recipe rec in book.Recipes.ToList<Recipe>())
            {
                if (rv.ListBox_RecipeView.SelectedItem == rec)
                {
                    book.Recipes.Remove(rec);
                }

            }
            book.Recipes.Add(r);
            rv.ListBox_RecipeView.SelectedItem = r;
            rv.ListBox_RecipeView.ItemsSource = null;
            rv.ListBox_RecipeView.ItemsSource = book.Recipes;
            this.Close();
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

        private void EnableEditButton_Click(object sender, RoutedEventArgs e)
        {
            Enabled = !Enabled;

        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            //fixed problem with closing window
            this.Close();
            //Application.Current.Windows[1].Close();
        }
    }
}
