namespace Macservice.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Thongtinnhansu")]
    public partial class Thongtinnhansu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Thongtinnhansu()
        {
            Chitietbangcongs = new HashSet<Chitietbangcong>();
            Chitietbaohiems = new HashSet<Chitietbaohiem>();
            Chitietchucvus = new HashSet<Chitietchucvu>();
            Chitietkhenthuongs = new HashSet<Chitietkhenthuong>();
            Chitietkyluats = new HashSet<Chitietkyluat>();
            Chitietphongbans = new HashSet<Chitietphongban>();
            Chitiettrinhdo_chuyenmon = new HashSet<Chitiettrinhdo_chuyenmon>();
            Hopdongs = new HashSet<Hopdong>();
            Lichtrinhcongtacs = new HashSet<Lichtrinhcongtac>();
            Nghipheps = new HashSet<Nghiphep>();
            Quatrinhluongs = new HashSet<Quatrinhluong>();
        }

        [Key]
       
        public int Manv { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Họ và tên không được để trống")]
        public string Hoten { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngaysinh { get; set; }

        [StringLength(50)]
        public string SDT { get; set; }

        [StringLength(50)]
        public string Gioitinh { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Dantoc { get; set; }

        [StringLength(250)]
        public string Noisinh { get; set; }

        [StringLength(250)]
        public string Hokhauthuongtru { get; set; }

        [StringLength(250)]
        public string Noiohientai { get; set; }

        public int? CMND { get; set; }

        [StringLength(50)]
        public string Noicap { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngaycap { get; set; }

        public int? Maphongban { get; set; }

        public int? Machucvu { get; set; }

        public int? Matrinhdochuyenmon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chitietbangcong> Chitietbangcongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chitietbaohiem> Chitietbaohiems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chitietchucvu> Chitietchucvus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chitietkhenthuong> Chitietkhenthuongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chitietkyluat> Chitietkyluats { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chitietphongban> Chitietphongbans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chitiettrinhdo_chuyenmon> Chitiettrinhdo_chuyenmon { get; set; }

        public virtual Chucvu Chucvu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hopdong> Hopdongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lichtrinhcongtac> Lichtrinhcongtacs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nghiphep> Nghipheps { get; set; }

        public virtual Phongban Phongban { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Quatrinhluong> Quatrinhluongs { get; set; }

        public virtual Trinhdo_chuyenmon Trinhdo_chuyenmon { get; set; }
    }
}
