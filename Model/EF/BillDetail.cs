namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BillDetail")]
    public partial class BillDetail
    {
        [StringLength(50)]
        public string billDetailId { get; set; }

        [StringLength(50)]
        public string billId { get; set; }

        [StringLength(50)]
        public string packId { get; set; }

        public virtual Bill Bill { get; set; }

        public virtual Pack Pack { get; set; }
    }
}
