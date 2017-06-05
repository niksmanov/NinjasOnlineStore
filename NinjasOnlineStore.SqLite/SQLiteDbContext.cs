using NinjasOnlineStore.SqLite.Models;
using SQLite.CodeFirst;
using System.Data.Entity;

namespace NinjasOnlineStore.SQLite
{
    public class SQLiteDbContext : DbContext
    {
        public SQLiteDbContext() : base("Stores")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<SQLiteDbContext>(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);
        }

        public DbSet<Shop> Shops { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}
