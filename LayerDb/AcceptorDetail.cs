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

        public long DonatedTo { get; set; }

        public long DonatedBy { get; set; }

        public DateTime BleedDate { get; set; }

        public DateTime OnCreated { get; set; }

        public DateTime OnModified { get; set; }

        public virtual Donar Donar { get; set; }

        public virtual Donar Donar1 { get; set; }
    }
}
