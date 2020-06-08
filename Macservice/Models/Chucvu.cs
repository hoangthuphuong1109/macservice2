namespace Macservice.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Chucvu")]
    public partial class Chucvu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Chucvu()
        {
            Chitietchucvus = new HashSet<Chitietchucvu>();
            Lichtrinhcongtacs = new HashSet<Lichtrinhcongtac>();
            Quatrinhluongs = new HashSet<Quatrinhluong>();
            Thongtinnhansus = new HashSet<Thongtinnhansu>();
        }

        [Key]
        public int Machucvu { get; set; }

        [StringLength(50)]
        public string Tenchucvu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chitietchucvu> Chitietchucvus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lichtrinhcongtac> Lichtrinhcongtacs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Quatrinhluong> Quatrinhluongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Thongtinnhansu> Thongtinnhansus { get; set; }
    }
}
