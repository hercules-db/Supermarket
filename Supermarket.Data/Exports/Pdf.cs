using System;
using System.Linq;
using Supermarket.Data.Context;

namespace Supermarket.Data.Exports
{
    public class Pdf
    {
        public static void Export(ISupermarketContext context, DateTime startDate, DateTime endDate)
        {
            var sales = (from s in context.Sales
                         join p in context.Products on s.ProductId equals p.ProductId
                         join v in context.Vendors on p.VendorId equals v.VendorId
                         where s.DateSold >= startDate && s.DateSold < endDate
                         select new
                         {
                             s.ProductId,
                             p.ProductName,
                             v.VendorName,
                             QuantitySold = s.Quantity,
                             TotalIncomes = s.SaleSum
                         }).ToList();


        }
    }
}