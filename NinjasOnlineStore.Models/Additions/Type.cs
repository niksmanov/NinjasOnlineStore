using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NinjasOnlineStore.Models.Additions
{
    public class Type
    {
        [Key]
        public int Id { get; set; }

        [MinLength(1)]
        [MaxLength(50)]
        [Index(IsUnique = true)]
        [Required]
        public string Name { get; set; }
    }
}
