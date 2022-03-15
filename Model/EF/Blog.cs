namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Blog")]
    public partial class Blog
    {
        public int blogId { get; set; }

        [Required]
        [StringLength(100)]
        public string blogName { get; set; }

        [Required]
        [StringLength(100)]
        public string images { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        public DateTime dateCreated { get; set; }

        [StringLength(50)]
        public string catId { get; set; }

        public int? empId { get; set; }

        public bool? status { get; set; }

        public virtual CategoryPack CategoryPack { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
