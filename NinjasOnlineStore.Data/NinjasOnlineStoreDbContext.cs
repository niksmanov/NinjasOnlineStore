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
        public virtual IDbSet<Size> Sizes { get; set; }
        public virtual IDbSet<Brand> Brands { get; set; }
        public virtual IDbSet<Model> Models { get; set; }
        public virtual IDbSet<Color> Colors { get; set; }
        public virtual IDbSet<Type> Types { get; set; }

        //Models
        public virtual IDbSet<Shoe> Shoes { get; set; }

    }
}
