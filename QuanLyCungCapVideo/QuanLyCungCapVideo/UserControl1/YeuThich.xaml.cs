using QuanLyCungCapVideo.Model;
using QuanLyCungCapVideo.ViewModel;
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

namespace QuanLyCungCapVideo.UserControl1
{
    /// <summary>
    /// Interaction logic for YeuThich.xaml
    /// </summary>
    public partial class YeuThich : UserControl
    {
        private ObservableCollection<YEUTHICH> list;
        public ObservableCollection<YEUTHICH> List { get => list; set { list = value; DataContext = list; } }
        //public ObservableCollection<YEUTHICH> list;
        MainWindow child;
        public void SetChild(MainWindow frm)
        {
            child = frm;
        }

        public YeuThich()
        {
            InitializeComponent();
            list = new ObservableCollection<YEUTHICH>();
            DataContext = list;
        }

        public YeuThich(MainWindow frm)
        {
            child = frm;
            InitializeComponent();
            list = new ObservableCollection<YEUTHICH>();
            DataContext = list;
        }

        public YeuThich(ObservableCollection<YEUTHICH> Lst)
        {

            InitializeComponent();
            list = new ObservableCollection<YEUTHICH>();
            list = Lst;
            DataContext = list;


        }

        private void Main_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {
                Grid gr = (Grid)sender;
                var yeuthich = gr.Tag as YEUTHICH;
                child.SenderYT(yeuthich);
                //MessageBox.Show(video.LinkVideo);
            }
            catch
            {

            }

        }

        private void Btnbochon_Click(object sender, RoutedEventArgs e)
        {
            Login loginWindow = new Login();
            if (loginWindow.DataContext == null)
                return;
            var LoginVM = loginWindow.DataContext as LoginViewModel;
            Button btn = (Button)sender;
            var video = btn.Tag as YEUTHICH;

            var ktyt = DataProvider.Ins.DB.YEUTHICHes.Where(x => x.LinkVideo == video.LinkVideo && x.TenND == LoginVM.UserName && x.LinkPoster == video.LinkPoster).Count();
            if (ktyt > 0)
            {
                var yt = DataProvider.Ins.DB.YEUTHICHes.Where(x => x.LinkVideo == video.LinkVideo && x.TenND == LoginVM.UserName && x.LinkPoster == video.LinkPoster).SingleOrDefault();
                DataProvider.Ins.DB.YEUTHICHes.Remove(yt);
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Xóa khỏi danh sách yêu thích!");

            }
            else
            {
                MessageBox.Show("Video không có trong danh sách yêu thích của bạn!");
            }

        }
    }
}
