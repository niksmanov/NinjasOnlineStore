using NinjasOnlineStore.PostgreSQL.Models;
using System.Data.Entity;

namespace NinjasOnlineStore.PostgreSQL
{
    public class PostgreSQLDbContext : DbContext
    {
        public PostgreSQLDbContext() : base(nameOrConnectionString: "StoresAvailability")
        {
        }

        public DbSet<Store> Stores { get; set; }
    }
}
