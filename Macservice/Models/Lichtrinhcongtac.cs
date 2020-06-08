namespace Macservice.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Lichtrinhcongtac")]
    public partial class Lichtrinhcongtac
    {
        [Key]
        public int Malichtrinhcongtac { get; set; }

        public int? Manv { get; set; }

        public int? Maphongban { get; set; }

        public int? Machucvu { get; set; }

        public int? Matrinhdochuyenmon { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Tungay { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Denngay { get; set; }

        [StringLength(50)]
        public string Noicongtac { get; set; }

        [StringLength(250)]
        public string Noidungcongtac { get; set; }

        public decimal? Trocap { get; set; }

        public virtual Chucvu Chucvu { get; set; }

        public virtual Phongban Phongban { get; set; }

        public virtual Thongtinnhansu Thongtinnhansu { get; set; }

        public virtual Trinhdo_chuyenmon Trinhdo_chuyenmon { get; set; }
    }
}
