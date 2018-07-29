namespace LayerDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonarDetailView")]
    public partial class DonarDetailView
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long DonarId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(256)]
        public string FirstName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(256)]
        public string LastName { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string MobilePhone { get; set; }

        [StringLength(50)]
        public string AlternateMobilePhone { get; set; }

        [StringLength(256)]
        public string EmailAddress { get; set; }

        public int? GenderId { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string GenderName { get; set; }

        public int? MartialStatusId { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string MartialStatusName { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BloodGroupId { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(5)]
        public string BloodGroupName { get; set; }

        public double? Weight { get; set; }

        public double? Longitude { get; set; }

        public double? Latitude { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ColonyAreaId { get; set; }

        [StringLength(1024)]
        public string ColonyAreaName { get; set; }

        [StringLength(2048)]
        public string StreetAddress { get; set; }

        [Key]
        [Column(Order = 9)]
        public DateTime OnCreated { get; set; }

        [Key]
        [Column(Order = 10)]
        public DateTime OnModified { get; set; }
    }
}
