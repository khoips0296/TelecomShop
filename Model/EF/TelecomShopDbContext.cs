namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TelecomShopDbContext : DbContext
    {
        public TelecomShopDbContext()
            : base("name=TelecomShop")
        {
        }

        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<BillBuyProductOnly> BillBuyProductOnlies { get; set; }
        public virtual DbSet<BillDetail> BillDetails { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<CategoryPack> CategoryPacks { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Pack> Packs { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductAddDetail> ProductAddDetails { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
