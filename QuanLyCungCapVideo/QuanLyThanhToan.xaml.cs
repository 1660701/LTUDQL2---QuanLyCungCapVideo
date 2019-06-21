using QuanLyCungCapVideo.Model;
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
    /// Interaction logic for QuanLyThanhToan.xaml
    /// </summary>
    public partial class QuanLyThanhToan : Window
    {
        public QuanLyThanhToan()
        {
            InitializeComponent();
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lv.ItemsSource);
            view.Filter = TTFilter;
        }

        private bool TTFilter(object item)
        {
            if (string.IsNullOrEmpty(txtloc.Text))
            {
                return true;
            }
            else
                return ((item as THANHTOAN).TenND.IndexOf(txtloc.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void Txtloc_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lv.ItemsSource).Refresh();
        }
    }
}
