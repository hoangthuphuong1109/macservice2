namespace Macservice.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hopdong")]
    public partial class Hopdong
    {
        [Key]
        public int Mahopdong { get; set; }

        public int? Manv { get; set; }

        public int? Maloaihopdong { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngaykiket { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngayketthuc { get; set; }

        public decimal? Luongcoban { get; set; }

        public virtual Loaihopdong Loaihopdong { get; set; }

        public virtual Thongtinnhansu Thongtinnhansu { get; set; }
    }
}
