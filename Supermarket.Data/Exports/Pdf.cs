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
        private const string FilePath = @"..\..\..\Exports\PDF\Aggregated-Sales-Report.pdf";

        private const string DocumentHeaderTitle = "Aggregated Sales Report";

        public static void Export(ISupermarketContext context, DateTime? startDate, DateTime? endDate)
        {
            var document = new Document(PageSize.LETTER, 10, 10, 42, 35);

            PdfWriter.GetInstance(document, new FileStream(FilePath, FileMode.Create));

            document.Open();

            var titleHeader = new PdfPTable(1);
            var cellHeader = new PdfPCell(new Phrase(DocumentHeaderTitle)) {HorizontalAlignment = 1};

            titleHeader.AddCell(cellHeader);
            document.Add(titleHeader);

            document.Close();
        }
    }
}