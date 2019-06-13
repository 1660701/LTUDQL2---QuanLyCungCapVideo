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
    class AccountManagementViewModel : BaseViewModel
    {
        private ObservableCollection<TAIKHOAN> _List;
        public ObservableCollection<TAIKHOAN> List { get => _List; set { _List = value; OnPropertyChanged(); } }

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
                    Quyen = SelectedItem.IDQuyen;
                }
            }
        }
        private string _IDTK;
        public string IDTK { get => _IDTK; set { _IDTK = value; OnPropertyChanged(); } }

        private string _TenND;
        public string TenND { get => _TenND; set { _TenND = value; OnPropertyChanged(); } }

        private string _MatKhau;
        public string MatKhau { get => _MatKhau; set { _MatKhau = value; OnPropertyChanged(); } }

        private string _DienThoai;
        public string DienThoai { get => _DienThoai; set { _DienThoai = value; OnPropertyChanged(); } }

        private string _Email;
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }

        private int? _Quyen;
        public int? Quyen { get => _Quyen; set { _Quyen = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }

        public AccountManagementViewModel()
        {
            List = new ObservableCollection<TAIKHOAN>(DataProvider.Ins.DB.TAIKHOANs);

            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;

            }, (p) =>
            {
                var taikhoan = new TAIKHOAN() { TenND = TenND, DienThoai = DienThoai, MatKhau = MatKhau ,Email = Email, IDQuyen = Quyen };

                DataProvider.Ins.DB.TAIKHOANs.Add(taikhoan);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(taikhoan);
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.TAIKHOANs.Where(x => x.IDTK == SelectedItem.IDTK);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {
                var taikhoan = DataProvider.Ins.DB.TAIKHOANs.Where(x => x.IDTK == SelectedItem.IDTK).SingleOrDefault();
                taikhoan.TenND = TenND;
                taikhoan.DienThoai = DienThoai;
                taikhoan.MatKhau = MatKhau;
                taikhoan.Email = Email;
                taikhoan.IDQuyen = Quyen;
                DataProvider.Ins.DB.SaveChanges();

                SelectedItem.TenND = TenND;
            });
        }
    }
}
