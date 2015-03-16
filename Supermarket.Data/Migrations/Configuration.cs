namespace Supermarket.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Models.SQL;
    using Models.Oracle;

    public sealed class Configuration : DbMigrationsConfiguration<SupermarketSqlContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SupermarketSqlContext context)
        {
            Sync(context);
        }

        public static void Sync(SupermarketSqlContext context)
        {
            SyncMeasures(context);
            SyncVendors(context);
            context.SaveChanges();

            SyncProducts(context);
        }

        private static void SyncMeasures(SupermarketSqlContext context)
        {
            var measures = new SupermarketOracleContext().MEASURES.ToList();

            foreach (var measure in measures)
            {
                if (!context.Measures.Any(x => x.MeasureName == measure.MEASURE_NAME))
                {
                    context.Measures.Add(new Measure()
                    {
                        MeasureName = measure.MEASURE_NAME
                    });
                }
            }
        }

        private static void SyncVendors(SupermarketSqlContext context)
        {
            var vendors = new SupermarketOracleContext().VENDORS.ToList();

            foreach (var vendor in vendors)
            {
                if (!context.Vendors.Any(x => x.VendorName == vendor.VENDOR_NAME))
                {
                    context.Vendors.Add(new Vendor()
                    {
                        VendorName = vendor.VENDOR_NAME
                    });
                }
            }
        }

        private static void SyncProducts(SupermarketSqlContext context)
        {
            var products = new SupermarketOracleContext().PRODUCTS.ToList();

            foreach (var product in products)
            {
                if (!context.Products.Any(x => x.ProductName == product.PRODUCT_NAME || x.ProductPrice == product.PRICE))
                {
                    context.Products.Add(new Product()
                    {
                        ProductName = product.PRODUCT_NAME,
                        MeasureId = (int)product.MEASURE_ID,
                        VendorId = (int)product.VENDOR_ID,
                        ProductPrice = product.PRICE
                    });
                }
            }
        }
    }
}