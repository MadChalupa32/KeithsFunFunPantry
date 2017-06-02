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
using KeithsFunFunPantry.CS;

namespace KeithsFunFunPantry
{
    /// <summary>
    /// Interaction logic for SplashScreen.xaml
    /// </summary>
    public partial class SplashScreen : Window
    {
        HomePage homePage = new HomePage();
        public SplashScreen()
        {
            Splash();
            InitializeComponent();

            //VALIDATION
            //RecipeBook.Instance.Recipes.Count == 0;
            //SETTING TO DEFAULT DATA
            //for both the RecipeBook & Pantry
        }

        DispatcherTimer timer = new DispatcherTimer();
        private void Splash()
        {

            timer.Tick += new EventHandler(TimerTicker);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void TimerTicker(object sender, EventArgs e)
        {
            homePage.Show();
            timer.Stop();
            this.Close();
        }
    }
}