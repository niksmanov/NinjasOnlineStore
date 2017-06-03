using NinjasOnlineStore.Models;
using NinjasOnlineStore.Models.Additions;
using System.Data.Entity;

namespace NinjasOnlineStore.Data
{
    public class NinjasOnlineStoreDbContext : DbContext
    {
        public NinjasOnlineStoreDbContext() : base("NinjasOnlineStore")
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
    }
}
