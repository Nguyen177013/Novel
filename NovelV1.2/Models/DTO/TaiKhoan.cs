namespace NovelV1._2.Models.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaiKhoan()
        {
            DanhGias = new HashSet<DanhGia>();
            LichSu_Doc = new HashSet<LichSu_Doc>();
            Sach_YeuThich = new HashSet<Sach_YeuThich>();
            ThanhToans = new HashSet<ThanhToan>();
        }

        [Key]
        public int TaiKhoan_ma { get; set; }


        [StringLength(50)]

        public string TaiKhoan_tenDN { get; set; }

        [StringLength(50)]
        public string TaiKhoan_hoTen { get; set; }

        [StringLength(120)]
        public string TaiKhoan_matKhau { get; set; }

        [StringLength(12)]
        public string TaiKhoan_sdt { get; set; }

        [StringLength(55)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string TaiKhoan_email { get; set; }
        [NotMapped]
        public string TaiKhoan_MatKhauXacNhan { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhGia> DanhGias { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichSu_Doc> LichSu_Doc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sach_YeuThich> Sach_YeuThich { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThanhToan> ThanhToans { get; set; }
    }
}
