namespace Supermarket.Console
{
    using System;
    using System.Linq;

    using Supermarket.Data;
    using Supermarket.Models;

    public class SupermarketConsole
    {
        public static void Main()
        {
            var db = new SupermarketDbContext();

            var vendor = new Vendor
            {
                VendorName = "Zagorka Corp."
            };

            var measure = new Measure
            {
                MeasureName = "liters"
            };

            var product = new Product
            {
                ProductName = "Beer \"Zagorka\"",
                Vendor = vendor,
                Measure = measure,
                Price = 1.50m
            };

            db.Products.Add(product);
            db.SaveChanges();

            var savedProduct = db.Products.First();

            Console.WriteLine(savedProduct);
        }
    }
}