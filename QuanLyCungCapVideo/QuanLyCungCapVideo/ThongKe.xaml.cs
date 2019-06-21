using LiveCharts;
using LiveCharts.Wpf;
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
    /// Interaction logic for ThongKe.xaml
    /// </summary>
    public partial class ThongKe : Window
    {
        public ThongKe()
        {
            InitializeComponent();
        }
     public String[] Labels  => new [] { "jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "oct", "Nov", "Dec" };

     public   SeriesCollection SeriesCollection => new SeriesCollection
        {
            new LineSeries
            {
                Values = new ChartValues<double> { 4, 2, 1, 6, 5, 3, 2, 8, 9, 6, 3, 12 },
                Stroke = Brushes.Red,
                Fill = Brushes.Blue,
                Title =" xem Nhiều nhất "
        },
            new ColumnSeries                
            {
                Values = new ChartValues<decimal> {  2, 4, 2, 3, 5, 6, 2, 9, 4, 7, 4, 6 },
                Stroke = Brushes.Green,
                Fill = Brushes.Yellow,
                StrokeThickness = 3 ,
                Title = " Doanh Thu (triệu) "
            }
        };
     private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = this;
        }
    }
}
