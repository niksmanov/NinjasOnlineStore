using System.Data.Entity;
using NinjasOnlineStore.PostgreSQL.Models;

namespace NinjasOnlineStore.PostgreSQL
{
    public interface IPgDatabase
    {
        DbSet<Store> Stores { get; set; }

        int SaveChanges();
    }
}