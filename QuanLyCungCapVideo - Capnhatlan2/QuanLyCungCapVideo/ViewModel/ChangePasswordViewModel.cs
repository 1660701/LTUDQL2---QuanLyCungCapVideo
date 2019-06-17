using QuanLyCungCapVideo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuanLyCungCapVideo.ViewModel
{
    class ChangePasswordViewModel : BaseViewModel
    {

        public ICommand EditCommand { get; set; }

        private string _UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }
        private string _OldPassword;
        public string OldPassword { get => _OldPassword; set { _OldPassword = value; OnPropertyChanged(); } }
        private string _NewPassword;
        public string NewPassword { get => _NewPassword; set { _NewPassword = value; OnPropertyChanged(); } }


        public ChangePasswordViewModel()
        {
            UserName = "";
            OldPassword = "";
            EditCommand = new RelayCommand<Window>((p) =>

            {
                return true;

            }, (p) =>
            {
                ChangePass(p);
            });
        }

        void ChangePass(Window p)
        {
            if (p == null)
                return;

            var accCount = DataProvider.Ins.DB.TAIKHOANs.Where(x => x.TenND == UserName && x.MatKhau == OldPassword).Count();
            if (accCount > 0)
            {
               var taikhoan = DataProvider.Ins.DB.TAIKHOANs.Where(x => x.TenND == UserName).SingleOrDefault();
                taikhoan.MatKhau = NewPassword;
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Cập Nhật Thành Công!");
                p.Hide();
            }
            else
            {
                MessageBox.Show("Sai tài khoản cũ hoặc mật khẩu cũ!");
            }
        }

    }
}
