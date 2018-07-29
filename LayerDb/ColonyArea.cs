namespace LayerDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ColonyArea")]
    public partial class ColonyArea
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ColonyArea()
        {
            Donars = new HashSet<Donar>();
        }

        public long Id { get; set; }

        [StringLength(1024)]
        public string Name { get; set; }

        public long CityAreaId { get; set; }

        public virtual CityArea CityArea { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Donar> Donars { get; set; }
    }
}
