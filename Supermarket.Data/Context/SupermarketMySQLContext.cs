namespace Supermarket.Data.Context
{
    using System.Data.Entity;
    using MySql.Data.MySqlClient;

    //[DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class SupermarketMySqlContext : SupermarketContext
    {
        public const string ConnectionString = "server=95.43.237.41;port=3306;database=hercules;uid=hercules;pwd=h3rcul3s;Persist Security Info=True;";

        public SupermarketMySqlContext()
            : base(new MySqlConnection(ConnectionString))
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SupermarketSqlContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<T>().MapToStoredProcedures();
            //modelBuilder.HasDefaultSchema("hercules");
        }
    }
}