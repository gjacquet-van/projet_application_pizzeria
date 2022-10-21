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
            ClientList.ItemsSource = pizzeria.getAllClients();
            DeliveryManList.ItemsSource = pizzeria.getAllDeliveryMen();
            HelperList.ItemsSource = pizzeria.getAllHelpers();
            OrdersList.ItemsSource = pizzeria.GetAllOrdersStat();
            DispatcherTimer dispatcherTimer = new DispatcherTimer(DispatcherPriority.Normal);
            dispatcherTimer.Tick += new EventHandler(timer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();



        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
            OrdersList.ItemsSource = pizzeria.GetAllOrdersStat();
        }
        private void CancelCookingOrder(object sender, RoutedEventArgs e)
        {
            Order o = (Order)OrderListToCook.SelectedItem;
            pizzeria.getOrders()[o.GetOrderNumber()].SetIsCanceled(true);
            OrdersList.ItemsSource = pizzeria.GetAllOrdersStat();
        }
        private void finishPreparingOrder(object sender, RoutedEventArgs e)
        {
            Order o = (Order)OrderList.SelectedItem;
            pizzeria.getOrders()[o.GetOrderNumber()].SetIsReady(true);
            OrdersList.ItemsSource = pizzeria.GetAllOrdersStat();
        }
        private void CancelOrder(object sender, RoutedEventArgs e)
        {
            Order o = (Order)OrderList.SelectedItem;
            pizzeria.getOrders()[o.GetOrderNumber()].SetIsCanceled(true);
            OrdersList.ItemsSource = pizzeria.GetAllOrdersStat();
        }
        private void finishDeliveringOrder(object sender, RoutedEventArgs e)
        {
            Order o = (Order)OrderListToDeliver.SelectedItem;
            pizzeria.getOrders()[o.GetOrderNumber()].SetIsDelivered(true);
            OrdersList.ItemsSource = pizzeria.GetAllOrdersStat();
        }
        private void CancelDeliveringOrder(object sender, RoutedEventArgs e)
        {
            Order o = (Order)OrderListToDeliver.SelectedItem;
            pizzeria.getOrders()[o.GetOrderNumber()].SetIsCanceled(true);
            OrdersList.ItemsSource = pizzeria.GetAllOrdersStat();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            OrderListToCook.ItemsSource = pizzeria.GetOrdersToCook();
            OrderListToDeliver.ItemsSource = pizzeria.GetOrdersToDeliver();
            OrderList.ItemsSource = pizzeria.GetAllOrders();
        }

        public void refreshData()
        {
            OrdersList.ItemsSource = pizzeria.GetAllOrdersStat();
        }
        
        internal Pizzeria GetPizzeria()
        {
            return pizzeria;
        }

        private void CloseOrder(object sender, RoutedEventArgs e)
        {
            Order o = (Order)OrderList.SelectedItem;
            pizzeria.getOrders()[o.GetOrderNumber()].SetIsClosed(true);
            pizzeria.getOrders()[o.GetOrderNumber()].GetClient().addSpending(o.GetTotalPrice());
            pizzeria.getOrders()[o.GetOrderNumber()].GetClient().addOrder();
            pizzeria.getOrders()[o.GetOrderNumber()].GetDeliveryMan().addDelivery();
            pizzeria.getOrders()[o.GetOrderNumber()].GetHelper().addNumberOfOrders();
            HelperList.ItemsSource = pizzeria.getAllHelpers();
            DeliveryManList.ItemsSource = pizzeria.getAllDeliveryMen();
            ClientList.ItemsSource = pizzeria.getAllClients();
            OrdersList.ItemsSource = pizzeria.GetAllOrdersStat();
        }

        private void DeleteHelper(object sender, RoutedEventArgs e)
        {
            Helper h = (Helper)HelperList.SelectedItem;
            int i = pizzeria.getHelpers().FindIndex(x => x == h);
            pizzeria.DeleteHelper(i);
            HelperList.ItemsSource = pizzeria.getAllHelpers();
        }

        private void DeleteDeliveryMan(object sender, RoutedEventArgs e)
        {
            DeliveryMan dm = (DeliveryMan)DeliveryManList.SelectedItem;
            int i = pizzeria.getDeliveryMen().FindIndex(x => x == dm);
            pizzeria.DeleteDeliveryMan(i);
            DeliveryManList.ItemsSource = pizzeria.getAllDeliveryMen();
        }



        private void AddNewHelper(object sender, RoutedEventArgs e)
        {
            string hf = HelperFirstname.Text;
            string hl = HelperLastname.Text;
            string hpn = HelperPhoneNumber.Text;
            string hsn = HelperStreetNumber.Text;
            string hsname = HelperStreetName.Text;
            string hc = HelperCity.Text;
            string hpc = HelperPostalCode.Text;
            string hcountry = HelperCountry.Text;

            Helper h1 = new Helper(hf, hl, hpn, hsn, hsname, hc, hpc, hcountry, 1000);
            pizzeria.addHelper(h1);
            HelperList.ItemsSource = pizzeria.getAllHelpers();

        }

        private void AddNewDeliveryMan(object sender, RoutedEventArgs e)
        {
            string dmf = DeliveryManFirstname.Text;
            string dml = DeliveryManLastname.Text;
            string dmpn = DeliveryManPhoneNumber.Text;
            string dmsn = DeliveryManStreetNumber.Text;
            string dmsname = DeliveryManStreetName.Text;
            string dmc = DeliveryManCity.Text;
            string dmpc = DeliveryManPostalCode.Text;
            string dmcountry = DeliveryManCountry.Text;

            DeliveryMan dm1 = new DeliveryMan(dmf, dml, dmpn, dmsn, dmsname, dmc, dmpc, dmcountry, 1000);
            pizzeria.addDeliveryMan(dm1);
            DeliveryManList.ItemsSource = pizzeria.getAllDeliveryMen();


        }
    }
}
