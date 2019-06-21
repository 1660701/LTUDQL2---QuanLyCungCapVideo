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

namespace QuanLyCungCapVideo
{
    /// <summary>
    /// Interaction logic for QuanLyTheLoai.xaml
    /// </summary>
    public partial class QuanLyTheLoai : Window
    {
        public QuanLyTheLoai()
        {
            InitializeComponent();
        }

        private void Tbyn_Checked(object sender, RoutedEventArgs e)
        {
            btndel.IsEnabled = true;
        }

        private void Tbyn_Unchecked(object sender, RoutedEventArgs e)
        {
            btndel.IsEnabled = false;
        }
    }
}
