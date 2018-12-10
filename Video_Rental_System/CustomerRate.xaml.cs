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
    /// Interaction logic for frmCustomerRatting.xaml
    /// </summary>
    public partial class CustomerRate : Window
    {
        public CustomerRate()
        {
            InitializeComponent();
        }
        Video Obj_video = new Video();

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

            dg.ItemsSource = Obj_video.LoadCustomerRankData().DefaultView;

        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new Admin().ShowDialog();

        }

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
