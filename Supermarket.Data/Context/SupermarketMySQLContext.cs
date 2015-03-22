namespace Supermarket.Data.Context
{
    using System.Data.Entity;
    using MySql.Data.MySqlClient;

    public class SupermarketMySqlContext : SupermarketContext
    {
        public const string ConnectionString =
            "Data Source=95.43.237.41:3306;Persist Security Info=True;database=hercules;uid=hercules;pwd=h3rcul3s;";

        public SupermarketMySqlContext()
            : base(new MySqlConnection(ConnectionString))
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("hercules");
        }
    }
}