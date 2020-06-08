namespace Macservice.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Bangchamcong> Bangchamcongs { get; set; }
        public virtual DbSet<Baohiem> Baohiems { get; set; }
        public virtual DbSet<Chitietbangcong> Chitietbangcongs { get; set; }
        public virtual DbSet<Chitietbaohiem> Chitietbaohiems { get; set; }
        public virtual DbSet<Chitietchucvu> Chitietchucvus { get; set; }
        public virtual DbSet<Chitietkhenthuong> Chitietkhenthuongs { get; set; }
        public virtual DbSet<Chitietkyluat> Chitietkyluats { get; set; }
        public virtual DbSet<Chitietphongban> Chitietphongbans { get; set; }
        public virtual DbSet<Chitiettrinhdo_chuyenmon> Chitiettrinhdo_chuyenmon { get; set; }
        public virtual DbSet<Chucvu> Chucvus { get; set; }
        public virtual DbSet<Hopdong> Hopdongs { get; set; }
        public virtual DbSet<Khenthuong> Khenthuongs { get; set; }
        public virtual DbSet<Kyluat> Kyluats { get; set; }
        public virtual DbSet<Lichtrinhcongtac> Lichtrinhcongtacs { get; set; }
        public virtual DbSet<Loaihopdong> Loaihopdongs { get; set; }
        public virtual DbSet<Nghiphep> Nghipheps { get; set; }
        public virtual DbSet<Phongban> Phongbans { get; set; }
        public virtual DbSet<Quatrinhluong> Quatrinhluongs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Taikhoan> Taikhoans { get; set; }
        public virtual DbSet<Thongtinnhansu> Thongtinnhansus { get; set; }
        public virtual DbSet<Trinhdo_chuyenmon> Trinhdo_chuyenmon { get; set; }
        public virtual DbSet<Demo> Demos { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           

            modelBuilder.Entity<Chitietkyluat>()
                .Property(e => e.Tienphat)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Hopdong>()
                .Property(e => e.Luongcoban)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Lichtrinhcongtac>()
                .Property(e => e.Trocap)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Quatrinhluong>()
                .Property(e => e.Luongcoban)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Quatrinhluong>()
                .Property(e => e.Trocapchucvu)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Quatrinhluong>()
                .Property(e => e.Phucapkhac)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Quatrinhluong>()
                .Property(e => e.Luongdoanhso)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Demo>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
