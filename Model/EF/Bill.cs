namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bill")]
    public partial class Bill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bill()
        {
            BillDetails = new HashSet<BillDetail>();
            ProductAddDetails = new HashSet<ProductAddDetail>();
        }

        [StringLength(50)]
        public string billId { get; set; }

        public int? empId { get; set; }

        public int? memberId { get; set; }

        public int? shopId { get; set; }

        [StringLength(50)]
        public string payId { get; set; }

        public DateTime dateOrder { get; set; }

        public DateTime dateInstall { get; set; }

        public double Total { get; set; }

        public bool? status { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Member Member { get; set; }

        public virtual Payment Payment { get; set; }

        public virtual Shop Shop { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BillDetail> BillDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductAddDetail> ProductAddDetails { get; set; }
    }
}
