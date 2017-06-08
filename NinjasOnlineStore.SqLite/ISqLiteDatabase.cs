using System.Data.Entity;
using NinjasOnlineStore.SqLite.Models;

namespace NinjasOnlineStore.SQLite
{
    public interface ISqLiteDatabase
    {
        DbSet<City> Cities { get; set; }

        DbSet<Shop> Shops { get; set; }

        int SaveChanges();
    }
}