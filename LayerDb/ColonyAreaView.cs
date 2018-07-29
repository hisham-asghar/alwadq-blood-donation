namespace LayerDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ColonyAreaView")]
    public partial class ColonyAreaView
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ColonyAreaId { get; set; }

        [StringLength(1024)]
        public string ColonyAreaName { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long CityAreaId { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(1024)]
        public string CityAreaName { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CityId { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(256)]
        public string CityName { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CountryId { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(256)]
        public string CountryName { get; set; }
    }
}
