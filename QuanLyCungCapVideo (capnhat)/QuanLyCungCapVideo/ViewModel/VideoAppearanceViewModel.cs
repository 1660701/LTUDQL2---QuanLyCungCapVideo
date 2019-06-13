using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCungCapVideo.Model;
using QuanLyCungCapVideo.ViewModel;

namespace QuanLyCungCapVideo.ViewModel
{
    class VideoAppearanceViewModel : BaseViewModel
    {
        private ObservableCollection<VIDEO> _List;
        public ObservableCollection<VIDEO> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        public VideoAppearanceViewModel()
        {

            var db = new QuanLyCungCapVideoEntities7();
            List = new ObservableCollection<VIDEO>();
            IEnumerable<VIDEO> listvideo =//query variable
                    from video in db.VIDEOs  //required    
                    where video.IDTL == 1                         //where video.THELOAI == new THELOAI()
                    select video;
            foreach (var L in listvideo)
            {
                List.Add(L);
            }

            
        }
    }
}
