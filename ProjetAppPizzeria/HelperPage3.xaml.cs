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
using System.Collections;

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
            this.h = h;
            Pizza_Type.ItemsSource = Enum.GetValues(typeof(PizzaType)).Cast<PizzaType>();
            Pizza_Size.ItemsSource = Enum.GetValues(typeof(PizzaSize)).Cast<PizzaSize>();
            Drink_Type.ItemsSource = Enum.GetValues(typeof(DrinkType)).Cast<DrinkType>();
            this.o = new Order(c, h, ((MainWindow)Application.Current.MainWindow).GetPizzeria().getDeliveryMen()[0]);
            ListOfOrderElements.ItemsSource = o.GetOrderElements();
            DispatcherTimer dispatcherTimer = new DispatcherTimer(DispatcherPriority.Normal);
            dispatcherTimer.Tick += new EventHandler(timer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            ListOfOrderElements.ItemsSource = o.GetOrderElements();
        }
        private void ButtonDisconnect(object sender, RoutedEventArgs e)
        {
            HelperPage1 helperPage1 = new HelperPage1();
            NavigationService.Navigate(helperPage1);
        }

        private void AddElementInOrder(object sender, RoutedEventArgs e)
        {
            PizzaType p = (PizzaType)Pizza_Type.SelectedItem;
            PizzaSize s = (PizzaSize)Pizza_Size.SelectedItem;
            DrinkType d = (DrinkType)Drink_Type.SelectedItem;
            if (p != PizzaType.NULL && s != PizzaSize.NULL)
            {
                Pizza pizza = new Pizza(p, s);
                o.AddPizza(pizza);
            }
            if (d != DrinkType.NULL)
            {
                Drink drink = new Drink(d);
                o.AddDrink(drink);
            }
            if (p == PizzaType.NULL || s == PizzaSize.NULL)
            {
                MessageBox.Show("Error");
            }
            else if (p == PizzaType.NULL && s == PizzaSize.NULL && d == DrinkType.NULL)
            {
                MessageBox.Show("Error");
            }
            ListOfOrderElements.ItemsSource = o.GetOrderElements();


        }

        private void ConfirmOrder(object sender, RoutedEventArgs e)
        {
            o.SetTotalPrice(o.CalculTotalPrice());
            int n = ((MainWindow)Application.Current.MainWindow).GetPizzeria().getOrders().Count;
            o.SetOrderNumber(n);
            ((MainWindow)Application.Current.MainWindow).GetPizzeria().addOrder(o);
            HelperPage2 helperPage2 = new HelperPage2(h);
            NavigationService.Navigate(helperPage2);
        }

        private void DeletePizza(object sender, RoutedEventArgs e)
        {
            int index = ListOfOrderElements.SelectedIndex;
            o.DeletePizza(index);
            ListOfOrderElements.ItemsSource = o.GetOrderElements();
        }
    }
}
