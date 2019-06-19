using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuanLyCungCapVideo.Model
{
    public class Videoinfo : DependencyObject 
    {
        public static readonly DependencyProperty TitleProperty;
        public static readonly DependencyProperty PathProperty;
        public static readonly DependencyProperty DecriptionProperty;
        static Videoinfo()
        {
            TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(Videoinfo), new PropertyMetadata("New Video"));
            TitleProperty = DependencyProperty.Register("Path", typeof(string), typeof(Videoinfo), new PropertyMetadata(@"H:\zzzVideo\nes.mp4"));
            TitleProperty = DependencyProperty.Register("Decription", typeof(string), typeof(Videoinfo), new PropertyMetadata(@"New secription"));
        }
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        public string Path
        {
            get { return (string)GetValue(PathProperty); }
            set { SetValue(PathProperty, value); }
        }
        public string Decription
        {
            get { return (string)GetValue(DecriptionProperty); }
            set { SetValue(DecriptionProperty, value); }
        }
    }
}
