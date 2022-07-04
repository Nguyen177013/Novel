using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace NovelV1._2.Models.DTO
{
    public partial class NovelDb : DbContext
    {
        public NovelDb()
            : base("name=NovelDb")
        {
        }

        public virtual DbSet<ctThanhToan> ctThanhToans { get; set; }
        public virtual DbSet<DanhGia> DanhGias { get; set; }
        public virtual DbSet<LichSu_Doc> LichSu_Doc { get; set; }
        public virtual DbSet<NoiDungSach> NoiDungSaches { get; set; }
        public virtual DbSet<Sach> Saches { get; set; }
        public virtual DbSet<Sach_YeuThich> Sach_YeuThich { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<ThanhToan> ThanhToans { get; set; }
        public virtual DbSet<TheLoai> TheLoais { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ctThanhToan>()
                .Property(e => e.ctThanhToan_tien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Sach>()
                .Property(e => e.Sach_anh)
                .IsUnicode(false);

            modelBuilder.Entity<Sach>()
                .Property(e => e.Sach_gia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Sach>()
                .HasMany(e => e.DanhGias)
                .WithRequired(e => e.Sach)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.TaiKhoan_tenDN)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.TaiKhoan_sdt)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .HasMany(e => e.DanhGias)
                .WithRequired(e => e.TaiKhoan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ThanhToan>()
                .HasOptional(e => e.ctThanhToan)
                .WithRequired(e => e.ThanhToan);
        }
    }
}
