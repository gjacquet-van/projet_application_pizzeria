using ProjetAppPizzeria.src;
using ProjetAppPizzeria.src.enums;
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
using System.Windows.Threading;

namespace ProjetAppPizzeria
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Pizzeria pizzeria;

        public MainWindow()
        {
            
            InitializeComponent();
            pizzeria = new Pizzeria();
            Console.WriteLine(pizzeria);
            DispatcherTimer dispatcherTimer = new DispatcherTimer(DispatcherPriority.Normal);
            dispatcherTimer.Tick += new EventHandler(timer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();



        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddNewClient(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("helloworld");
        }

        private void sendNewOrderToCook(object sender, RoutedEventArgs e)
        {
            Pizza p1 = new Pizza(PizzaType.FOUR_CHEESES, PizzaSize.MEDIUM, 10);
            Pizza p2 = new Pizza(PizzaType.MARGHERITA, PizzaSize.LARGE, 12);
            Drink d1 = new Drink(DrinkType.WATER, 2);
            Drink d2 = new Drink(DrinkType.COLA, 3);
            List<Pizza> pizzas = new List<Pizza>();
            List<Drink> drinks = new List<Drink>();
            pizzas.Add(p1);
            pizzas.Add(p2);
            drinks.Add(d1);
            drinks.Add(d2);

            Order o = new Order((Client)pizzeria.getClients()[0], (Helper)pizzeria.getHelpers()[0], (DeliveryMan)pizzeria.getDeliveryMen()[0], pizzas, drinks, pizzeria.getOrders().Count);

            pizzeria.addOrder(o);
            OrderListToCook.ItemsSource = pizzeria.GetOrdersToCook();
        }
        private void finishCookingOrder(object sender, RoutedEventArgs e)
        {
            Order o = (Order)OrderListToCook.SelectedItem;
            pizzeria.getOrders()[o.GetOrderNumber()].SetIsCooked(true);
        }
        private void CancelCookingOrder(object sender, RoutedEventArgs e)
        {
            Order o = (Order)OrderListToCook.SelectedItem;
            pizzeria.getOrders()[o.GetOrderNumber()].SetIsCanceled(true);
        }
        private void finishDeliveringOrder(object sender, RoutedEventArgs e)
        {
            Order o = (Order)OrderListToDeliver.SelectedItem;
            pizzeria.getOrders()[o.GetOrderNumber()].SetIsDelivered(true);
        }
        private void CancelDeliveringOrder(object sender, RoutedEventArgs e)
        {
            Order o = (Order)OrderListToDeliver.SelectedItem;
            pizzeria.getOrders()[o.GetOrderNumber()].SetIsCanceled(true);
        }
        void timer_Tick(object sender, EventArgs e)
        {
            OrderListToCook.ItemsSource = pizzeria.GetOrdersToCook();
            OrderListToDeliver.ItemsSource = pizzeria.GetOrdersToDeliver();
        }
    
    }
}
