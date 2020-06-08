namespace Macservice.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Phongban")]
    public partial class Phongban
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Phongban()
        {
            Chitietbangcongs = new HashSet<Chitietbangcong>();
            Chitietphongbans = new HashSet<Chitietphongban>();
            Lichtrinhcongtacs = new HashSet<Lichtrinhcongtac>();
            Quatrinhluongs = new HashSet<Quatrinhluong>();
            Thongtinnhansus = new HashSet<Thongtinnhansu>();
        }

        [Key]
        public int Maphongban { get; set; }

        [StringLength(50)]
        public string Tenphongban { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chitietbangcong> Chitietbangcongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chitietphongban> Chitietphongbans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lichtrinhcongtac> Lichtrinhcongtacs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Quatrinhluong> Quatrinhluongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Thongtinnhansu> Thongtinnhansus { get; set; }
    }
}
