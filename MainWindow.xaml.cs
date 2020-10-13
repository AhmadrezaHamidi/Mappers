using BookAndShelve.XmlFile;
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

namespace BookAndShelve
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ifoButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoginButton_Click_1(object sender, RoutedEventArgs e)
        {
            var Login = new Login();
            Login.Show();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            var Rgistr = new Register();
            Rgistr.Show();

        }
    }
}
