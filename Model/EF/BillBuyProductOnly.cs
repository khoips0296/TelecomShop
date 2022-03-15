namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BillBuyProductOnly")]
    public partial class BillBuyProductOnly
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int billProOnlyId { get; set; }

        [StringLength(50)]
        public string proId { get; set; }

        public int? empId { get; set; }

        public int? memberId { get; set; }

        public int? shopId { get; set; }

        [StringLength(50)]
        public string payId { get; set; }

        public DateTime dateOrder { get; set; }

        public DateTime dateInstall { get; set; }

        public int Quantity { get; set; }

        public double Total { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Member Member { get; set; }

        public virtual Payment Payment { get; set; }

        public virtual Product Product { get; set; }

        public virtual Shop Shop { get; set; }
    }
}
