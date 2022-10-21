using ProjetAppPizzeria.src;
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
using ProjetAppPizzeria.src.enums;
using System.Windows.Threading;

namespace ProjetAppPizzeria
{
    /// <summary>
    /// Logique d'interaction pour HelperPage3.xaml
    /// </summary>
    public partial class HelperPage3 : Page
    {
        private Client c;
        private Helper h;
        private Order o;
        internal HelperPage3(Client c, Helper h)
        {
            InitializeComponent();
            this.c = c;
            Pizza_Type.ItemsSource = Enum.GetValues(typeof(PizzaType)).Cast<PizzaType>();
            Pizza_Size.ItemsSource = Enum.GetValues(typeof(PizzaSize)).Cast<PizzaSize>();
            Drink_Type.ItemsSource = Enum.GetValues(typeof(DrinkType)).Cast<DrinkType>();
            this.o = new Order(c, h);
            DispatcherTimer dispatcherTimer = new DispatcherTimer(DispatcherPriority.Normal);
            dispatcherTimer.Tick += new EventHandler(timer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            
        }
        private void ButtonDisconnect(object sender, RoutedEventArgs e)
        {
            HelperPage1 helperPage1 = new HelperPage1();
            NavigationService.Navigate(helperPage1);
        }
    }
}
