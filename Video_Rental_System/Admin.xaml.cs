using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        // Fields
        Customer_Data Obj_Customer = new Customer_Data();
        Video Obj_video = new Video();
        public int CustomerID;
        public int MovieID;

        public Admin()
        {
            
            this.InitializeComponent();
            base.WindowStartupLocation = WindowStartupLocation.CenterScreen;

        }

        private void Tab_Customer_Loaded(object sender, RoutedEventArgs e)
        {
            DG_Customer.ItemsSource = Obj_Customer.LoadCustomerData().DefaultView;
        }

        private void Tab_Video_Loaded(object sender, RoutedEventArgs e)
        {
          VideoDG.ItemsSource = Obj_video.LoadvideoData().DefaultView;
        }

        private void Update_Customer_Click(object sender, RoutedEventArgs e)
        {
            string text = FirstName_TextBox.Text;
            Obj_Customer.Update_Customer(CustomerID,FirstName_TextBox.Text, LastName_TextBox.Text, Address_TextBox.Text, Convert.ToInt32(Phone_TextBox.Text));
            MessageBox.Show("Customer Updated");
            DG_Customer.ItemsSource = Obj_Customer.LoadCustomerData().DefaultView;
            FirstName_TextBox.Text = "";
            LastName_TextBox.Text = "";
            Address_TextBox.Text = "";
            Phone_TextBox.Text = "";
        }

        private void Update_Video_Click(object sender, RoutedEventArgs e)
        {
            int rent = Convert.ToInt32(Rental_Cost_TextBox.Text);
            Obj_video.Update_video(MovieID,Rating_TextBox.Text, Title_TextBox.Text, Year_TextBox.Text, rent, Copies_TextBox.Text,Plot_TextBox.Text,Genre_TextBox.Text);
            MessageBox.Show("Movie Updated");
            VideoDG.ItemsSource = Obj_video.LoadvideoData().DefaultView;
            Rating_TextBox.Text = "";
            Title_TextBox.Text = "";
            Year_TextBox.Text = "";
            Rental_Cost_TextBox.Text = "";
            Copies_TextBox.Text = "";
            Plot_TextBox.Text = "";
            Genre_TextBox.Text = "";
        }

        private void SelectCustomerRow(object sender, MouseButtonEventArgs e)
        {
            DataRowView view = (DataRowView)DG_Customer.SelectedItems[0];
            CustomerID = Convert.ToInt32(view["CustID"]);
            FirstName_TextBox.Text = Convert.ToString(view["FirstName"]);
            LastName_TextBox.Text = Convert.ToString(view["LastName"]);
            Address_TextBox.Text = Convert.ToString(view["Address"]);
            Phone_TextBox.Text = Convert.ToString(view["Phone"]);
            DG_Customer.ItemsSource = Obj_Customer.LoadCustomerData().DefaultView;
        }

        private void SelectVideoRow(object sender, MouseButtonEventArgs e)
        {
            DataRowView view = (DataRowView)VideoDG.SelectedItems[0];
            MovieID = Convert.ToInt32(view["MovieID"]);
            Rating_TextBox.Text = Convert.ToString(view["Rating"]);
            Title_TextBox.Text = Convert.ToString(view["Title"]);
            Year_TextBox.Text = Convert.ToString(view["Year"]);
            Rental_Cost_TextBox.Text = Convert.ToString(view["Rental_Cost"]);
            Copies_TextBox.Text = Convert.ToString(view["Copies"]);
            Plot_TextBox.Text = Convert.ToString(view["Copies"]);
            Genre_TextBox.Text = Convert.ToString(view["Genre"]);
            VideoDG.ItemsSource = Obj_video.LoadvideoData().DefaultView;
        }

        private void Delete_Customer_Click(object sender, RoutedEventArgs e)
        {
            int customerID = CustomerID;
            if (MessageBox.Show("Are you sure you want to delete the User?", "User", MessageBoxButton.YesNo).ToString() == "Yes")
            {
                Obj_Customer.Delete_Customer(CustomerID);
                MessageBox.Show("User Deleted");
                DG_Customer.ItemsSource = Obj_Customer.LoadCustomerData().DefaultView;
                FirstName_TextBox.Text = "";
                LastName_TextBox.Text = "";
                Address_TextBox.Text = "";
                Phone_TextBox.Text = "";
            }
        }

        private void Delete_Video_Click(object sender, RoutedEventArgs e)
        {
            int movieID = MovieID;
            if (MessageBox.Show("Are you sure you want to delete the Video?", "User", MessageBoxButton.YesNo).ToString() == "Yes")
            {
                Obj_video.Delete_video(MovieID);
                MessageBox.Show("Video Deleted");
                VideoDG.ItemsSource = Obj_video.LoadvideoData().DefaultView;
                Rating_TextBox.Text = "";
                Title_TextBox.Text = "";
                Year_TextBox.Text = "";
                Rental_Cost_TextBox.Text = "";
                Copies_TextBox.Text = "";
                Plot_TextBox.Text = "";
                Genre_TextBox.Text = "";
            }
        }
        private void Add_Customer_Click(object sender, RoutedEventArgs e)
        {
            if (((FirstName_TextBox.Text != "") && ((LastName_TextBox.Text != "") && (Address_TextBox.Text != ""))) && Phone_TextBox.Text != "")
            {
                Obj_Customer.Add_Customer(FirstName_TextBox.Text, LastName_TextBox.Text, Address_TextBox.Text, Phone_TextBox.Text);
                DG_Customer.ItemsSource = Obj_Customer.LoadCustomerData().DefaultView;
                FirstName_TextBox.Text = "";
                LastName_TextBox.Text = "";
                Address_TextBox.Text = "";
                Phone_TextBox.Text = "";
            }
        }

       
        private void Add_Video_Click(object sender, RoutedEventArgs e)
        {
            if (((Rating_TextBox.Text != "") && ((Title_TextBox.Text != "") && ((Year_TextBox.Text != "") && ((Rental_Cost_TextBox.Text != "") && ((Copies_TextBox.Text != "") && (Plot_TextBox.Text != "")))))) && (Genre_TextBox.Text != ""))
            {
                Obj_video.Add_video(Rating_TextBox.Text, Title_TextBox.Text, Year_TextBox.Text, Rental_Cost_TextBox.Text, Copies_TextBox.Text, Plot_TextBox.Text, Genre_TextBox.Text);
                VideoDG.ItemsSource = Obj_video.LoadvideoData().DefaultView;
                Rating_TextBox.Text = "";
                Title_TextBox.Text = "";
                Year_TextBox.Text = "";
                Rental_Cost_TextBox.Text = "";
                Copies_TextBox.Text = "";
                Plot_TextBox.Text = "";
                Genre_TextBox.Text = "";
            }
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            base.Close();
        }

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            base.Close();

        }
    }
}
