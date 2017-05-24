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
    /// Interaction logic for AddRecipeWindow.xaml
    /// </summary>
    public partial class AddRecipeWindow : UserControl
    {
        public AddRecipeWindow()
        {
            InitializeComponent();
            
            StackPanel sp = new StackPanel();
            IngredientDisplayer.Content = sp;
            foreach (Ingredient ingr in Pantry.Ingredients)
            {
                sp.Children.Add(new AddRecipeIngredientList(ingr));
                
            }
        }
    }
}
