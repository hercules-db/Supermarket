namespace Supermarket.Data
{
    using System.Data.Entity;

    using Oracle.ManagedDataAccess.Client;
    using Oracle.ManagedDataAccess.EntityFramework;
    
    using Models;

    public class SupermarketOracleContext : SupermarketContext
    {
        public SupermarketOracleContext()
            : base(new OracleConnection("Data Source=62.176.105.57:1521/XE;Persist Security Info=True;User ID=HERCULES;Password=pass123;"))
        {
        }

        public class ModelConfiguration : DbConfiguration
        {
            public ModelConfiguration() 
            {
                SetProviderServices("Oracle.ManagedDataAccess.Client", EFOracleProviderServices.Instance);
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("HERCULES");
            modelBuilder.Entity<Product>().ToTable("PRODUCT", "HERCULES");
            modelBuilder.Entity<Measure>().ToTable("MEASURE", "HERCULES");
            modelBuilder.Entity<Vendor>().ToTable("VENDOR", "HERCULES");
        }
    }
}