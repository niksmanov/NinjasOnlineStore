using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NinjasOnlineStore.PostgreSQL.Models
{
    [Table("stores", Schema = "public")]
    public class Store
    {
        [Key]
        public int Id { get; set; }

        [MinLength(1)]
        [MaxLength(50)]
        [Index(IsUnique = true)]
        [Required]
        public string Name { get; set; }

        [Required]
        public bool Jackets { get; set; }

        [Required]
        public bool Pants { get; set; }

        [Required]
        public bool Shoes { get; set; }

        [Required]
        public bool SwimmingSuits { get; set; }

        [Required]
        public bool TShirts { get; set; }
    }
}
