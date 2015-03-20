namespace Supermarket.Data.Exports
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    using Context;

    public class Xml
    {

        private static readonly string FolderLocation =
            Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\Exports\XML\");
        private const string FileName = "Sales-by-Vendors-Report.xml";

        public static void Export(ISupermarketContext context, DateTime? startDate, DateTime? endDate)
        {
            var root = new XElement("sales");
            var vendors = context.Vendors.ToList();

            Directory.CreateDirectory(FolderLocation);

            foreach (var vendor in vendors)
            {
                var sales = context.Sales
                .GroupBy(s => s.DateSold)
                .ToDictionary(sd => sd.Key,
                gr => new // TODO: Wrong calculation
                {
                    sales = gr.Count(),
                    sum = gr.Sum(m => m.SaleSum)
                }).OrderBy(date => date.Key)
                .Select(date => new XElement(
                    "summary",
                    new XAttribute("date", date.Key.ToShortDateString()),
                    new XAttribute("total-sum", date.Value.sum)
                    ));

                root.Add(new XElement("sale", new XAttribute("vendor", vendor.VendorName), sales));
            }

            root.Save(Path.Combine(FolderLocation, FileName));
        }
    }
}