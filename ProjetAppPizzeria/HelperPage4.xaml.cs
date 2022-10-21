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
        private Helper h;
        internal HelperPage4(string number, Helper h)
        {
            InitializeComponent();
            this.number = number;
            this.h = h;
        }

/*        private void SetClientAddress(String phoneNumber)
        {
            Address address = AskClientAddress();
            //pizzeria.FindClientWithPhoneNumber(phoneNumber).setAddress(address);
        }*/
        private Address AskClientAddress()
        {
            String streetNumber = StreetNumber.Text;
            String streetName = StreetName.Text;
            String postalCode = PostalCode.Text;
            String city = City.Text;
            String country = Country.Text;
            return new Address(streetNumber, streetName, city, postalCode, country);
        }
        private String AskClientPhoneNumber()
        {
            Console.WriteLine("Veuillez entrer le numéro de téléphone du client : ");
            String phoneNumber = Console.ReadLine();
            return phoneNumber;
        }
        private void AddNewClient(object sender, RoutedEventArgs e)
        {
            Client client = AddClient();
            ((MainWindow)Application.Current.MainWindow).GetPizzeria().addClient(client);
            HelperPage3 helperPage3 = new HelperPage3(client, h);
            NavigationService.Navigate(helperPage3);
        }
        private String AskClientFirstName()
        {
            String firstName = Firstname.Text;
            return firstName;
        }
        private String AskClientLastName()
        {
            String lastName = Lastname.Text;
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
