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
using System.Data;
namespace Video_Rental_System
{
    /// <summary>
    /// Interaction logic for frmMovieRanking.xaml
    /// </summary>
    public partial class MovieRate : Window
    {
        public MovieRate()
        {
            InitializeComponent();
        }
        Video Obj_video = new Video();

        private void DgVideo_Loaded(object sender, RoutedEventArgs e)
        {
            dgVideo.ItemsSource = Obj_video.LoadMovieRankData().DefaultView;
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new Admin().ShowDialog();
        }

        private void dgVideo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
