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
    /// Interaction logic for PantryView.xaml
    /// </summary>
    public partial class PantryView : Page
    {
        HomePage p = new HomePage();
        public PantryView()
        {
            InitializeComponent();
            TextBoxOptions();
        }

        private string ph = "Search Ingredients";
        private void TextBoxOptions()
        {

            TextBox_PantrySearch.GotFocus += RemoveText;
            TextBox_PantrySearch.LostFocus += AddText;
            TextBox_PantrySearch.Text = ph;
        }

        public void RemoveText(object sender, EventArgs e)
        {
            if (TextBox_PantrySearch.Text == ph)
                TextBox_PantrySearch.Text = "";
        }

        public void AddText(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TextBox_PantrySearch.Text))
            {
                TextBox_PantrySearch.Text = ph;
            }
        }
    }
}
