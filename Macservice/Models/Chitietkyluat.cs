namespace Macservice.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Chitietkyluat")]
    public partial class Chitietkyluat
    {
        [Key]
        public int Machitietkyluat { get; set; }

        public int? Manv { get; set; }

        public int? Makyluat { get; set; }

        [StringLength(50)]
        public string Lydokyluat { get; set; }

        public decimal? Tienphat { get; set; }

        public virtual Kyluat Kyluat { get; set; }

        public virtual Thongtinnhansu Thongtinnhansu { get; set; }
    }
}
