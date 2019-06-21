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
    class ForgetPassViewModel : BaseViewModel
    {
        private string _TenND;
        public string TenND { get => _TenND; set { _TenND = value; NotifyPropertyChanged("TenND"); } }

        private string _MatKhau;
        public string MatKhau { get => _MatKhau; set { _MatKhau = value; NotifyPropertyChanged("MatKhau"); } }

        private string _DienThoai;
        public string DienThoai { get => _DienThoai; set { _DienThoai = value; NotifyPropertyChanged("DienThoai"); } }

        private string _Email;
        public string Email { get => _Email; set { _Email = value; NotifyPropertyChanged("Email"); } }

        public ICommand fpCommand { get; set; }


        public ForgetPassViewModel()
        {
            fpCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { forgetpass(p); });

        }

        void forgetpass(Window p)
        {
            var accCount = DataProvider.Ins.DB.TAIKHOANs.Where(x => x.TenND == TenND && x.Email == Email && x.DienThoai == DienThoai).Count();
            IQueryable<TAIKHOAN> pw = from TK in DataProvider.Ins.DB.TAIKHOANs
                                          where TK.TenND == TenND && TK.Email == Email && TK.DienThoai == DienThoai
                                          select TK;
            TAIKHOAN pass = pw.SingleOrDefault();
            if (accCount > 0)
            {

                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
                message.Subject = "Mat Khau";
                message.From = new System.Net.Mail.MailAddress("phuonguyen.1108@gmail.com");
                message.Body = pass.MatKhau;
                message.To.Add(Email);

                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com");
                smtp.Credentials = new System.Net.NetworkCredential("phuonguyen.1108@gmail.com", "punguyen1108");
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Send(message);
                MessageBox.Show("Mat khau da duoc gui den mail cua ban!");

            }
            else
            {
                MessageBox.Show("Tên tài khoản hoặc Email hoặc số điện thoại sai!");
            }

            
        }
    }
}
