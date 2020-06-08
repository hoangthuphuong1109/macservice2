namespace Macservice.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Nghiphep")]
    public partial class Nghiphep
    {
        [Key]
        public int Manghiphep { get; set; }

        public int? Manv { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngaynghi { get; set; }

        public double? Thoigiannghi { get; set; }

        [StringLength(50)]
        public string Lydo { get; set; }

        public bool? Nghicoluong { get; set; }

        public bool? Nghỉkhongluong { get; set; }

        public virtual Thongtinnhansu Thongtinnhansu { get; set; }
    }
}
