namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pack")]
    public partial class Pack
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pack()
        {
            BillDetails = new HashSet<BillDetail>();
        }

        [StringLength(50)]
        public string packId { get; set; }

        [Required]
        [StringLength(100)]
        public string packName { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        public double Price { get; set; }

        [StringLength(50)]
        public string catId { get; set; }

        public bool? status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BillDetail> BillDetails { get; set; }

        public virtual CategoryPack CategoryPack { get; set; }
    }
}
