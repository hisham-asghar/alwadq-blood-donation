namespace LayerDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Donar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Donar()
        {
            Donars1 = new HashSet<Donar>();
            Donars = new HashSet<Donar>();
        }

        public long DonarId { get; set; }

        [Required]
        [StringLength(256)]
        public string FirstName { get; set; }

        [StringLength(256)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string MobilePhone { get; set; }

        [StringLength(50)]
        public string AlternateMobilePhone { get; set; }

        [StringLength(256)]
        public string EmailAddress { get; set; }

        public int? GenderId { get; set; }

        public int? MartialStatusId { get; set; }

        public int BloodGroupId { get; set; }

        public double? Weight { get; set; }

        public double? Longitude { get; set; }

        public double? Latitude { get; set; }

        [StringLength(2048)]
        public string StreetAddress { get; set; }

        public long ColonyAreaId { get; set; }

        public DateTime OnCreated { get; set; }

        public DateTime OnModified { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public virtual BloodGroup BloodGroup { get; set; }

        public virtual ColonyArea ColonyArea { get; set; }

        public virtual Gender Gender { get; set; }

        public virtual MartialStatu MartialStatu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Donar> Donars1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Donar> Donars { get; set; }
    }
}
