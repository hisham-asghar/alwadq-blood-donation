namespace LayerDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CityAreaView")]
    public partial class CityAreaView
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long CityAreaId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(1024)]
        public string CityAreaName { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CityId { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(256)]
        public string CityName { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CountryId { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(256)]
        public string CountryName { get; set; }
    }
}
