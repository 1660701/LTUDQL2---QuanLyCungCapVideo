using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using QuanLyCungCapVideo.Model;

namespace QuanLyCungCapVideo.ViewModel
{
    public class MainViewModel : BaseViewModel
    {

        public bool Isloaded = false;
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand AccountCommand { get; set; }
        public ICommand TaiKhoanCommand { get; set; }
        private string _Username;
        public string Username { get => _Username; set { _Username = value; OnPropertyChanged(); } }

        private string _DienThoai;
        public string DienThoai { get => _DienThoai; set { _DienThoai = value; OnPropertyChanged(); } }

        private string _Email;
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }


        public MainViewModel()
        {

            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Isloaded = true;
                if(p == null)
                {
                    return;
                }
                p.Hide();
                Login loginWindow = new Login();
                loginWindow.ShowDialog();
                if (loginWindow.DataContext == null)
                    return;

                var LoginVM = loginWindow.DataContext as LoginViewModel;

                if(LoginVM.IsLogin)
                {
                    p.Show();
                    
                    Username = LoginVM.UserName;
                    
                }
                else
                {
                    p.Close();
                }

            }
                );
            AccountCommand = new RelayCommand<object>((p) => { return true; }, (p) => { AccountManagement wd = new AccountManagement(); wd.ShowDialog(); });
            TaiKhoanCommand = new RelayCommand<object>((p) => { return true; }, (p) =>  {TaiKhoan wd = new TaiKhoan(); wd.ShowDialog(); });


        }
       
    }
}
