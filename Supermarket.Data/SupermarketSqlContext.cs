namespace Supermarket.Data
{
    using System.Data.Entity;
    using System.Data.SqlClient;

    using Models;

    public class SupermarketSqlContext : SupermarketContext
    {
        public SupermarketSqlContext()
            : base(new SqlConnection("Server=62.176.105.57;Database=Supermarket;Persist Security Info=True;User ID=hercules;Password=pass123;"))
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SupermarketSqlContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<Measure>().Property(p => p.MeasureId).HasColumnName("MeasureId");
            modelBuilder.Entity<Measure>().Property(p => p.MeasureName).HasColumnName("MeasureName");

            modelBuilder.Entity<Vendor>().Property(p => p.VendorId).HasColumnName("VendorId");
            modelBuilder.Entity<Vendor>().Property(p => p.VendorName).HasColumnName("VendorName");

            modelBuilder.Entity<Product>().Property(p => p.ProductId).HasColumnName("ProductId");
            modelBuilder.Entity<Product>().Property(p => p.ProductName).HasColumnName("ProductName");
            modelBuilder.Entity<Product>().Property(p => p.ProductPrice).HasColumnName("ProductPrice");
            modelBuilder.Entity<Product>().Property(p => p.MeasureId).HasColumnName("MeasureId");
            modelBuilder.Entity<Product>().Property(p => p.VendorId).HasColumnName("VendorId");
        }
    }
}