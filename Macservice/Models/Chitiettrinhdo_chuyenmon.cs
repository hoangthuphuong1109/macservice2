namespace Macservice.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Chitiettrinhdo_chuyenmon
    {
        [Key]
        public int Machitiettrinhdo_chuyenmon { get; set; }

        public int? Manv { get; set; }

        public int? Matrinhdochuyenmon { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Tungay { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Denngay { get; set; }

        public virtual Thongtinnhansu Thongtinnhansu { get; set; }

        public virtual Trinhdo_chuyenmon Trinhdo_chuyenmon { get; set; }
    }
}
