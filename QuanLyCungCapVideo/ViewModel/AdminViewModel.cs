using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyCungCapVideo.ViewModel
{
    

    class AdminViewModel : BaseViewModel
    {
        public ICommand AccountCommand { get; set; }
        public ICommand QLVCommand { get; set; }
        public ICommand QLTLCommand { get; set; }
        public ICommand MainCommand { get; set; }
        public ICommand TTCommand { get; set; }



        public AdminViewModel()
        {
            QLVCommand = new RelayCommand<object>((p) => { return true; }, (p) => { QuanLyVideo wd = new QuanLyVideo(); wd.ShowDialog(); });
            AccountCommand = new RelayCommand<object>((p) => { return true; }, (p) => { AccountManagement wd = new AccountManagement(); wd.ShowDialog(); });
            QLTLCommand = new RelayCommand<object>((p) => { return true; }, (p) => { QuanLyTheLoai wd = new QuanLyTheLoai(); wd.ShowDialog(); });
            MainCommand = new RelayCommand<object>((p) => { return true; }, (p) => { MainWindow wd = new MainWindow(); wd.ShowDialog(); });
            TTCommand = new RelayCommand<object>((p) => { return true; }, (p) => { QuanLyThanhToan wd = new QuanLyThanhToan(); wd.ShowDialog(); });

        }
    }
}
