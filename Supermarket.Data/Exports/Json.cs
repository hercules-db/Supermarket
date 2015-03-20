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
            var sales = (from sale in context.Sales
                         select new
                         {
                             sale.ProductId,
                             ProductName = "",
                             VendorName = "",
                             QuantitySold = sale.Quantity,
                             TotalIncomes = sale.SaleSum
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