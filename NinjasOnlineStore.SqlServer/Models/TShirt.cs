using NinjasOnlineStore.SqlServer.Additions;
using NinjasOnlineStore.SqlServer.Contracts;
using System.ComponentModel.DataAnnotations;

namespace NinjasOnlineStore.SqlServer.Models
{
    public class TShirt : IObject
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int SizeId { get; set; }
        public virtual Size Size { get; set; }

        [Required]
        public int ColorId { get; set; }
        public virtual Color Color { get; set; }

        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }

        [Required]
        public int KindId { get; set; }
        public virtual Kind Kind { get; set; }

        [Required]
        public int ModelId { get; set; }
        public virtual Model Model { get; set; }
    }
}
