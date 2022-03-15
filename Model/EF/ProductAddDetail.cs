namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductAddDetail")]
    public partial class ProductAddDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int proAddDetailId { get; set; }

        [StringLength(50)]
        public string billId { get; set; }

        [StringLength(50)]
        public string proId { get; set; }

        public int Quantity { get; set; }

        public double Total { get; set; }

        public virtual Bill Bill { get; set; }

        public virtual Product Product { get; set; }
    }
}
