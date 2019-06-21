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
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void Btnthoat_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow.Close();
            Login lg = new Login();
            lg.Show();
        }

        //private void QLTK_Click(object sender, RoutedEventArgs e)
        //{
        //    gridHeChucNang.Children.Clear();
        //    var qltk = new AccountManagement();
        //    gridHeChucNang.Children.Add(qltk);
        //}

        //private void QLV_Click(object sender, RoutedEventArgs e)
        //{
        //    gridHeChucNang.Children.Clear();
        //    var qlv = new QuanLyVideo();
        //    gridHeChucNang.Children.Add(qlv);

        //}

        //private void QLTL_Click(object sender, RoutedEventArgs e)
        //{
        //    gridHeChucNang.Children.Clear();
        //    var qltl = new QuanLyTheLoai();
        //    gridHeChucNang.Children.Add(qltl);
        //}

        //private void LSTT_Click(object sender, RoutedEventArgs e)
        //{
        //    gridHeChucNang.Children.Clear();
        //    var qltk = new AccountManagement();
        //    gridHeChucNang.Children.Add(qltk);
        //}
    }
}
