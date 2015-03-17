namespace Supermarket.ConsoleClient
{
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