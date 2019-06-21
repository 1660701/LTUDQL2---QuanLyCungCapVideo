using QuanLyCungCapVideo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCungCapVideo.ViewModel
{
    class VideoAppearanceViewModel : BaseViewModel
    {
        private ObservableCollection<LoadVideos> _List;
        public ObservableCollection<LoadVideos> List { get => _List; set { _List = value; OnPropertyChanged(); } }       

        public VideoAppearanceViewModel()
        {
            //var db = new QuanLyCungCapVideoEntities8();
            List = new ObservableCollection<LoadVideos>();

            IEnumerable<THELOAI> tl =//query variable
                  from thel in DataProvider.Ins.DB.THELOAIs //required                     
                  select thel;
            foreach(var tll in tl)
            {
                IEnumerable<VIDEO> listvideos =//query variable
                  from video in DataProvider.Ins.DB.VIDEOs  //required    
                    where video.IDTL == tll.IDTL                       //where video.THELOAI == new THELOAI()
                    select video;
                var x = new LoadVideos() { TheLoai = tll.TenTL, Videos = new ObservableCollection<VIDEO>() };

                foreach (var L in listvideos)
                {
                    x.Videos.Add(L);
                }

                List.Add(x);
            }

        }
    }
}
