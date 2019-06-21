using QuanLyCungCapVideo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyCungCapVideo.ViewModel
{
    class QuanLyTheLoaiViewModel : BaseViewModel
    {
        private ObservableCollection<THELOAI> _List;
        private THELOAI _SelectedItem;// nhấn để hiện ra trên textbox
        private string _TenTL;
        private int _IDTL;


        public ObservableCollection<THELOAI> List
        {
            get
            {
                return _List;
            }

            set
            {
                _List = value;
                OnPropertyChanged();
            }
        }
        public string TenTL
        {
            get
            {
                return _TenTL;
            }

            set
            {
                _TenTL = value;
                OnPropertyChanged();
            }
        }
        public int IDTL
        {
            get
            {
                return _IDTL;

            }

            set
            {
                _IDTL = value;
                OnPropertyChanged();
            }
        }
        public THELOAI SelectedItem
        {
            get
            {
                return _SelectedItem;
            }

            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    TenTL = SelectedItem.TenTL;
                    IDTL = SelectedItem.IDTL;
                }
            }
        }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }


        public QuanLyTheLoaiViewModel()
        {
            List = new ObservableCollection<THELOAI>(DataProvider.Ins.DB.THELOAIs);// hiển thị danh sách

            AddCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(TenTL))
                    return false;

                var displayList = DataProvider.Ins.DB.THELOAIs.Where(x => x.IDTL == IDTL);
                if (displayList == null || displayList.Count() == 0) //điều kiện để nhấn dc button
                    return true;

                return false;



            }, (p) =>
            {
                var role = new THELOAI() { TenTL = TenTL, IDTL = IDTL };
                DataProvider.Ins.DB.THELOAIs.Add(role);
                DataProvider.Ins.DB.SaveChanges();// cập nhật trên db

                List.Add(role);


            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                {
                    return false;
                }
                return true;
            }, (p) =>
            {
                var role = DataProvider.Ins.DB.THELOAIs.Where(x => x.IDTL == SelectedItem.IDTL).SingleOrDefault();//lấy ra id tương ứng
                role.TenTL = TenTL;
                role.IDTL = IDTL;

                DataProvider.Ins.DB.SaveChanges();

                TenTL = SelectedItem.TenTL;
                IDTL = SelectedItem.IDTL;

            });

            //DeleteCommand = new RelayCommand<object>((p) =>
            //{
            //    if (SelectedItem == null)
            //        return false;

            //    var displayList = DataProvider.Ins.DB.THELOAIs.Where(x => x.IDTL == SelectedItem.IDTL);
            //    if (displayList != null && displayList.Count() != 0)
            //        return true;

            //    return false;

            //}, (p) =>
            //{
            //    var tl = DataProvider.Ins.DB.THELOAIs.Where(x => x.IDTL == SelectedItem.IDTL).SingleOrDefault();
            //    DataProvider.Ins.DB.THELOAIs.Remove(tl);
            //    //DataProvider.Ins.DB.SaveChanges();
            //    List.Remove(tl);

            //    var v = DataProvider.Ins.DB.VIDEOs.Where(x => x.IDTL == SelectedItem.IDTL).SingleOrDefault();
            //    DataProvider.Ins.DB.VIDEOs.Remove(v);
            //    DataProvider.Ins.DB.SaveChanges();

            //    var join = (from tl in THELOAI join v in VIDEO
            //                on tl.IDTL equals v.IDTL
            //                where tl.IDTL == SelectedItem.IDTL)
            //});

        }
    }
}
