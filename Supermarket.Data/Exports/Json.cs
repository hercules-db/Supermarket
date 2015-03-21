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

        private static readonly string FolderPath =
            Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\Exports\JSON\");

        public static void Export(ISupermarketContext context, DateTime? startDate, DateTime? endDate)
        {
            var sales = (from s in context.Sales
                         join p in context.Products on s.ProductId equals p.ProductId
                         join v in context.Vendors on p.VendorId equals v.VendorId
                         where s.DateSold >= startDate && s.DateSold <= endDate
                         select new
                         {
                             s.ProductId,
                             p.ProductName,
                             v.VendorName,
                             QuantitySold = s.Quantity,
                             TotalIncomes = s.SaleSum
                         }).ToList();

            var serialize = new JavaScriptSerializer();

            Directory.CreateDirectory(FolderPath);

            for (int i = 0; i < sales.Count; i++)
            {
                var jsonSale = serialize.Serialize(sales[i]);
                var fileName = string.Format(FileName, string.Format("{0}. {1}", i + 1, sales[i].ProductId));
                var writer = new StreamWriter(string.Concat(FolderPath, fileName));

                using (writer)
                {
                    writer.WriteLine(jsonSale);
                }
            }
        }
    }
}