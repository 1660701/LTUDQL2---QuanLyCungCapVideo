using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
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

        private void Main_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                Grid gr = (Grid)sender;
                var video =gr.Tag as VIDEO;
                child.Sender(video);
                //MessageBox.Show(video.LinkVideo);
            }
            catch
            {

            }
        
        }


       // int timebegin = 3000;
        bool isEnter = false;
        private void Main_MouseEnter(object sender, MouseEventArgs e)
        {
            var gr = sender as Grid;
            var me = gr.FindName("mediaplay") as MediaElement;
            me.Visibility = Visibility.Visible;



            int timebegin ;


            if (isEnter)
            {
                timebegin = 1000;
            }
            try
            {
                me?.Play();
                me.Volume = 0;
            }
            catch { }

            var sxDA = new DoubleAnimation();
            sxDA.To = 1.6;
            sxDA.BeginTime = TimeSpan.FromMilliseconds(500);
            sxDA.Duration = TimeSpan.FromMilliseconds(300);
            Storyboard.SetTarget(sxDA, gr);
            Storyboard.SetTargetProperty(sxDA, new PropertyPath("LayoutTransform.ScaleX"));

            var syDA = new DoubleAnimation();
            syDA.To = 1.6;
            syDA.BeginTime = TimeSpan.FromMilliseconds(500);
            syDA.Duration = TimeSpan.FromMilliseconds(300);
            Storyboard.SetTarget(syDA, gr);
            Storyboard.SetTargetProperty(syDA, new PropertyPath("LayoutTransform.ScaleY"));

            var sb = new Storyboard();
            sb.Children.Add(sxDA);
            sb.Children.Add(syDA);

            sb.Begin();
        }

        private void Main_MouseLeave(object sender, MouseEventArgs e)
        {
            var gr = sender as Grid;
            var me = gr.FindName("mediaplay") as MediaElement;
            me.Visibility = Visibility.Collapsed;
            try
            {
                me?.Stop();
            }
            catch
            {

            }

            var sxDA = new DoubleAnimation();
            sxDA.Duration = TimeSpan.FromMilliseconds(300);
            Storyboard.SetTarget(sxDA, gr);
            Storyboard.SetTargetProperty(sxDA, new PropertyPath("LayoutTransform.ScaleX"));

            var syDA = new DoubleAnimation();
            syDA.Duration = TimeSpan.FromMilliseconds(300);
            Storyboard.SetTarget(syDA, gr);
            Storyboard.SetTargetProperty(syDA, new PropertyPath("LayoutTransform.ScaleY"));

            var sb = new Storyboard();
            sb.Children.Add(sxDA);
            sb.Children.Add(syDA);
            sb.Begin();
        }


        private void Btnchon_Click(object sender, RoutedEventArgs e)
        {
            Login loginWindow = new Login();
            if (loginWindow.DataContext == null)
                return;
            var LoginVM = loginWindow.DataContext as LoginViewModel;
            Button btn = (Button)sender;
            var video = btn.Tag as VIDEO;
            var yt = DataProvider.Ins.DB.YEUTHICHes.Where(x => x.LinkVideo == video.LinkVideo && x.TenND == LoginVM.UserName && x.LinkPoster == video.LinkPoster ).Count();
            if (yt > 0)
            {
                MessageBox.Show("Video đã có trong danh sách yêu thích của bạn!");
            }
            else
            {
                try
                {
                    var yeuthich = new YEUTHICH() { LinkPoster = video.LinkPoster, LinkVideo = video.LinkVideo, TenND = LoginVM.UserName, DaoDien = video.DaoDien, LuotXem = video.LuotXem, QuocGia = video.QuocGia, TenVideo = video.TenVideo, TomTat = video.TomTat };
                    DataProvider.Ins.DB.YEUTHICHes.Add(yeuthich);
                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Thêm vào danh sách yêu thích!");
                }
                catch
                {

                }
                
                
            }
            
        }



      
    }
}
