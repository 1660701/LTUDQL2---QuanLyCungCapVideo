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
    using System;
    using System.Collections.Generic;
    using QuanLyCungCapVideo.ViewModel;
    
    public partial class TAIKHOAN : BaseViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TAIKHOAN()
        {
            this.THANHTOANs = new HashSet<THANHTOAN>();
            this.YEUTHICHes = new HashSet<YEUTHICH>();
        }
    
        public int IDTK { get; set; }

        private string _TenND;
        public string TenND { get => _TenND; set { _TenND = value; OnPropertyChanged(); } }

         string _MatKhau { get; set; }
        public string MatKhau { get => _MatKhau; set { _MatKhau = value; OnPropertyChanged(); } }

        string _DienThoai { get; set; }
        public string DienThoai { get => _DienThoai; set { _DienThoai = value; OnPropertyChanged(); } }

        string _Email { get; set; }
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }

        Nullable<int> _IDQuyen { get; set; }
        public Nullable<int> IDQuyen { get => _IDQuyen; set { _IDQuyen = value; OnPropertyChanged(); } }


        public virtual QUYEN QUYEN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THANHTOAN> THANHTOANs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<YEUTHICH> YEUTHICHes { get; set; }
    }
}