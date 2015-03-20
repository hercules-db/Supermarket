using Supermarket.Models;

namespace Supermarket.Data.Exports
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Web.Script.Serialization;

    using Context;

    public class Json
    {
        private const string FileName = "{0}.json";
        private static string reportsFolder = "../../../Reports/JSON/";

        public static void Export(ISupermarketContext context, DateTime? startDate = null, DateTime? endDate = null)
        {
            var sales = (from s in context.Sales
                         join p in context.Products on s.ProductId equals p.ProductId
                         join v in context.Vendors on p.VendorId equals v.VendorId
                         select new
                         {
                             s.ProductId,
                             p.ProductName,
                             v.VendorName,
                             QuantitySold = s.Quantity,
                             TotalIncomes = s.SaleSum
                         }).ToList();

            var serialize = new JavaScriptSerializer();

            if (!Directory.Exists(reportsFolder))
            {
                Directory.CreateDirectory(reportsFolder);

                for (int i = 0; i < sales.Count; i++)
                {
                    var jsonSale = serialize.Serialize(sales[i]);
                    var fileName = string.Format(FileName, string.Format("{0}. {1}", i + 1, sales[i].ProductId));
                    var writer = new StreamWriter(string.Concat(reportsFolder, fileName));

                    using (writer)
                    {
                        writer.WriteLine(jsonSale);
                    }
                }
            }
        }
    }
}