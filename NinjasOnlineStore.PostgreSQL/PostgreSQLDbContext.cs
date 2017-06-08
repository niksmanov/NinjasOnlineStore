using NinjasOnlineStore.PostgreSQL.Models;
using System.Data.Entity;
using System;

namespace NinjasOnlineStore.PostgreSQL
{
    public class PostgreSQLDbContext : DbContext, IPgDatabase
    {
        public PostgreSQLDbContext() : base(nameOrConnectionString: "StoresAvailability")
        {
        }

        public DbSet<Store> Stores { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
