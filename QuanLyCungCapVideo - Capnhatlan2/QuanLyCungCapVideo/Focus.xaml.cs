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
    /// Interaction logic for Focus.xaml
    /// </summary>
    public partial class Focus : Window
    {
        TimeSpan time;
        public TimeSpan Time;
        public Focus()
        {
            InitializeComponent();
            time = new TimeSpan();
        }
        public Focus(Model.VIDEO video, TimeSpan time)
        {
            InitializeComponent();
            Watch.SetMedia(video, time);
            Watch.BtnX();
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            time = Watch.GetTime();
            Watch.ClearVideo();
            this.DialogResult = true;
            this.Close();
        }
    }
}
