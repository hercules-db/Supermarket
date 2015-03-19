namespace Supermarket.Data.Imports
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;

    using Microsoft.Office.Interop.Excel;

    using Context;
    using Models;

    public class Excel
    {
        private const string FileName = "Import.xls";
        private const string FolderName = "\\Temp\\";

        public List<string> Import(string path, ISupermarketContext context)
        {
            string tempFolder = string.Format("{0}{1}", Directory.GetCurrentDirectory(), FolderName);
            var reportDates = new List<string>();
            var archive = ZipFile.OpenRead(path);

            using (archive)
            {
                foreach (var entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith("/"))
                    {
                        reportDates.Add(entry.FullName.TrimEnd('/'));
                    }
                    else
                    {
                        if (!Directory.Exists(tempFolder))
                        {
                            Directory.CreateDirectory(tempFolder);
                        }

                        entry.ExtractToFile(Path.Combine(tempFolder, FileName), true);
                        var sales = this.ProcessExcel(string.Format("{0}{1}", tempFolder, FileName), context);

                        foreach (var sale in sales)
                        {
                            context.Sales.Add(sale);
                        }
                    }
                }

                context.SaveChanges();
            }

            return reportDates;
        }

        private List<Sale> ProcessExcel(string path, ISupermarketContext context = null)
        {
            var excel = new Application();
            var workBook = excel.Workbooks.Open(path, 0, true, 5, string.Empty, string.Empty, true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            var workSheet = (Worksheet)workBook.Worksheets.get_Item("Sales");

            workSheet.Columns.ClearFormats();
            workSheet.Rows.ClearFormats();

            var range = workSheet.UsedRange;
            var sales = new List<Sale>();

            string supermarketName = range.Value2[1, 1];
            var supermarket = context.Supermarkets.First(x => x.SupermarketName == supermarketName);

            if (supermarket == null)
            {
                return sales; // Supermarket not found
            }

            for (int i = 3; i < range.Rows.Count; i++)
            {
                for (int j = 1; j < 2; j++)
                {
                    string productName = range.Value2[i, 1];
                    var product = context.Products.First(x => x.ProductName == productName);

                    if (product != null)
                    {
                        var quantity = int.Parse(range.Value2[i, 2].ToString());
                        var unitPrice = decimal.Parse(range.Value2[i, 3].ToString());

                        sales.Add(new Sale()
                        {
                            SupermarketId = supermarket.SupermarketId,
                            ProductId = product.ProductId,
                            Quantity = quantity,
                            UnitPrice = unitPrice,
                            SaleSum = quantity * unitPrice
                        });
                    }
                }
            }

            object misValue = System.Reflection.Missing.Value;
            workBook.Close(false, misValue, misValue);

            this.ReleaseObject(workSheet);
            this.ReleaseObject(workBook);
            this.ReleaseObject(excel);

            return sales;
        }

        private void ReleaseObject(object obj)
        {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
            obj = null;
            GC.Collect();
        }
    }
}