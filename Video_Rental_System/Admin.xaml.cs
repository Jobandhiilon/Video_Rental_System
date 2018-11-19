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
            this.DG_Customer.ItemsSource = this.Obj_Customer.LoadCustomerData().DefaultView;
        }

        private void Tab_Video_Loaded(object sender, RoutedEventArgs e)
        {
            this.VideoDG.ItemsSource = this.Obj_video.LoadvideoData().DefaultView;
        }

        private void Update_Customer_Click(object sender, RoutedEventArgs e)
        {
            string text = this.FirstName_TextBox.Text;
            this.Obj_Customer.Update_Customer(this.CustomerID, text, this.LastName_TextBox.Text, this.Address_TextBox.Text, Convert.ToInt32(this.Phone_TextBox.Text));
            MessageBox.Show("Customer Updated");
            this.DG_Customer.ItemsSource = this.Obj_Customer.LoadCustomerData().DefaultView;
            this.FirstName_TextBox.Text = "";
            this.LastName_TextBox.Text = "";
            this.Address_TextBox.Text = "";
            this.Phone_TextBox.Text = "";
        }

        private void Update_Video_Click(object sender, RoutedEventArgs e)
        {
            string text = this.Rating_TextBox.Text;
            this.Obj_video.Update_video(this.MovieID, text, this.Title_TextBox.Text, this.Year_TextBox.Text, Convert.ToInt32(this.Rental_Cost_TextBox.Text), this.Copies_TextBox.Text, this.Plot_TextBox.Text, this.Genre_TextBox.Text);
            MessageBox.Show("Movie Updated");
            this.VideoDG.ItemsSource = this.Obj_video.LoadvideoData().DefaultView;
            this.Rating_TextBox.Text = "";
            this.Title_TextBox.Text = "";
            this.Year_TextBox.Text = "";
            this.Rental_Cost_TextBox.Text = "";
            this.Copies_TextBox.Text = "";
            this.Plot_TextBox.Text = "";
            this.Genre_TextBox.Text = "";
        }

        private void SelectCustomerRow(object sender, MouseButtonEventArgs e)
        {
            DataRowView view = (DataRowView)this.DG_Customer.SelectedItems[0];
            this.CustomerID = Convert.ToInt32(view["CustID"]);
            this.FirstName_TextBox.Text = Convert.ToString(view["FirstName"]);
            this.LastName_TextBox.Text = Convert.ToString(view["LastName"]);
            this.Address_TextBox.Text = Convert.ToString(view["Address"]);
            this.Phone_TextBox.Text = Convert.ToString(view["Phone"]);
            this.DG_Customer.ItemsSource = this.Obj_Customer.LoadCustomerData().DefaultView;
        }

        private void SelectVideoRow(object sender, MouseButtonEventArgs e)
        {
            DataRowView view = (DataRowView)this.VideoDG.SelectedItems[0];
            this.MovieID = Convert.ToInt32(view["MovieID"]);
            this.Rating_TextBox.Text = Convert.ToString(view["Rating"]);
            this.Title_TextBox.Text = Convert.ToString(view["Title"]);
            this.Year_TextBox.Text = Convert.ToString(view["Year"]);
            this.Rental_Cost_TextBox.Text = Convert.ToString(view["Rental_Cost"]);
            this.Copies_TextBox.Text = Convert.ToString(view["Copies"]);
            this.Plot_TextBox.Text = Convert.ToString(view["Copies"]);
            this.Genre_TextBox.Text = Convert.ToString(view["Genre"]);
            this.VideoDG.ItemsSource = this.Obj_video.LoadvideoData().DefaultView;
        }

        private void Delete_Customer_Click(object sender, RoutedEventArgs e)
        {
            int customerID = this.CustomerID;
            if (MessageBox.Show("Are you sure you want to delete the User?", "User", MessageBoxButton.YesNo).ToString() == "Yes")
            {
                this.Obj_Customer.Delete_Customer(this.CustomerID);
                MessageBox.Show("User Deleted");
                this.DG_Customer.ItemsSource = this.Obj_Customer.LoadCustomerData().DefaultView;
                this.FirstName_TextBox.Text = "";
                this.LastName_TextBox.Text = "";
                this.Address_TextBox.Text = "";
                this.Phone_TextBox.Text = "";
            }
        }

        private void Delete_Video_Click(object sender, RoutedEventArgs e)
        {
            int movieID = this.MovieID;
            if (MessageBox.Show("Are you sure you want to delete the Video?", "User", MessageBoxButton.YesNo).ToString() == "Yes")
            {
                this.Obj_video.Delete_video(this.MovieID);
                MessageBox.Show("Video Deleted");
                this.VideoDG.ItemsSource = this.Obj_video.LoadvideoData().DefaultView;
                this.Rating_TextBox.Text = "";
                this.Title_TextBox.Text = "";
                this.Year_TextBox.Text = "";
                this.Rental_Cost_TextBox.Text = "";
                this.Copies_TextBox.Text = "";
                this.Plot_TextBox.Text = "";
                this.Genre_TextBox.Text = "";
            }
        }
        private void Add_Customer_Click(object sender, RoutedEventArgs e)
        {
            if (((this.FirstName_TextBox.Text != "") && ((this.LastName_TextBox.Text != "") && (this.Address_TextBox.Text != ""))) && (this.Phone_TextBox.Text != ""))
            {
                this.Obj_Customer.Add_Customer(this.FirstName_TextBox.Text, this.LastName_TextBox.Text, this.Address_TextBox.Text, this.Phone_TextBox.Text);
                this.DG_Customer.ItemsSource = this.Obj_Customer.LoadCustomerData().DefaultView;
                this.FirstName_TextBox.Text = "";
                this.LastName_TextBox.Text = "";
                this.Address_TextBox.Text = "";
                this.Phone_TextBox.Text = "";
            }
        }

        private void Add_Video_Click(object sender, RoutedEventArgs e)
        {
            if (((this.Rating_TextBox.Text != "") && ((this.Title_TextBox.Text != "") && ((this.Year_TextBox.Text != "") && ((this.Rental_Cost_TextBox.Text != "") && ((this.Copies_TextBox.Text != "") && (this.Plot_TextBox.Text != "")))))) && (this.Genre_TextBox.Text != ""))
            {
                this.Obj_video.Add_video(this.Rating_TextBox.Text, this.Title_TextBox.Text, this.Year_TextBox.Text, this.Rental_Cost_TextBox.Text, this.Copies_TextBox.Text, this.Plot_TextBox.Text, this.Genre_TextBox.Text);
                this.VideoDG.ItemsSource = this.Obj_video.LoadvideoData().DefaultView;
                this.Rating_TextBox.Text = "";
                this.Title_TextBox.Text = "";
                this.Year_TextBox.Text = "";
                this.Rental_Cost_TextBox.Text = "";
                this.Copies_TextBox.Text = "";
                this.Plot_TextBox.Text = "";
                this.Genre_TextBox.Text = "";
            }
        }


    }
}
