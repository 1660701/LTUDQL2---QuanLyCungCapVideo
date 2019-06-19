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
using QuanLyCungCapVideo.Model;

namespace QuanLyCungCapVideo
{
    /// <summary>
    /// Interaction logic for WdlistVideo.xaml
    /// </summary>
    public partial class WdlistVideo : Window
    {
        public WdlistVideo()
        {
            InitializeComponent();
            DataContext = new List<Videoinfo>
            {
                new Videoinfo{},
                new Videoinfo{},
                new Videoinfo{},
                new Videoinfo{},
                new Videoinfo{},
                new Videoinfo{},
                new Videoinfo{},
                new Videoinfo{},
                new Videoinfo{},
                new Videoinfo{},
                new Videoinfo{},
                new Videoinfo{},
                new Videoinfo{},
                new Videoinfo{},
                new Videoinfo{},
                new Videoinfo{},
                new Videoinfo{},
                new Videoinfo{},
                new Videoinfo{}
            };
        }
    }
}
