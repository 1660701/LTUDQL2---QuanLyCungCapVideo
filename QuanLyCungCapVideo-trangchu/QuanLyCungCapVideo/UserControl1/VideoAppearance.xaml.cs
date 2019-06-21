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
using System.Windows.Media.Animation;
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
        MainWindow child;

        public VideoAppearance()
        {

            InitializeComponent();
            list = new ObservableCollection<VIDEO>();
            DataContext = list;
            
        }

        public VideoAppearance(MainWindow frm)
        {

            InitializeComponent();
            list = new ObservableCollection<VIDEO>();
            DataContext = list;
            child = frm;

        }

        private void Main_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {
                Grid gr = (Grid)sender;
                var video =gr.Tag as VIDEO;
                child.Sender(video);
            }
            catch
            {

            }
        
        }
    }
}
