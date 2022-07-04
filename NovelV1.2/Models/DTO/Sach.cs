namespace NovelV1._2.Models.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sach")]
    public partial class Sach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sach()
        {
            DanhGias = new HashSet<DanhGia>();
            LichSu_Doc = new HashSet<LichSu_Doc>();
            NoiDungSaches = new HashSet<NoiDungSach>();
            Sach_YeuThich = new HashSet<Sach_YeuThich>();
            ThanhToans = new HashSet<ThanhToan>();
        }

        [Key]
        public int Sach_ma { get; set; }

        [Required]
        [StringLength(200)]
        public string Sach_ten { get; set; }

        [Required]
        [StringLength(100)]
        public string Sach_TacGia { get; set; }

        [Column(TypeName = "date")]
        public DateTime Sach_ngaySanXuat { get; set; }

        [StringLength(60)]
        public string Sach_anh { get; set; }

        public int? Sach_LuotDoc { get; set; }

        public bool? Sach_TinhTrang { get; set; }

        public string Sach_TomTat { get; set; }

        public decimal? Sach_gia { get; set; }

        public int? TheLoai_ma { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhGia> DanhGias { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichSu_Doc> LichSu_Doc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NoiDungSach> NoiDungSaches { get; set; }

        public virtual TheLoai TheLoai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sach_YeuThich> Sach_YeuThich { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThanhToan> ThanhToans { get; set; }
    }
}
