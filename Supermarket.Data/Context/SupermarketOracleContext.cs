namespace Supermarket.Data.Context
{
    using System.Data.Entity;

    using Models;

    using Oracle.ManagedDataAccess.Client;
    using Oracle.ManagedDataAccess.EntityFramework;

    public class SupermarketOracleContext : SupermarketContext
    {
        public const string ConnectionString =
            "Data Source=62.176.105.57:1521/XE;Persist Security Info=True;User ID=HERCULES;Password=pass123;";

        public SupermarketOracleContext()
            : base(new OracleConnection(ConnectionString))
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("HERCULES");

            modelBuilder.Entity<Supermarket>().ToTable("SUPERMARKETS", "HERCULES");
            modelBuilder.Entity<Product>().ToTable("PRODUCTS", "HERCULES");
            modelBuilder.Entity<Measure>().ToTable("MEASURES", "HERCULES");
            modelBuilder.Entity<Vendor>().ToTable("VENDORS", "HERCULES");
            modelBuilder.Entity<Sale>().ToTable("SALES", "HERCULES");

            modelBuilder.Entity<Supermarket>().Property(p => p.SupermarketId).HasColumnName("SUPERMARKET_ID");
            modelBuilder.Entity<Supermarket>().Property(p => p.SupermarketName).HasColumnName("SUPERMARKET_NAME");

            modelBuilder.Entity<Vendor>().Property(p => p.VendorId).HasColumnName("VENDOR_ID");
            modelBuilder.Entity<Vendor>().Property(p => p.VendorName).HasColumnName("VENDOR_NAME");

            modelBuilder.Entity<Product>().Property(p => p.ProductId).HasColumnName("PRODUCT_ID");
            modelBuilder.Entity<Product>().Property(p => p.ProductName).HasColumnName("PRODUCT_NAME");
            modelBuilder.Entity<Product>().Property(p => p.ProductPrice).HasColumnName("PRODUCT_PRICE");
            modelBuilder.Entity<Product>().Property(p => p.MeasureId).HasColumnName("MEASURE_ID");
            modelBuilder.Entity<Product>().Property(p => p.VendorId).HasColumnName("VENDOR_ID");

            modelBuilder.Entity<Measure>().Property(p => p.MeasureId).HasColumnName("MEASURE_ID");
            modelBuilder.Entity<Measure>().Property(p => p.MeasureName).HasColumnName("MEASURE_NAME");

            modelBuilder.Entity<Sale>().Property(p => p.SaleId).HasColumnName("SALE_ID");
            modelBuilder.Entity<Sale>().Property(p => p.SupermarketId).HasColumnName("SUPERMARKET_ID");
            modelBuilder.Entity<Sale>().Property(p => p.ProductId).HasColumnName("PRODUCT_ID");
            modelBuilder.Entity<Sale>().Property(p => p.UnitPrice).HasColumnName("UNIT_PRICE");
            modelBuilder.Entity<Sale>().Property(p => p.Quantity).HasColumnName("QUANTITY");
            modelBuilder.Entity<Sale>().Property(p => p.SaleSum).HasColumnName("SALE_SUM");
        }

        public class ModelConfiguration : DbConfiguration
        {
            public ModelConfiguration()
            {
                this.SetProviderServices("Oracle.ManagedDataAccess.Client", EFOracleProviderServices.Instance);
            }
        }
    }
}