namespace Supermarket.Data.Context
{
    using System.Data.Entity;
    using System.Data.SqlClient;

    public class SupermarketSqlContext : SupermarketContext
    {
        public const string ConnectionString =
            "Server=77.70.63.194;Database=Supermarket;Persist Security Info=True;User ID=hercules;Password=pass123;";
            //"Server=62.176.105.57;Database=Supermarket;Persist Security Info=True;User ID=hercules;Password=pass123;";

        public SupermarketSqlContext()
            : base(new SqlConnection(ConnectionString))
        {
            // Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SupermarketSqlContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
        }
    }
}