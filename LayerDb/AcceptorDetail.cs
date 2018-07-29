namespace LayerDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AcceptorDetail
    {
        [Key]
        public long AcceptorId { get; set; }

        public long? AcceptedFrom { get; set; }

        public long? DonatedBy { get; set; }

        public DateTime OnCreated { get; set; }

        public DateTime OnModified { get; set; }
    }
}
