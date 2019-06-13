using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using QuanLyCungCapVideo.Model;
using QuanLyCungCapVideo.ViewModel;

namespace QuanLyCungCapVideo.UserControl1
{
    /// <summary>
    /// Interaction logic for VideoAppearance.xaml
    /// </summary>
    public partial class VideoAppearance : UserControl
    {

        private ObservableCollection<VIDEO> list;
        public ObservableCollection<VIDEO> List { get => list; set { list = value; DataContext = list; } }
        //VideoAppearanceViewModel vmd = new VideoAppearanceViewModel();

        public VideoAppearance()
        {
            InitializeComponent();
            list = new ObservableCollection<VIDEO>();
            DataContext = list;
            //DataContext = vmd.List;
        }       
        

    }
}
