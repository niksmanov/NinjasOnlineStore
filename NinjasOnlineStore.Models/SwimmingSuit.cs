using NinjasOnlineStore.Models.Additions;
using System.ComponentModel.DataAnnotations;

namespace NinjasOnlineStore.Models
{
    public class SwimmingSuit
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int SizeId { get; set; }
        //Foreign key
        public virtual Size Size { get; set; }

        [Required]
        public int ColorId { get; set; }
        public virtual Color Color { get; set; }

        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }

        [Required]
        public int TypeId { get; set; }
        public virtual Type Type { get; set; }

        [Required]
        public int ModelId { get; set; }
        public virtual Model Model { get; set; }
    }
}