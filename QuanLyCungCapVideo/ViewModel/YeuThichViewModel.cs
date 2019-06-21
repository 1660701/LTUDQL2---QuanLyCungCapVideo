using QuanLyCungCapVideo.Model;
using QuanLyCungCapVideo.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCungCapVideo.ViewModel
{
    class YeuThichViewModel :BaseViewModel
    {
        private ObservableCollection<YEUTHICH> _List;
        public ObservableCollection<YEUTHICH> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        public YeuThichViewModel()
        {
            Login loginWindow = new Login();
            if (loginWindow.DataContext == null)
                return;
            var LoginVM = loginWindow.DataContext as LoginViewModel;

            var db = new QuanLyCungCapVideoEntities15();
            List = new ObservableCollection<YEUTHICH>();
            IEnumerable<YEUTHICH> listYT =//query variable
                    from yt in db.YEUTHICHes  //required    
                   // where yt.TenND == LoginVM.UserName
                    select yt;
            foreach (var L in listYT)
            {
                List.Add(L);
            }

        }
    }
}
