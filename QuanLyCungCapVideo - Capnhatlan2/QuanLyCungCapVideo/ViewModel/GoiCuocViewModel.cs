using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using QuanLyCungCapVideo.Model;

namespace QuanLyCungCapVideo.ViewModel
{
    class GoiCuocViewModel  : BaseViewModel, IDataErrorInfo
    {
        private string _GoiCuoc;
        public string GoiCuoc { get => _GoiCuoc; set { _GoiCuoc = value; NotifyPropertyChanged("GoiCuoc"); } }

        private string _TenND;
        public string TenND { get => _TenND; set { _TenND = value; NotifyPropertyChanged("TenND"); } }

        private string _MatKhau;
        public string MatKhau { get => _MatKhau; set { _MatKhau = value; NotifyPropertyChanged("MatKhau"); } }

        private string _HTTT;
        public string HTTT { get => _HTTT; set { _HTTT = value; NotifyPropertyChanged("HTTT"); } }

        public DateTime NgayTT { get; set; }

        public DateTime NgayKT { get; set; }

        public ICommand GoiCuocCommand { get; set; }

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
            "GoiCuoc", "HTTT"
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
                case "GoiCuoc":
                    error = ValidateGoiCuoc();
                    break;
                case "HTTT":
                    error = ValidateHTTT();
                    break;
                case "TenND":
                    error = ValidateTenND();
                    break;
                case "MatKhau":
                    error = ValidateMatKhau();
                    break;
            }
            return error;
        }

        private string ValidateGoiCuoc()
        {
            if (string.IsNullOrWhiteSpace(GoiCuoc))
            {
                return "Gói cước không được để trống";
            }
            

            return null;
        }
        private string ValidateTenND()
        {
            if (string.IsNullOrWhiteSpace(TenND))
            {
                return "Tên không được để trống";
            }


            return null;
        }
        private string ValidateMatKhau()
        {
            if (string.IsNullOrWhiteSpace(MatKhau))
            {
                return "Mật khẩu không được để trống";
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

        #endregion


        public GoiCuocViewModel()
        {
            GoiCuocCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { GoiCuocc(p); });
        }

        void GoiCuocc(Window p)
        {
            if (p == null)
                return;

            if (IsValid == false)
            {
                MessageBox.Show("Bạn cần phải nhập đầy đủ thông tin tất cả các ô");
            }
            if(!KiemTraTenNguoiDung())
            {
                MessageBox.Show("Tên người dùng hoặc mật khẩu bị sai!");
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

                var gc = new THANHTOAN() {  HTTT = HTTT, NgayTT = NgayTT, NgayKT = NgayKT, GoiCuoc = GoiCuoc, TenND = TenND };
                DataProvider.Ins.DB.THANHTOANs.Add(gc);
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Bạn đã hoàn thành các bước! Enjoy your movies!");
                p.Close();
                Login lg = new Login();
                lg.ShowDialog();
            }
        }
        public bool KiemTraTenNguoiDung()
        {
            var accCount = DataProvider.Ins.DB.TAIKHOANs.Where(x => x.TenND == TenND && x.MatKhau == MatKhau).Count();
            if (accCount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
