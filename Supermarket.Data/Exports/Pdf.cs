namespace Supermarket.Data.Exports
{
    using System;
    using System.IO;
    using System.Linq;

    using Context;

    using iTextSharp.text;
    using iTextSharp.text.pdf;

    public class Pdf
    {
        private const string FilePath = @"Aggregated Sales Report.pdf";

        private const string DocumentHeaderTitle = "Aggregated Sales Report";

        public static void Export(ISupermarketContext context, DateTime? startDate, DateTime? endDate)
        {
            var document = new Document(PageSize.LETTER, 10, 10, 42, 35);
            var file =new FileStream(FilePath, FileMode.OpenOrCreate);
            PdfWriter.GetInstance(document,file );

            document.Open();
            int numberOfColumn = 2;
            var PdfTable = new PdfPTable(numberOfColumn);
            var cellHeader = new PdfPCell(new Phrase(DocumentHeaderTitle));
            cellHeader.Colspan = numberOfColumn;
            cellHeader.HorizontalAlignment = 1;
            PdfTable.AddCell(cellHeader);
            var data = (
                        from m in context.Supermarkets
                        group m by m.SupermarketName into g
                        join s in context.Sales on g.FirstOrDefault().SupermarketId equals s.SupermarketId into sm
                        select new
                        {
                            marketName = g.FirstOrDefault().SupermarketName,
                            saleSum = sm.Sum(d => d.SaleSum)
                        }
                        );

            //var data = context.Sales
            //    .Join(context.Supermarkets,
            //    sale => sale.SupermarketId,
            //    market => market.SupermarketId,
            //    (sale, market) => new { marketName = market.SupermarketName, saleSum = sale.SaleSum })
            //    .GroupBy(g => g.marketName).Select(s => new {marketName = context., saleSum = sale.SaleSum });
            foreach (var sale in data)
            {
      //          var cellSaleId = sale.saleId.ToString();
                var cellSaleSum = sale.saleSum.ToString() + " лв.";
                var cellSaleSupermarketName = sale.marketName.ToString();

         //       PdfTable.AddCell(cellSaleId);
                PdfTable.AddCell(cellSaleSupermarketName);
                PdfTable.AddCell(cellSaleSum);
            }
            document.Add(PdfTable);
            document.Close();
            file.Close();
        }
    }
}