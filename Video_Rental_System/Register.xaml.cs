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
        {
            InitializeComponent();
            base.WindowStartupLocation = WindowStartupLocation.CenterScreen;

        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DHILLON\SQLEXPRESS01;Initial Catalog=LoginDB;Integrated Security=True");
            try
            {
                SqlCommand command1 = new SqlCommand
                {
                    Connection = connection
                };
                string str = "Insert into Customer(userid,password,fullname,age) Values(@userid, @password, @fullname, @age)";
                SqlParameter[] parameterArray = new SqlParameter[] { new SqlParameter("@userid", this.UserId_TextBox.Text), new SqlParameter("@password", this.Password_TextBox.Text), new SqlParameter("@fullname", this.FullName_TextBox.Text), new SqlParameter("@age", this.Age_TextBox.Text) };
                command1.Parameters.Add(parameterArray[0]);
                command1.Parameters.Add(parameterArray[1]);
                command1.Parameters.Add(parameterArray[2]);
                command1.CommandText = str;
                connection.Open();
                command1.ExecuteReader();
                MessageBox.Show("Data Inserted successfully");
                connection.Close();
                new MainWindow().Show();
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


    }
}
