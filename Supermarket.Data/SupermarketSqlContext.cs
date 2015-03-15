namespace Supermarket.Data
{
    using System.Data.Entity;
   
    using Models.SQL;
    using Migrations;

    public class SupermarketSqlContext : DbContext
    {
        public SupermarketSqlContext()
            : base("SupermarketSqlContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SupermarketSqlContext, Configuration>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<SupermarketSqlContext>());
            //Database.Initialize(true);
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Measure> Measures { get; set; }

        public DbSet<Vendor> Vendors { get; set; }
    }
}