using NinjasOnlineStore.SqlServer.Additions;
using NinjasOnlineStore.SqlServer.Models;
using System.Data.Entity;

namespace NinjasOnlineStore.SqlServer
{
    public class SqlServerDbContext : DbContext, ISqlDatabase
    {
        public SqlServerDbContext() : base("NinjasOnlineStore")
        {
        }

        //Additions
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Kind> Kinds { get; set; }

        //Models
        public DbSet<Shoe> Shoes { get; set; }
        public DbSet<Jacket> Jackets { get; set; }
        public DbSet<Pants> Pants { get; set; }
        public DbSet<SwimmingSuit> SwimmingSuits { get; set; }
        public DbSet<TShirt> TShirts { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
