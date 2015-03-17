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

        public DbSet<Supermarket> Supermarkets { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Measure> Measures { get; set; }

        public DbSet<Vendor> Vendors { get; set; }

        public DbSet<Sale> Sales { get; set; }
    }
}