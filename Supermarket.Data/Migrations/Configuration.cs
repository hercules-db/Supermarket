namespace Supermarket.Data.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Models;

    public sealed class Configuration : DbMigrationsConfiguration<SupermarketSqlContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        #region Seed
        protected override void Seed(SupermarketSqlContext context)
        {
            SeedMeasures(context);
            SeedVendors(context);

            context.SaveChanges();

            SeedProducts(context);
        }

        private static void SeedMeasures(SupermarketContext context)
        {
            var measures = new List<Measure>()
            {
                new Measure()
                {
                    MeasureName = "liters"
                },
                new Measure()
                {
                    MeasureName = "pieces"
                },
                new Measure()
                {
                    MeasureName = "kg"
                }
            };

            foreach (var measure in measures)
            {
                if (!context.Measures.Any(x => x.MeasureName == measure.MeasureName))
                {
                    context.Measures.Add(measure);
                }
            }
        }

        private static void SeedVendors(SupermarketContext context)
        {
            var vendors = new List<Vendor>()
            {
                new Vendor()
                {
                    VendorName = "Nestle Sofia Corp."
                },
                new Vendor()
                {
                    VendorName = "Zagorka Corp."
                },
                new Vendor()
                {
                    VendorName = "Targovishte Bottling Company Ltd."
                }
            };

            foreach (var vendor in vendors)
            {
                if (!context.Vendors.Any(x => x.VendorName == vendor.VendorName))
                {
                    context.Vendors.Add(vendor);
                }
            }
        }

        private static void SeedProducts(SupermarketContext context)
        {
            var products = new List<Product>()
            {
                new Product()
                {
                    ProductName = "Beer “Zagorka”",
                    ProductPrice = 0.86m,
                    MeasureId = 1,
                    VendorId = 2
                },
                new Product()
                {
                    ProductName = "Vodka “Targovishte”",
                    ProductPrice = 7.56m,
                    MeasureId = 1,
                    VendorId = 3
                },
                new Product()
                {
                    ProductName = "Beer “Beck’s”",
                    ProductPrice = 1.03m,
                    MeasureId = 1,
                    VendorId = 2
                },
                new Product()
                {
                    ProductName = "Chocolate “Milka”",
                    ProductPrice = 2.80m,
                    MeasureId = 2,
                    VendorId = 1
                }
            };

            foreach (var product in products)
            {
                if (!context.Products.Any(x => x.ProductName == product.ProductName))
                {
                    context.Products.Add(product);
                }
            }
        }
        #endregion

        #region Sync
        public static void Sync(SupermarketSqlContext context)
        {
            SyncMeasures(context);
            context.SaveChanges();

            SyncVendors(context);
            context.SaveChanges();

            SyncProducts(context);
            context.SaveChanges();
        }

        private static void SyncMeasures(SupermarketContext context)
        {
            var measures = new SupermarketOracleContext().Measures.ToList();

            foreach (var measure in measures)
            {
                if (!context.Measures.Any(x => x.MeasureName == measure.MeasureName))
                {
                    context.Measures.Add(new Measure()
                    {
                        MeasureName = measure.MeasureName
                    });
                }
            }
        }

        private static void SyncVendors(SupermarketContext context)
        {
            var vendors = new SupermarketOracleContext().Vendors.ToList();

            foreach (var vendor in vendors)
            {
                if (!context.Vendors.Any(x => x.VendorName == vendor.VendorName))
                {
                    context.Vendors.Add(new Vendor()
                    {
                        VendorName = vendor.VendorName
                    });
                }
            }
        }

        private static void SyncProducts(SupermarketContext context)
        {
            var products = new SupermarketOracleContext().Products.ToList();

            foreach (var product in products)
            {
                if (!context.Products.Any(x => x.ProductName == product.ProductName))
                {
                    context.Products.Add(new Product()
                    {
                        ProductName = product.ProductName,
                        MeasureId = product.MeasureId,
                        VendorId = product.VendorId,
                        ProductPrice = product.ProductPrice
                    });
                }
            }
        }
        #endregion
    }
}