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
            var file = new FileStream(FilePath, FileMode.OpenOrCreate);
            PdfWriter.GetInstance(document, file);
            document.Open();

            int numberOfColumn = 5;

            var PdfTable = new PdfPTable(numberOfColumn);
            PdfTable.HorizontalAlignment = 1;
            var cellHeader = new PdfPCell(new Phrase(DocumentHeaderTitle));

            var productsData = (
            from p in context.Products
            group p by p.ProductName into gr
            join s in context.Sales on gr.FirstOrDefault().ProductId equals s.ProductId into ps
            join m in context.Supermarkets on ps.FirstOrDefault().SupermarketId equals m.SupermarketId
            select new
            {
                productName = gr.FirstOrDefault().ProductName,
                quantity = ps.FirstOrDefault().Quantity,
                unitPrice = ps.FirstOrDefault().UnitPrice,
                location = m.SupermarketName,
                productSaleSum = ps.Sum(sum => sum.SaleSum)
            }
            );

            //Add report Date
            PdfTable.AddCell(new Phrase(endDate.ToString()));


            cellHeader.Colspan = numberOfColumn;
            cellHeader.HorizontalAlignment = 1;
            PdfTable.AddCell(cellHeader);
            
            //Add labels
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

            PdfTable.AddCell(productLabel);
            PdfTable.AddCell(quantityLabel);
            PdfTable.AddCell(unitPriceLabel);
            PdfTable.AddCell(locationlabel);
            PdfTable.AddCell(sumLabel);


            foreach (var product in productsData)
            {
                var cellProductName = product.productName.ToString();
                var cellQuantity = product.quantity.ToString();
                var cellUnitPrice = product.unitPrice.ToString();
                var cellLocation = product.location.ToString();
                var cellProductSaleSum = product.productSaleSum.ToString();

                PdfTable.AddCell(cellProductName);
                PdfTable.AddCell(cellQuantity);
                PdfTable.AddCell(cellUnitPrice);
                PdfTable.AddCell(cellLocation);
                PdfTable.AddCell(cellProductSaleSum);
            }
            document.Add(PdfTable);
            document.Close();
            file.Close();
        }
    }
}