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
        public IDbSet<Size> Sizes { get; set; }
        public IDbSet<Brand> Brands { get; set; }
        public IDbSet<Model> Models { get; set; }
        public IDbSet<Color> Colors { get; set; }
        public IDbSet<Type> Types { get; set; }

        //Models
        public IDbSet<Shoe> Shoes { get; set; }
        public IDbSet<Jacket> Jacket { get; set; }
        public IDbSet<Pants> Pants { get; set; }

    }
}
