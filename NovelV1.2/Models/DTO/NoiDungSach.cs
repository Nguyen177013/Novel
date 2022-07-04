namespace NovelV1._2.Models.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NoiDungSach")]
    public partial class NoiDungSach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NoiDungSach()
        {
            LichSu_Doc = new HashSet<LichSu_Doc>();
        }

        [Key]
        public int NoiDungSach_ma { get; set; }

        public int? Sach_ma { get; set; }

        [StringLength(100)]
        public string NoiDungSach_Ten { get; set; }

        public int NoiDungSach_Tap { get; set; }

        public string NoiDungSach_NoiDung { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NoiDungSach_ngayUp { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichSu_Doc> LichSu_Doc { get; set; }

        public virtual Sach Sach { get; set; }
    }
}
