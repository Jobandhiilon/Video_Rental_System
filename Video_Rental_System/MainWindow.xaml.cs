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

namespace Video_Rental_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //below code is to open our project in the center of screen.
            InitializeComponent();
            base.WindowStartupLocation = WindowStartupLocation.CenterScreen;

        }
        //login button coding
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            // To open the login page
            new Login().Show();
            //close this window
            base.Close();
        }
        // Register button coding
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            // to open the register page
            new Register().Show();
            // for close this window
            base.Close();
        }


    }
}
