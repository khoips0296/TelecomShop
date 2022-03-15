namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            BillBuyProductOnlies = new HashSet<BillBuyProductOnly>();
            ProductAddDetails = new HashSet<ProductAddDetail>();
        }

        [Key]
        [StringLength(50)]
        public string proId { get; set; }

        [Required]
        [StringLength(100)]
        public string proName { get; set; }

        [Required]
        [StringLength(50)]
        public string proCode { get; set; }

        [StringLength(100)]
        public string Images { get; set; }

        [Column(TypeName = "xml")]
        public string moreImages { get; set; }

        [StringLength(50)]
        public string catId { get; set; }

        [StringLength(50)]
        public string manuId { get; set; }

        public DateTime dateOfManu { get; set; }

        [Required]
        [StringLength(50)]
        public string color { get; set; }

        public int Quantity { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        public double Price { get; set; }

        public double salePrice { get; set; }

        public int Warranty { get; set; }

        public bool? status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BillBuyProductOnly> BillBuyProductOnlies { get; set; }

        public virtual CategoryPack CategoryPack { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductAddDetail> ProductAddDetails { get; set; }
    }
}
