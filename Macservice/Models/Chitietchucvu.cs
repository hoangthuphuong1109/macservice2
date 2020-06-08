namespace Macservice.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Chitietchucvu")]
    public partial class Chitietchucvu
    {
        [Key]
        public int Machitietchucvu { get; set; }

        public int? Manv { get; set; }

        public int? Machucvu { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Tungay { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Denngay { get; set; }

        public virtual Chucvu Chucvu { get; set; }

        public virtual Thongtinnhansu Thongtinnhansu { get; set; }
    }
}
