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
using System.Windows.Navigation;
using System.Windows.Shapes;
using QuanLyCungCapVideo.Model;

namespace QuanLyCungCapVideo.UserControl1
{
    /// <summary>
    /// Interaction logic for FilmInfo.xaml
    /// </summary>
    public partial class FilmInfo : UserControl
    {
        VIDEO filminfo;
        public FilmInfo()
        {
            InitializeComponent();

            filminfo = new VIDEO();
        }
        MainWindow Child;
        public FilmInfo(MainWindow frm)
        {
            InitializeComponent();
            Child = frm;
            filminfo = new VIDEO();
        }
        public void SetInfo(VIDEO video)
        {
            //filminfo = video;
            //DataContext = filminfo;
            txtten.Text = video.TenVideo;
            txtquocgia.Text = video.QuocGia;
            txtdaodien.Text = video.DaoDien;
            txttomtat.Text = video.TomTat;
            txtluotxem.Text = video.LuotXem.ToString();
            imgposter.Source = new BitmapImage(new Uri(video.LinkPoster));
        }

        public void SetInfoYT(YEUTHICH video)
        {
            //filminfo = video;
            //DataContext = filminfo;
            txtten.Text = video.TenVideo;
            txtquocgia.Text = video.QuocGia;
            txtdaodien.Text = video.DaoDien;
            txttomtat.Text = video.TomTat;
            txtluotxem.Text = video.LuotXem.ToString();
            imgposter.Source = new BitmapImage(new Uri(video.LinkPoster));
        }
        //private void BtnXP_Click(object sender, RoutedEventArgs e)
        //{
        //    Child.SenderFI(filminfo);
        //}
    }
}
