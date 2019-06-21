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
        public bool IsEnabled  { get; set; }
        public ICommand LoadedWindowCommand { get; set; }       
        public ICommand TaiKhoanCommand { get; set; }
        public ICommand DangXuatCommand { get; set; }
        
        private string _Username;
        public string Username { get => _Username; set { _Username = value; OnPropertyChanged(); } }

        private string _DienThoai;
        public string DienThoai { get => _DienThoai; set { _DienThoai = value; OnPropertyChanged(); } }

        private string _Email;
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }

        private int _IDQuyen;
        public int IDQuyen { get => _IDQuyen; set { _IDQuyen = value; OnPropertyChanged(); } }


        public MainViewModel()
        {

            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Isloaded = true;
                if (p == null)
                {
                    return;
                }
                p.Hide();
                

                Login loginWindow = new Login();
                loginWindow.ShowDialog();
                if (loginWindow.DataContext == null)
                    return;
                var LoginVM = loginWindow.DataContext as LoginViewModel;

                if (LoginVM.IsLogin )
                {
                    //IsEnabled = true;
                    p.Show();
                    Username = LoginVM.UserName;                    
                }
                else
                {
                    p.Close();
                }
            });

            TaiKhoanCommand = new RelayCommand<object>((p) => { return true; }, (p) =>  {TaiKhoan wd = new TaiKhoan(); wd.ShowDialog(); });
        }
    }
}
