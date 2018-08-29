namespace LayerDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonarRelationshipView")]
    public partial class DonarRelationshipView
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long PersonId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(513)]
        public string PersonName { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long RelatedPersonId { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(513)]
        public string RelatedPersonName { get; set; }
    }
}
