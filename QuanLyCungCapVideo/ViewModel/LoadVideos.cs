using QuanLyCungCapVideo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCungCapVideo.ViewModel
{
    class LoadVideos
    {

        public string TheLoai { get; set; }
        public ObservableCollection<VIDEO> Videos { get; set; }
      
    }
}
