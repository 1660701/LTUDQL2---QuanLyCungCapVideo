//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyCungCapVideo.Model
{
    using QuanLyCungCapVideo.ViewModel;
    using System;
    using System.Collections.Generic;
    
    public partial class THANHTOAN : BaseViewModel
    {
        public int IDThanhToan { get; set; }

        public Nullable<System.DateTime> NgayTT { get; set; }
        public Nullable<System.DateTime> NgayKT { get; set; }
        private string _GoiCuoc;
        public string GoiCuoc { get => _GoiCuoc; set { _GoiCuoc = value; NotifyPropertyChanged("GoiCuoc"); } }


        private string _HTTT;
        public string HTTT { get => _HTTT; set { _HTTT = value; NotifyPropertyChanged("HTTT"); } }

        private string _TenND;
        public string TenND { get => _TenND; set { _TenND = value; NotifyPropertyChanged("TenND"); } }
    }
}