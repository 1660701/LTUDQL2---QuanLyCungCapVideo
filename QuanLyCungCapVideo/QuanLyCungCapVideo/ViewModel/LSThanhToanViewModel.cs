using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCungCapVideo.Model;

namespace QuanLyCungCapVideo.ViewModel
{
    class LSThanhToanViewModel : BaseViewModel
    {
        private ObservableCollection<THANHTOAN> _List;
        public ObservableCollection<THANHTOAN> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        public LSThanhToanViewModel()
        {
            Login loginWindow = new Login();
            if (loginWindow.DataContext == null)
                return;
            var LoginVM = loginWindow.DataContext as LoginViewModel;

            List = new ObservableCollection<THANHTOAN>(DataProvider.Ins.DB.THANHTOANs.Where(x => x.TenND == LoginVM.UserName));
        }
    }
}
