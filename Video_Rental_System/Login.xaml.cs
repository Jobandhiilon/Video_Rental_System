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
using System.Windows.Shapes;

namespace Video_Rental_System
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        User_Login obj_login = new User_Login();
        public Login()
        {
            InitializeComponent();
            base.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            int userid = Convert.ToInt32(TxtBox_UserName.Text);
            if (this.obj_login.User_Log_method(userid, TxtBox_Password.Text))
            {
                MessageBox.Show("Login Successful");
                new Admin().ShowDialog();
                base.Close();
            }
            else
            {
                MessageBox.Show("Invalid User Name or Password");
                new Login().Show();
                base.Close();
            }
        }

    }
}
