namespace Supermarket.Console
{
    using Data.Context;

    public class Program
    {
        public static void Main()
        {
            using (var oracle = new SupermarketOracleContext())
            {
                
            }

            using (var sql = new SupermarketSqlContext())
            {
                
            }
        }
    }
}