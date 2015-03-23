using System.Data.Entity.Core.Objects;
using MySql.Data.MySqlClient;

namespace Supermarket.Data.Sync
{
    using System.Data.Entity.Core;
    using System.Linq;
    using Models;
    using System;
    using Context;
    
    public sealed class SyncDatabases : SupermarketContext
    {
        public static string MsSqlMySql(ISupermarketContext mssqlContext, ISupermarketContext mysqlContext)
        {
            var SalesSynced = 0;
            var ExpensesSynced = 0;
            var ItemsFailed = 0;

            /**
             * Syncronizing Sales Data
             */
            var mssqlList = mssqlContext.Sales.ToList();
            if (mssqlList.Any())
            {
                foreach (var msItem in mssqlList)
                {
                    var id = msItem.SaleId;
                    if (!mysqlContext.Sales.Any(e => e.SaleId == id))
                    {
                        mysqlContext.Sales.Add(new Sale()
                        {
                            SaleId = msItem.SaleId,
                            SupermarketId = msItem.SupermarketId,
                            ProductId = msItem.ProductId,
                            DateSold = msItem.DateSold,
                            Quantity = msItem.Quantity,
                            UnitPrice = msItem.UnitPrice,
                            SaleSum = msItem.SaleSum
                        });

                        try
                        {
                            mysqlContext.SaveChanges();
                            Console.WriteLine("No conflicts. Sale #" + msItem.SaleId + " Added.");
                            SalesSynced++;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("########### MYSQL ERROR - Exception ############## ");
                            Console.WriteLine(ex);
                            ItemsFailed++;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("NO SALES SO FAR!");
            }

            /**
             * Syncronizing Sales Data
             */
            var mssqlListEx = mssqlContext.Expenses.ToList();
            if (mssqlListEx.Any())
            {
                foreach (var msItem in mssqlListEx)
                {
                    var id = msItem.ExpenseId;
                    if (!mysqlContext.Expenses.Any(e => e.ExpenseId == id))
                    {
                        mysqlContext.Expenses.Add(new Expense()
                        {
                            ExpenseId = msItem.ExpenseId,
                            VendorId = msItem.VendorId,
                            ExpenseDate = msItem.ExpenseDate,
                            ExpenseAmount = msItem.ExpenseAmount
                        });

                        try
                        {
                            mysqlContext.SaveChanges();
                            Console.WriteLine("No conflicts. Expense #" + msItem.ExpenseId + " Added.");
                            ExpensesSynced++;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("########### MYSQL ERROR Expenses - Exception ############## ");
                            Console.WriteLine(ex);
                            ItemsFailed++;
                        }
                    }
                }
            }

            return SalesSynced + " Sales synced, " + ExpensesSynced + " Expenses synced, " + ItemsFailed +
                   " items failed to sync! \n Check the MySQL database for more details on: \n http://95.43.237.41/phpmyadmin/";

        }
    }
}
