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

namespace ProjetAppPizzeria
{
    /// <summary>
    /// Logique d'interaction pour HelperPage4.xaml
    /// </summary>
    public partial class HelperPage4 : Page
    {
        private string number;
        public HelperPage4(string number)
        {
            InitializeComponent();
            this.number = number;
        }

/*        private void SetClientAddress(String phoneNumber)
        {
            Address address = AskClientAddress();
            //pizzeria.FindClientWithPhoneNumber(phoneNumber).setAddress(address);
        }*/
        private Address AskClientAddress()
        {
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
            ((MainWindow)Application.Current.MainWindow).GetPizzeria().addClient(client);
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
            String phoneNumber = number;
            DateTime firstOderDate = DateTime.Now;
            return new Client(firstName, lastName, phoneNumber, address.getStreetNumber(), address.getStreetName(), address.getCity(), address.getPostalCode(), address.getCountry(), firstOderDate);
        }
        private void ButtonDisconnect(object sender, RoutedEventArgs e)
        {
            HelperPage1 helperPage1 = new HelperPage1();
            NavigationService.Navigate(helperPage1);
        }
    }
}
