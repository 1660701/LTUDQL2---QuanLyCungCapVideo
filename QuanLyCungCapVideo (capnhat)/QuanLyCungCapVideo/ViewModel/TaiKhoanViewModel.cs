using System;
using System.Collections.Generic;
using QuanLyCungCapVideo.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyCungCapVideo.ViewModel
{
    class TaiKhoanViewModel : BaseViewModel
    {
        private ObservableCollection<TAIKHOAN> _List;
        public ObservableCollection<TAIKHOAN> List { get => _List; set { _List = value; OnPropertyChanged(); } }
        public ICommand ChangePasswordCommand { get; set; }

        private TAIKHOAN _SelectedItem;
        public TAIKHOAN SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    TenND = SelectedItem.TenND;
                    MatKhau = SelectedItem.MatKhau;
                    DienThoai = SelectedItem.DienThoai;
                    Email = SelectedItem.Email;
                }
            }
        }

        private string _TenND;
        public string TenND { get => _TenND; set { _TenND = value; OnPropertyChanged(); } }

        private string _DienThoai;
        public string DienThoai { get => _DienThoai; set { _DienThoai = value; OnPropertyChanged(); } }

        private string _Email;
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }

        private string _MatKhau;
        public string MatKhau { get => _MatKhau; set { _MatKhau = value; OnPropertyChanged(); } }

        public ICommand EditCommand { get; set; }

        public TaiKhoanViewModel()
        {
            Login loginWindow = new Login();

            var LoginVM = loginWindow.DataContext as LoginViewModel;

            List = new ObservableCollection<TAIKHOAN>(DataProvider.Ins.DB.TAIKHOANs.Where(x => x.TenND == LoginVM.UserName));

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.TAIKHOANs.Where(x => x.TenND == SelectedItem.TenND);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {
                var taikhoan = DataProvider.Ins.DB.TAIKHOANs.Where(x => x.TenND == SelectedItem.TenND).SingleOrDefault();
                taikhoan.TenND = TenND;
                taikhoan.DienThoai = DienThoai;
                taikhoan.MatKhau = MatKhau;
                taikhoan.Email = Email;
                DataProvider.Ins.DB.SaveChanges();
                SelectedItem.TenND = TenND;
            });
            ChangePasswordCommand = new RelayCommand<object>((p) => { return true; }, (p) => { ChangePassword wd = new ChangePassword(); wd.ShowDialog(); });
        }
    }
}
