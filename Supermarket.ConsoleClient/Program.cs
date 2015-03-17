namespace Supermarket.ConsoleClient
{
    using System;
    using System.Linq;

    using Data;
    using Data.Migrations;

    public class Program
    {
        public static void Main()
        {
            Configuration.Sync(new SupermarketSqlContext());
        }
    }
}