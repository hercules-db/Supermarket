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
        private const string DocumentHeaderTitle = "Aggregated Sales Report";
        private const int NumberOfColumn = 5;

        private static readonly string FilePath =
            Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\Exports\PDF\Aggregated-Sales-Report.pdf");

        public static void Export(ISupermarketContext context, DateTime? startDate, DateTime? endDate)
        {
            var document = new Document(PageSize.LETTER, 10, 10, 42, 35);
            var file = new FileStream(FilePath, FileMode.OpenOrCreate);
            PdfWriter.GetInstance(document, file);
            document.Open();

            var pdfTable = new PdfPTable(NumberOfColumn);
            pdfTable.HorizontalAlignment = 1;

            var cellHeader = new PdfPCell(new Phrase(DocumentHeaderTitle));

            var productsData = from p in context.Products
                               group p by p.ProductName
                                   into gr
                                   join s in context.Sales on gr.FirstOrDefault().ProductId equals s.ProductId into ps
                                   join m in context.Supermarkets on ps.FirstOrDefault().SupermarketId equals m.SupermarketId
                                   select new
                                   {
                                       productName = gr.FirstOrDefault().ProductName,
                                       quantity = ps.FirstOrDefault().Quantity,
                                       unitPrice = ps.FirstOrDefault().UnitPrice,
                                       location = m.SupermarketName,
                                       productSaleSum = ps.Sum(sum => sum.SaleSum)
                                   };

            // Add report Date
            pdfTable.AddCell(new Phrase(endDate.ToString()));

            cellHeader.Colspan = NumberOfColumn;
            cellHeader.HorizontalAlignment = 1;
            pdfTable.AddCell(cellHeader);

            // Add labels
            var productLabel = new PdfPCell(new Phrase("Product"));
            var quantityLabel = new PdfPCell(new Phrase("Quantity"));
            var unitPriceLabel = new PdfPCell(new Phrase("Unit Price"));
            var locationlabel = new PdfPCell(new Phrase("Location"));
            var sumLabel = new PdfPCell(new Phrase("Sum"));

            productLabel.HorizontalAlignment = 1;
            quantityLabel.HorizontalAlignment = 1;
            unitPriceLabel.HorizontalAlignment = 1;
            locationlabel.HorizontalAlignment = 1;
            sumLabel.HorizontalAlignment = 1;

            productLabel.BackgroundColor = BaseColor.CYAN;
            quantityLabel.BackgroundColor = BaseColor.CYAN;
            unitPriceLabel.BackgroundColor = BaseColor.CYAN;
            locationlabel.BackgroundColor = BaseColor.CYAN;
            sumLabel.BackgroundColor = BaseColor.CYAN;

            pdfTable.AddCell(productLabel);
            pdfTable.AddCell(quantityLabel);
            pdfTable.AddCell(unitPriceLabel);
            pdfTable.AddCell(locationlabel);
            pdfTable.AddCell(sumLabel);

            foreach (var product in productsData)
            {
                pdfTable.AddCell(product.productName);
                pdfTable.AddCell(product.quantity.ToString());
                pdfTable.AddCell(product.unitPrice.ToString());
                pdfTable.AddCell(product.location);
                pdfTable.AddCell(product.productSaleSum.ToString());
            }

            document.Add(pdfTable);
            document.Close();
            file.Close();
        }
    }
}