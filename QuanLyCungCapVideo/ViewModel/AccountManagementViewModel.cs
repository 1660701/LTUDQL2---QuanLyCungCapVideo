using QuanLyCungCapVideo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyCungCapVideo.ViewModel
{
    class AccountManagementViewModel : BaseViewModel, IDataErrorInfo
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
                    IDQuyen = SelectedItem.IDQuyen;
                }
            }
        }
        private int _IDTK;
        public int IDTK { get => _IDTK; set { _IDTK = value; OnPropertyChanged(); } }

        private string _TenND;
        public string TenND { get => _TenND; set { _TenND = value; OnPropertyChanged(); } }

        private string _MatKhau;
        public string MatKhau { get => _MatKhau; set { _MatKhau = value; OnPropertyChanged(); } }

        private string _DienThoai;
        public string DienThoai { get => _DienThoai; set { _DienThoai = value; OnPropertyChanged(); } }

        private string _Email;
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }

        private string _IDQuyen;
        public string IDQuyen { get => _IDQuyen; set { _IDQuyen = value; OnPropertyChanged(); } }

        #region IDataErrorInfo Members
        string IDataErrorInfo.this[string propertyName]
        {
            get
            {
                return GetvalidationError(propertyName);
            }
        }

        string IDataErrorInfo.Error
        {
            get
            {
                return null;
            }
        }

        #endregion

        #region Validation 

        static readonly string[] validatedProperties =
        {
            "TenND", "MatKhau", "Email" ,
        };

        public bool IsValid
        {
            get
            {
                foreach (string property in validatedProperties)
                    if (GetvalidationError(property) != null)
                        return false;
                return true;
            }
        }

        string GetvalidationError(string propertyName)
        {
            string error = null;
            switch (propertyName)
            {
                case "TenND":
                    error = ValidateTenND();
                    break;
                case "MatKhau":
                    error = ValidateMatKhau();
                    break;
                case "Email":
                    error = ValidateEmail();
                    break;
            }
            return error;
        }

        private string ValidateTenND()
        {
            if (string.IsNullOrWhiteSpace(TenND))
            {
                return "Tên không được để trống";
            }
            if (!KiemTraTenNguoiDung())
            {
                return "Tên này đã được sử dụng vui lòng đặt tên khác";
            }

            return null;
        }

        private string ValidateMatKhau()
        {
            if (string.IsNullOrWhiteSpace(MatKhau))
            {
                return "Mật Khẩu không được để trống!";
            }
            if (!KiemTraDinhDangMatKhau())
            {
                return "Mật Khẩu phải có tối thiểu 7 ký tự gồm cả chữ và số ";
            }

            return null;
        }
       


        private string ValidateEmail()
        {
            if (string.IsNullOrWhiteSpace(Email))
            {
                return "email Không được để trống";
            }
            if (!KiemTraEmailDungDinhDang())
            {
                return "email phải có định dạng example@example.com";
            }
            if (!KiemTraEmailTonTai())
            {
                return "email đã tồn tại";
            }

            return null;
        }
        #endregion



        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public AccountManagementViewModel()
        {
            List = new ObservableCollection<TAIKHOAN>(DataProvider.Ins.DB.TAIKHOANs);

            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;

            }, (p) =>
            {
                var taikhoan = new TAIKHOAN() { TenND = TenND, DienThoai = DienThoai, MatKhau = MatKhau ,Email = Email, IDQuyen = IDQuyen };

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
                taikhoan.IDQuyen = IDQuyen;
                DataProvider.Ins.DB.SaveChanges();
                SelectedItem.TenND = TenND;
            });

            DeleteCommand = new RelayCommand<object>((p) =>
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
                DataProvider.Ins.DB.TAIKHOANs.Remove(taikhoan);
                DataProvider.Ins.DB.SaveChanges();
                List.Remove(taikhoan);
            });
        }

        public bool KiemTraEmailDungDinhDang()
        {
            // liệt kê ra hết các trường hợp sai

            // Nếu không chứa @ là sai
            if (!Email.Contains("@"))
            {
                return false;
            }

            // Nếu không chứa .com là sai
            if (!Email.Contains(".com"))
            {
                return false;
            }

            int index1 = Email.IndexOf("@");
            int index2 = Email.IndexOf(".com");

            string s = Email.Substring(index1 + 1, index2 - index1 - 1);

            if (s != "gmail" && s != "yahoo" && s != "hotmail")
            {
                return false;
            }

            if (s != "yahoo")
            {
                if (Email.Contains(".vn"))
                {
                    return false;
                }
            }

            return true;

        }
        public bool KiemTraDinhDangMatKhau() // Tối thiểu 7 ký tự và có cả chữ & số
        {
            if (MatKhau.Length < 7)
            {
                return false;
            }

            // Kiểm tra có cả chữ và số
            bool KiemTraChu = false; // coi như chưa có chữ
            bool KiemTraSo = false; // coi như chưa có số

            for (int i = 0; i < MatKhau.Length; ++i)
            {

                if (KiemTraChu == true && KiemTraSo == true)
                {
                    break; // Dừng vòng lặp lại
                }

                // A -> Z: Bắt đầu 65
                // a -> z: Bắt đầu 97
                if ((MatKhau[i] >= 'A' && MatKhau[i] <= 'Z') || (MatKhau[i] >= 'a' && MatKhau[i] <= 'z'))

                {
                    KiemTraChu = true;
                }

                if (MatKhau[i] >= '0' && MatKhau[i] <= '9')
                //if(Char.IsDigit(MatKhau[i]))
                {
                    KiemTraSo = true;
                }
            }

            if (KiemTraSo == false || KiemTraChu == false)
            {
                return false; // không hợp lệ
            }
            return true; // hoàn toàn hợp lệ
        }
        public bool KiemTraTenNguoiDung()
        {
            var accCount = DataProvider.Ins.DB.TAIKHOANs.Where(x => x.TenND == TenND).Count();
            if (accCount > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool KiemTraEmailTonTai()
        {
            var accCount = DataProvider.Ins.DB.TAIKHOANs.Where(x => x.Email == Email).Count();
            if (accCount > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
