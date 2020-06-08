namespace Macservice.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Trinhdo_chuyenmon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Trinhdo_chuyenmon()
        {
            Chitiettrinhdo_chuyenmon = new HashSet<Chitiettrinhdo_chuyenmon>();
            Lichtrinhcongtacs = new HashSet<Lichtrinhcongtac>();
            Thongtinnhansus = new HashSet<Thongtinnhansu>();
        }

        [Key]
        public int Matrinhdochuyenmon { get; set; }

        [StringLength(50)]
        public string Tentrinhdochuyenmon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chitiettrinhdo_chuyenmon> Chitiettrinhdo_chuyenmon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lichtrinhcongtac> Lichtrinhcongtacs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Thongtinnhansu> Thongtinnhansus { get; set; }
    }
}
