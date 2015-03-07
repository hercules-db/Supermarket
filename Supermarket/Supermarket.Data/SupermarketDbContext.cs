namespace Supermarket.Data
{
    using System.Data.Entity;

    using Supermarket.Models;

    public class SupermarketDbContext : DbContext
    {

        public SupermarketDbContext()
            : base("Supermarket")
        {
        }

        public IDbSet<Product> Products { get; set; }


        public IDbSet<Vendor> Vendors { get; set; }

        public IDbSet<Measure> Measures { get; set; }
    }
}