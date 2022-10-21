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
    /// Logique d'interaction pour HelperPage2.xaml
    /// </summary>
    public partial class HelperPage2 : Page
    {
        private Helper h;
        private string number;
        internal HelperPage2(Helper h)
        {
            InitializeComponent();
            this.h = h;
            Helper test = GetHelperPage2();
            Console.WriteLine(test);
        }
        private void ButtonDisconnect(object sender, RoutedEventArgs e)
        {
            HelperPage1 helperPage1 = new HelperPage1();
            NavigationService.Navigate(helperPage1);
        }
        internal Helper GetHelperPage2()
        {
            return h;
        }

        private void ButtonFindClient(object sender, RoutedEventArgs e)
        {
            Client c = ((MainWindow)Application.Current.MainWindow).GetPizzeria().getClients().Find(x => x.getPhoneNumber() == number);
            if (c != null)
            {
                HelperPage3 helperPage3 = new HelperPage3(c);
                NavigationService.Navigate(helperPage3);
            }
            else
            {
                HelperPage4 helperPage4 = new HelperPage4(number);
                NavigationService.Navigate(helperPage4);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            number = NumberClient.Text;
            Console.WriteLine(number);
        }
    }
}
