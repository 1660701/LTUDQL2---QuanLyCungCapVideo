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
using QuanLyCungCapVideo.UserControl1;
using QuanLyCungCapVideo.ViewModel;
namespace QuanLyCungCapVideo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        VideoAppearanceViewModel vmd = new VideoAppearanceViewModel();
        public delegate void send(VIDEO video);
        public send Sender;
        VideoPlay videoplay;
        public MainWindow()
        {
            InitializeComponent();
            foreach(var x in vmd.List)
            {
                st.Children.Add(new TextBlock() { Text = x.TheLoai, FontSize = 30, Foreground = new SolidColorBrush(Colors.White), Margin = new Thickness(30) });
               st.Children.Add(new VideoAppearance(this) { List = x.Videos });
                
            }
           
            Sender = new send(GetVieo);
            videoplay = new VideoPlay();
            
        }

        private void GetVieo(VIDEO video)
        {
            st.Children.Clear();
            videoplay.SetVideo(video);
            st.Children.Add(videoplay);
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            videoplay.ClearVideo();
            st.Children.Clear();
            foreach (var x in vmd.List)
            {
                st.Children.Add(new TextBlock() { Text = x.TheLoai, FontSize = 30, Foreground = new SolidColorBrush(Colors.White), Margin = new Thickness(30) });
                st.Children.Add(new VideoAppearance(this) { List = x.Videos });

            }
        }
    }
}
