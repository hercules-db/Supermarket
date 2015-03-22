namespace Supermarket.Data.Sync
{
    using System;
    using System.Data.Entity.Migrations;

    using Context;

    public sealed class SyncDatabases : DbMigrationsConfiguration<SupermarketSqlContext>
    {
        public static void MsSqlMySql(ISupermarketContext context)
        {
            Console.WriteLine("################################# Done ! #################################");
        }
    }
}
