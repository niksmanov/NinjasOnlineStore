using System.Data.Entity;
using NinjasOnlineStore.SqlServer.Additions;
using NinjasOnlineStore.SqlServer.Models;

namespace NinjasOnlineStore.SqlServer
{
    public interface ISqlDatabase
    {
        DbSet<Brand> Brands { get; set; }
        DbSet<Color> Colors { get; set; }
        DbSet<Jacket> Jackets { get; set; }
        DbSet<Kind> Kinds { get; set; }
        DbSet<Model> Models { get; set; }
        DbSet<Pants> Pants { get; set; }
        DbSet<Shoe> Shoes { get; set; }
        DbSet<Size> Sizes { get; set; }
        DbSet<SwimmingSuit> SwimmingSuits { get; set; }
        DbSet<TShirt> TShirts { get; set; }

        int SaveChanges();
    }
}