using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {// below code helps to open the resister page in the center of screen
            InitializeComponent();
            base.WindowStartupLocation = WindowStartupLocation.CenterScreen;

        }

        // Submit_Click() is used to submit the register data into the register tables from the textboxes.
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DHILLON\SQLEXPRESS;Initial Catalog=DbLogin;Integrated Security=True");
            try
            {
                SqlCommand command1 = new SqlCommand
                {
                    Connection = connection
                };
                string str = "Insert into Register(userid,password,fullname,age) Values(@userid, @password, @fullname, @age)";
                SqlParameter[] parameterArray = new SqlParameter[] { new SqlParameter("@userid", UserId_TextBox.Text), new SqlParameter("@password", Password_TextBox.Text), new SqlParameter("@fullname", FullName_TextBox.Text), new SqlParameter("@age", Age_TextBox.Text) };
                command1.Parameters.Add(parameterArray[0]);
                command1.Parameters.Add(parameterArray[1]);
                command1.Parameters.Add(parameterArray[2]);
                command1.Parameters.Add(parameterArray[3]);
                command1.CommandText = str;
                connection.Open();
                command1.ExecuteReader();
                // pop up message when your account successfully created
                MessageBox.Show("Data Inserted successfully");
                connection.Close();
                // to return back to the main window
                new MainWindow().Show();
                // below code is for close this page
                base.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Database Exception" + exception.Message);
                connection.Close();
            }
            new MainWindow().Show();
            base.Close();
        }

        private void Password_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Age_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
