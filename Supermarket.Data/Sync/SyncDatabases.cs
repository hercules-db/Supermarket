namespace Supermarket.Data.Sync
{
    using System.Data.Entity.Migrations;
    using Context;
    using System;

    public sealed class SyncDatabases : DbMigrationsConfiguration<SupermarketSqlContext>
    {

        public static void MsSqlMySql(ISupermarketContext context)
        {
            Console.WriteLine("################################# Done ! #################################");
        }
    }
}
