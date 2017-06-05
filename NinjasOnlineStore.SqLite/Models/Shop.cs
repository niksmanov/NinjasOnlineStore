using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NinjasOnlineStore.SqLite.Models
{
    [Table("Shops")]
    public class Shop
    {
        [Key]
        public int Id { get; set; }

        [MinLength(1)]
        [MaxLength(50)]
        [Index(IsUnique = true)]
        [Required]
        public string Name { get; set; }

        [Required]
        public int CityId { get; set; }
        public virtual City City { get; set; }
    }
}
