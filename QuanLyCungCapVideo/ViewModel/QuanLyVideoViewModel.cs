using QuanLyCungCapVideo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyCungCapVideo.ViewModel
{
    class QuanLyVideoViewModel : BaseViewModel
    {
        private ObservableCollection<VIDEO> _List;
        public ObservableCollection<VIDEO> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private ObservableCollection<THELOAI> _IDTL;
        public ObservableCollection<THELOAI> IDTL { get => _IDTL; set { _IDTL = value; OnPropertyChanged(); } }

        private THELOAI _SelectedIDTL;
        public THELOAI SelectedIDTL
        {
            get => _SelectedIDTL;
            set
            {
                _SelectedIDTL = value;
                OnPropertyChanged();
            }
        }

        private VIDEO _SelectedItem;
        public VIDEO SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    IDVideo = SelectedItem.IDVideo;
                    TenVideo = SelectedItem.TenVideo;
                    QuocGia = SelectedItem.QuocGia;
                    DaoDien = SelectedItem.DaoDien;
                    TomTat = SelectedItem.TomTat;
                    LuotXem = SelectedItem.LuotXem;
                    LinkVideo = SelectedItem.LinkVideo;
                    LinkPoster = SelectedItem.LinkPoster;
                    Trailer = SelectedItem.Trailer;
                    SelectedIDTL = SelectedItem.THELOAI;
                }
            }
        }

        private int _IDVideo;
        public int IDVideo { get => _IDVideo; set { _IDVideo = value; OnPropertyChanged(); } }

        //private int _IDTL;
        //public int IDTL { get => _IDTL; set { _IDTL = value; OnPropertyChanged(); } }

        private string _TenVideo;
        public string TenVideo { get => _TenVideo; set { _TenVideo = value; OnPropertyChanged(); } }

        private string _QuocGia;
        public string QuocGia { get => _QuocGia; set { _QuocGia = value; OnPropertyChanged(); } }

        private string _DaoDien;
        public string DaoDien { get => _DaoDien; set { _DaoDien = value; OnPropertyChanged(); } }

        private string _TomTat;
        public string TomTat { get => _TomTat; set { _TomTat = value; OnPropertyChanged(); } }

        private int _LuotXem;
        public int LuotXem { get => _LuotXem; set { _LuotXem = value; OnPropertyChanged(); } }

        private string _LinkVideo;
        public string LinkVideo { get => _LinkVideo; set { _LinkVideo = value; OnPropertyChanged(); } }

        private string _LinkPoster;
        public string LinkPoster { get => _LinkPoster; set { _LinkPoster = value; OnPropertyChanged(); } }

        private string _Trailer;
        public string Trailer { get => _Trailer; set { _Trailer = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand LVCommand { get; set; }
        public ICommand LPCommand { get; set; }
        public ICommand LTCommand { get; set; }



        public QuanLyVideoViewModel()
        {
            List = new ObservableCollection<VIDEO>(DataProvider.Ins.DB.VIDEOs);
            IDTL = new ObservableCollection<THELOAI>(DataProvider.Ins.DB.THELOAIs);

            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;

            }, (p) =>
            {
                var v = new VIDEO() { TenVideo = TenVideo, IDTL = SelectedIDTL.IDTL, QuocGia = QuocGia, TomTat = TomTat, DaoDien = DaoDien, LuotXem = LuotXem, LinkVideo = LinkVideo, LinkPoster = LinkPoster, Trailer = Trailer };

                DataProvider.Ins.DB.VIDEOs.Add(v);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(v);
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.VIDEOs.Where(x => x.IDVideo == SelectedItem.IDVideo);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {
                var v = DataProvider.Ins.DB.VIDEOs.Where(x => x.IDVideo == SelectedItem.IDVideo).SingleOrDefault();

                v.TenVideo = TenVideo;
                v.QuocGia = QuocGia;
                v.TomTat = TomTat;
                v.DaoDien = DaoDien;
                v.LuotXem = LuotXem;
                v.LinkVideo = LinkVideo;
                v.LinkPoster = LinkPoster;
                v.Trailer = Trailer;

                DataProvider.Ins.DB.SaveChanges();
                SelectedItem.TenVideo = TenVideo;
            });

            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.VIDEOs.Where(x => x.IDVideo == SelectedItem.IDVideo);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {
                var v = DataProvider.Ins.DB.VIDEOs.Where(x => x.IDVideo == SelectedItem.IDVideo).SingleOrDefault();

                DataProvider.Ins.DB.VIDEOs.Remove(v);
                DataProvider.Ins.DB.SaveChanges();
                List.Remove(v);
            });

            LVCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
                dialog.FileName = "Videos"; // Default file name
                dialog.DefaultExt = ".WMV,.mp4"; // Default file extension
                dialog.Filter = "Video files |*.wmv; *.3g2; *.3gp; *.3gp2; *.3gpp; *.amv; *.asf;  *.avi; *.bin; *.cue; *.divx; *.dv; *.flv; *.gxf; *.iso; *.m1v; *.m2v; *.m2t; *.m2ts; *.m4v; " +
                          " *.mkv; *.mov; *.mp2; *.mp2v; *.mp4; *.mp4v; *.mpa; *.mpe; *.mpeg; *.mpeg1; *.mpeg2; *.mpeg4; *.mpg; *.mpv2; *.mts; *.nsv; *.nuv; *.ogg; *.ogm; *.ogv; *.ogx; *.ps; *.rec; *.rm; *.rmvb; *.tod; *.ts; *.tts; *.vob; *.vro; *.webm; *.dat; "; // Filter files by extension 

                // Show open file dialog box
                Nullable<bool> result = dialog.ShowDialog();

                // Process open file dialog box results 
                if (result == true)
                {
                    // Open document 
                    LinkVideo = dialog.FileName;
                }
            });

            LTCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
                dialog.FileName = "Videos"; // Default file name
                dialog.DefaultExt = ".WMV,.mp4"; // Default file extension
                dialog.Filter = "Video files |*.wmv; *.3g2; *.3gp; *.3gp2; *.3gpp; *.amv; *.asf;  *.avi; *.bin; *.cue; *.divx; *.dv; *.flv; *.gxf; *.iso; *.m1v; *.m2v; *.m2t; *.m2ts; *.m4v; " +
                          " *.mkv; *.mov; *.mp2; *.mp2v; *.mp4; *.mp4v; *.mpa; *.mpe; *.mpeg; *.mpeg1; *.mpeg2; *.mpeg4; *.mpg; *.mpv2; *.mts; *.nsv; *.nuv; *.ogg; *.ogm; *.ogv; *.ogx; *.ps; *.rec; *.rm; *.rmvb; *.tod; *.ts; *.tts; *.vob; *.vro; *.webm; *.dat; "; // Filter files by extension 

                // Show open file dialog box
                Nullable<bool> result = dialog.ShowDialog();

                // Process open file dialog box results 
                if (result == true)
                {
                    // Open document 
                    Trailer = dialog.FileName;
                }
            });

            LPCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
                dialog.FileName = "Videos"; // Default file name
                dialog.DefaultExt = ".jpg,.jpn"; // Default file extension
                dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*"; // Filter files by extension 

                // Show open file dialog box
                Nullable<bool> result = dialog.ShowDialog();

                // Process open file dialog box results 
                if (result == true)
                {
                    // Open document 
                    LinkPoster = dialog.FileName;
                }
            });

        }
    }
}
