using QuanLyCungCapVideo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuanLyCungCapVideo.ViewModel
{
    class LoginViewModel : BaseViewModel
    {
        public bool IsLogin { get; set; }
        public bool IsEnabled { get; set; }
        private string _UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }
        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }
        private int _IDQuyen;
        public int IDQuyen { get => _IDQuyen; set { _IDQuyen = value; OnPropertyChanged(); } }


        public ICommand LoginCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }
        public ICommand SignUpCommand { get; set; }


        public LoginViewModel()
        {
            IsEnabled = false;
            IsLogin = false;
            Password = "";
            UserName = "";
            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { Login(p); });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = p.Password; });
            SignUpCommand = new RelayCommand<object>((p) => { return true; }, (p) => { SignUp wd = new SignUp(); wd.ShowDialog(); });
        }
        void Login(Window p)
        {
            if (p == null)
                return;

           var accCount = DataProvider.Ins.DB.TAIKHOANs.Where(x => x.TenND == UserName && x.MatKhau == Password ).Count();
            IQueryable<TAIKHOAN> idrole = from TK in DataProvider.Ins.DB.TAIKHOANs
                                       where TK.TenND == UserName && TK.MatKhau == Password
                                       select TK;
            TAIKHOAN role = idrole.SingleOrDefault();
            if (accCount > 0)
                switch (role.IDQuyen)
                {
                    case "Admin":

                        {
                            var ad = new Admin();
                            ad.Show();
                            //p.Close();
                            break;
                        }
                    case "User":
                        {
                            IsLogin = true;
                            var ngaykt = DataProvider.Ins.DB.THANHTOANs.Where(x => x.NgayKT == DateTime.Now && x.TenND == UserName).Count();
                            if(ngaykt > 0)
                            {
                                MessageBox.Show("Gói cước của bạn đã hết hạn vui lòng đăng ký gói cước khác!");
                                GoiCuoc gc = new GoiCuoc();
                                gc.ShowDialog();
                            }
                            p.Close();
                            break;
                        }
                }
            else
            {
                IsLogin = false;
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
            }
        }        
    }
}
