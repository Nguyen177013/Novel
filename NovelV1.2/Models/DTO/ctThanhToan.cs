namespace NovelV1._2.Models.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ctThanhToan")]
    public partial class ctThanhToan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ThanhToan_ma { get; set; }

        public decimal? ctThanhToan_tien { get; set; }

        public virtual ThanhToan ThanhToan { get; set; }
    }
}
