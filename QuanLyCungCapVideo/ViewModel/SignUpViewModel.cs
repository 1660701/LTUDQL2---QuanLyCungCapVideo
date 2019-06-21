using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using QuanLyCungCapVideo.Model;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace QuanLyCungCapVideo.ViewModel
{

    class SignUpViewModel : BaseViewModel, IDataErrorInfo
    {

      

        private string _IDTK;
        public string IDTK { get => _IDTK; set { _IDTK = value; NotifyPropertyChanged("IDTK"); } }

        private string _TenND;
        public string TenND { get => _TenND; set { _TenND = value; NotifyPropertyChanged("TenND"); } }

        private string _MatKhau;
        public string MatKhau { get => _MatKhau; set { _MatKhau = value; NotifyPropertyChanged("MatKhau"); } }

        private string _DienThoai;
        public string DienThoai { get => _DienThoai; set { _DienThoai = value; NotifyPropertyChanged("DienThoai"); } }

        private string _Email;
        public string Email { get => _Email; set { _Email = value; NotifyPropertyChanged("Email"); } }

        private string _GoiCuoc;
        public string GoiCuoc { get => _GoiCuoc; set { _GoiCuoc = value; NotifyPropertyChanged("GoiCuoc"); } }


        private string _HTTT;
        public string HTTT { get => _HTTT; set { _HTTT = value; NotifyPropertyChanged("HTTT"); } }


        public DateTime NgayTT { get; set; }

        public DateTime NgayKT { get; set; }

        public ICommand GoiCuocCommand { get; set; }

        public bool IsSignUp { get; set; }

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
            "TenND", "MatKhau", "Email" , "GoiCuoc", "HTTT", "DienThoai"
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
                case "GoiCuoc":
                    error = ValidateGoiCuoc();
                    break;
                case "HTTT":
                    error = ValidateHTTT();
                    break;
                case "DienThoai":
                    error = ValidateDienThoai();
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
        private string ValidateHTTT()
        {
            if (string.IsNullOrWhiteSpace(HTTT))
            {
                return "Hình thức thanh toán không được để trống!";
            }

            return null;
        }

        private string ValidateGoiCuoc()
        {
            if (string.IsNullOrWhiteSpace(GoiCuoc))
            {
                return "Gói cước không được để trống";
            }


            return null;
        }


        private string ValidateEmail()
        {
            if (string.IsNullOrWhiteSpace(Email))
            {
                return "email Không được để trống";
            }
            if(!KiemTraEmailDungDinhDang())
            {
                return "email phải có định dạng example@example.com";
            }
            if (!KiemTraEmailTonTai())
            {
                return "email đã tồn tại";
            }

            return null;
        }

        private string ValidateDienThoai()
        {
            if (string.IsNullOrWhiteSpace(DienThoai))
            {
                return "Điện thoại Không được để trống";
            }
            if (!KiemTraSDTTonTai())
            {
                return "Số diện thoại đã tồn tại";
            }

            return null;
        }
        #endregion


        public SignUpViewModel()
        {
            TenND = "";
            MatKhau = "";
            Email = "";
            DienThoai = "";
            HTTT = "";
            GoiCuoc = "";
            IsSignUp = false;
            GoiCuocCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { GoiCuocc(p); });
        }


        void GoiCuocc(Window p)
        {
            if (p == null)
                return;
            if (!KiemTraTenNguoiDung())
            {
                IsSignUp = false;
                MessageBox.Show("Tên này đã được sử dụng vui lòng đặt tên khác");
            }
            else if (!KiemTraEmailDungDinhDang())
            {
                IsSignUp = false;
                MessageBox.Show("email phải có định dạng example@example.com");
            }
            else if (!KiemTraEmailTonTai())
            {
                IsSignUp = false;
                MessageBox.Show("Email này đã được sử dụng vui lòng đặt tên khác");
            }
            else if (!KiemTraDinhDangMatKhau())
            {
                IsSignUp = false;
                MessageBox.Show("Mật Khẩu phải có tối thiểu 7 ký tự gồm cả chữ và số ");
            }
            else if (!KiemTraSDTTonTai())
            {
                IsSignUp = false;
                MessageBox.Show(" Số điiện thoại này đã được sử dụng vui lòng đặt tên khác");
            }
            else if (IsValid == false)
            {
                MessageBox.Show("Bạn cần phải nhập đầy đủ thông tin tất cả các ô");
            }
            else
            {
                NgayTT = DateTime.Now;

                if (GoiCuoc == "BASIC")
                {
                    NgayKT = DateTime.Now.AddMonths(1);
                }
                if (GoiCuoc == "STANDARD")
                {
                    NgayKT = DateTime.Now.AddMonths(6);
                }
                if (GoiCuoc == "PREMIUM")
                {
                    NgayKT = DateTime.Now.AddYears(1);
                }
                //IDTK = DataProvider.Ins.DB.TAIKHOANs.Select(x => x.IDTK).ToString();
                IsSignUp = true;

                var taikhoan = new TAIKHOAN() { TenND = TenND, DienThoai = DienThoai, MatKhau = MatKhau, Email = Email, IDQuyen = "User" };
                DataProvider.Ins.DB.TAIKHOANs.Add(taikhoan);
                DataProvider.Ins.DB.SaveChanges();

                var gc = new THANHTOAN() { HTTT = HTTT, NgayTT = NgayTT, NgayKT = NgayKT, GoiCuoc = GoiCuoc, TenND = TenND };
                DataProvider.Ins.DB.THANHTOANs.Add(gc);
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Bạn đã hoàn thành các bước! Enjoy your movies!");
                p.Close();
            }
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
           var accCount =  DataProvider.Ins.DB.TAIKHOANs.Where(x => x.TenND == TenND).Count();
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
        public bool KiemTraSDTTonTai()
        {
            var accCount = DataProvider.Ins.DB.TAIKHOANs.Where(x => x.DienThoai == DienThoai).Count();
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
