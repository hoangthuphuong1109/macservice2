namespace Macservice.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Quatrinhluong")]
    public partial class Quatrinhluong
    {
        [Key]
        public int Maquatrinhluong { get; set; }

        public int? Manv { get; set; }

        public int? Maphongban { get; set; }

        public int? Machucvu { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Thoigian { get; set; }

        public decimal? Luongcoban { get; set; }

        public decimal? Trocapchucvu { get; set; }

        public decimal? Phucapkhac { get; set; }

        [StringLength(50)]
        public string Noidung { get; set; }

        public decimal? Luongdoanhso { get; set; }

        public virtual Chucvu Chucvu { get; set; }

        public virtual Phongban Phongban { get; set; }

        public virtual Thongtinnhansu Thongtinnhansu { get; set; }
    }
}
