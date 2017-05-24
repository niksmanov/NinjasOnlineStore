using NinjasOnlineStore.Models;
using System.Data.Entity;

namespace NinjasOnlineStore.Data
{
    public class NinjasOnlineStoreDbContext : DbContext
    {
        public NinjasOnlineStoreDbContext() : base("NinjasOnlineStore")
        {
        }

        //Referrer every model here so entity framework can know which tables to create
        public virtual DbSet<SportItem> SportItems { get; set; } //use plural
    }
}
