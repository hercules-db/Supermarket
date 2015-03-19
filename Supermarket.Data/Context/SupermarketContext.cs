namespace Supermarket.Data.Context
{
    using System.Data.Common;
    using System.Data.Entity;

    using Models;

    public class SupermarketContext : DbContext, ISupermarketContext
    {
        public SupermarketContext()
            : base()
        {
        }

        public SupermarketContext(DbConnection connection)
            : base(connection, true)
        {
        }

        public IDbSet<Supermarket> Supermarkets { get; set; }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<Measure> Measures { get; set; }

        public IDbSet<Vendor> Vendors { get; set; }

        public IDbSet<Sale> Sales { get; set; }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}