using ProjetAppPizzeria.src;
using ProjetAppPizzeria.src.enums;
using System;
using System.Collections;
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

        private List<Order> GetOrdersFromHelper(Helper helper)
        {
            return pizzeria.getOrders().FindAll(order => ((order.GetIsDelivered() == true) && (order.GetIsCanceled() == false) && (order.GetHelper() == helper)));
        }
        private int GetTotalOrdersFromHelper(Helper helper)
        {
            return this.GetOrdersFromHelper(helper).Count;
        }
        private List<Order> GetOrdersFromDeliveryMan(DeliveryMan DeliveryMan)
        {
            return pizzeria.getOrders().FindAll(order => ((order.GetIsDelivered() == true) && (order.GetIsCanceled() == false) && (order.GetDeliveryMan() == DeliveryMan)));
        }
        private int GetTotalOrdersFromDeliveryMan(DeliveryMan deliveryMan)
        {
            return this.GetOrdersFromDeliveryMan(deliveryMan).Count;
        }
        private float GetAveragePrice()
        {
            List<Order> orders =  pizzeria.getOrders().FindAll(order => ((order.GetIsDelivered() == true) && (order.GetIsCanceled() == false)));
            float totalPrice = 0;
            foreach (Order order in orders)
            {
                totalPrice += order.GetTotalPrice();
            }
            return totalPrice / orders.Count;
        }
        private float GetAveragePriceFromClient(Client client)
        {
            List<Order> orders = pizzeria.getOrders().FindAll(order => ((order.GetIsDelivered() == true) && (order.GetIsCanceled() == false) && (order.GetClient() == client)));
            float totalPrice = 0;
            foreach (Order order in orders)
            {
                totalPrice += order.GetTotalPrice();
            }
            return totalPrice / orders.Count;
        }
        private bool IsFirstOrder(String phoneNumber)
        {
            if (pizzeria.FindClientWithPhoneNumber(phoneNumber) == null)
            {
                return true;
            }
            else
                return false;
        }
        /*
         * Le Commis demande au client si c'est sa première commande. 
         * Si oui, le commis demande le numéro de téléphone et appelle AskClientPhoneNumber.
         * Il obtient l'adresse et demande confirmation au client. S'il faut changer l'adresse, le commis appelle SetClientAddress.
         * 
         * Si c'est la première commannde, le commis appelle la fonction AddNewClient.
         */
        private Address AskClientPhoneNumber(String phoneNumber)  
        {
            if (IsFirstOrder(phoneNumber)){
                Console.WriteLine("Le numéro de téléphone n'existe pas dans la base de donnée.");
                return null;
            }
            else
            {
                return pizzeria.FindClientWithPhoneNumber(phoneNumber).getAddress();
            }
        }
        
        
    private void SetClientAddress(String phoneNumber)
    {
        Address address = AskClientAddress();
        pizzeria.FindClientWithPhoneNumber(phoneNumber).setAddress(address);
    }
    private Address AskClientAddress() {             
                Console.WriteLine("Veuillez entrer le numéro de rue : ");
                String streetNumber = Console.ReadLine();
                Console.WriteLine("Veuillez entrer le nom de rue : ");
                String streetName = Console.ReadLine();
                Console.WriteLine("Veuillez entrer le code postal : ");
                String postalCode = Console.ReadLine();
                Console.WriteLine("Veuillez entrer la ville : ");
                String city = Console.ReadLine();
                Console.WriteLine("Veuillez entrer le pays : ");
                String country = Console.ReadLine();
        return new Address(streetNumber, streetName, city, postalCode, country);
    }
        private String AskClientPhoneNumber()
        {
            Console.WriteLine("Veuillez entrer le numéro de téléphone du client : ");
            String phoneNumber = Console.ReadLine();
            return phoneNumber;
        }
        private void AddNewClient()
        {
            Client client = AddClient();
            pizzeria.addClient(client);
        }
        private String AskClientFirstName()
        {
            Console.WriteLine("Veuillez entrer le prénom du client : ");
            String firstName = Console.ReadLine();
            return firstName;
        }
        private String AskClientLastName()
        {
            Console.WriteLine("Veuillez entrer le nom du client : ");
            String lastName = Console.ReadLine();
            return lastName;
        }
        private Client AddClient()
        {
            Address address = AskClientAddress();
            String firstName = AskClientFirstName();
            String lastName = AskClientLastName();
            String phoneNumber = AskClientPhoneNumber();
            DateTime firstOderDate = DateTime.Now;
            return new Client(firstName, lastName, phoneNumber, address.getStreetNumber(), address.getStreetName(), address.getCity(), address.getPostalCode(), address.getCountry(), firstOderDate) ;
        }
    }
}
