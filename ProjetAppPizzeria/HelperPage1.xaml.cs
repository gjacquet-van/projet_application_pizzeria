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
    /// Logique d'interaction pour HelperPage1.xaml
    /// </summary>
    public partial class HelperPage1 : Page
    {
        public HelperPage1()
        {
            InitializeComponent();
            SelectHelper.ItemsSource = ((MainWindow)Application.Current.MainWindow).GetPizzeria().GetHelpersEnum();
        }

        private void Connect(object sender, RoutedEventArgs e)
        {
            Helper h = (Helper)SelectHelper.SelectedItem;
            HelperPage2 helperPage2 = new HelperPage2(h);
            NavigationService.Navigate(helperPage2);
        }
    }
}
