namespace NovelV1._2.Models.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LichSu_Doc
    {
        [Key]
        public int LichSu_ma { get; set; }

        public int? TaiKhoan_ma { get; set; }

        public int? Sach_ma { get; set; }

        public int? NoiDungSach_ma { get; set; }

        [StringLength(100)]
        public string LichSu_dong { get; set; }

        public virtual NoiDungSach NoiDungSach { get; set; }

        public virtual Sach Sach { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
