namespace Macservice.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Chitietbaohiem")]
    public partial class Chitietbaohiem
    {
        [Key]
        public int Machitietbaohiem { get; set; }

        public int? Mabaohiem { get; set; }

        public int? Manv { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Tungay { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Denngay { get; set; }

        public virtual Baohiem Baohiem { get; set; }

        public virtual Thongtinnhansu Thongtinnhansu { get; set; }
    }
}
