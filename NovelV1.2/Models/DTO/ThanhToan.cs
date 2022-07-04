namespace NovelV1._2.Models.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThanhToan")]
    public partial class ThanhToan
    {
        [Key]
        public int ThanhToan_ma { get; set; }

        public int? Sach_ma { get; set; }

        public int? TaiKhoan_ma { get; set; }

        [Column(TypeName = "date")]
        public DateTime ThanhToan_ngay { get; set; }

        public virtual ctThanhToan ctThanhToan { get; set; }

        public virtual Sach Sach { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
