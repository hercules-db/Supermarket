namespace Supermarket.Data.Context
{
    using System.Data.Entity;
    using MySql.Data.MySqlClient;

    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class SupermarketMySqlContext : SupermarketContext
    {
        public const string ConnectionString =
            "server=62.176.105.57;port=3306;database=hercules;uid=hercules;pwd=pass123;Persist Security Info=True;";

        public SupermarketMySqlContext()
            : base(new MySqlConnection(ConnectionString))
        {
        }
    }
}