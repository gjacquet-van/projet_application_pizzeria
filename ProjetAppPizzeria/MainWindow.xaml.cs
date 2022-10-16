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
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Pizzeria pizzeria;

        public MainWindow()
        {
            pizzeria = new Pizzeria();
            Console.WriteLine(pizzeria);
            InitializeComponent();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddNewClient(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("helloworld");
        }
    }
}
