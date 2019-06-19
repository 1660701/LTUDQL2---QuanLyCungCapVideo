using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuanLyCungCapVideo.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public bool Isloaded = false;
        public ICommand LoadedWindowCommand { get; set; }

        public MainViewModel()
        {
            LoadedWindowCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                Isloaded = true;
                WdlistVideo SignupWindow = new WdlistVideo();
                SignupWindow.ShowDialog();
            }
                );
            }
    }
}
