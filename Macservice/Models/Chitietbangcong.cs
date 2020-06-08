namespace Macservice.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Chitietbangcong")]
    public partial class Chitietbangcong
    {
        [Key]
        public int Machitietbangcong { get; set; }

        public int? Manv { get; set; }

        public int? Mabangcong { get; set; }

        public double? Sogiolam { get; set; }

        public double? Sogiolamthemngayhtuong { get; set; }

        public double? Sogiolamthemngaynghi { get; set; }

        public double? Sogiolamthemngayle { get; set; }

        public double? Songaynghiphep { get; set; }

        public int? Maphongban { get; set; }

        public virtual Bangchamcong Bangchamcong { get; set; }

        public virtual Phongban Phongban { get; set; }

        public virtual Thongtinnhansu Thongtinnhansu { get; set; }
    }
}
