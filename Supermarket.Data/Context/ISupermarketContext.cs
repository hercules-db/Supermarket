namespace Supermarket.Data.Context
{
    using System;
    using System.Data.Entity;

    using Models;

    public interface ISupermarketContext : IDisposable
    {
        IDbSet<Supermarket> Supermarkets { get; set; }

        IDbSet<Product> Products { get; set; }

        IDbSet<Measure> Measures { get; set; }

        IDbSet<Vendor> Vendors { get; set; }

        IDbSet<Sale> Sales { get; set; }

        IDbSet<Expense> Expenses { get; set; }

        void SaveChanges();
    }
}