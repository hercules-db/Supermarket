namespace Supermarket.Data
{
    using System.Data.Common;
    using System.Data.Entity;

    using Models;

    public class SupermarketContext : DbContext
    {
        public SupermarketContext()
            : base()
        {
        }

        public SupermarketContext(DbConnection connection)
            : base(connection, true)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Measure> Measures { get; set; }

        public DbSet<Vendor> Vendors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}