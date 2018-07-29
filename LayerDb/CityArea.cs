namespace LayerDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CityArea")]
    public partial class CityArea
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CityArea()
        {
            ColonyAreas = new HashSet<ColonyArea>();
        }

        public long Id { get; set; }

        [Required]
        [StringLength(1024)]
        public string Name { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ColonyArea> ColonyAreas { get; set; }
    }
}
