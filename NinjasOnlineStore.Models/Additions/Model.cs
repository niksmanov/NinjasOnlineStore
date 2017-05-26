using System.ComponentModel.DataAnnotations;

namespace NinjasOnlineStore.Models.Additions
{
    public class Model
    {
        [Key]
        public int Id { get; set; }

        [MinLength(1)]
        [Required]
        public string Name { get; set; }
    }
}
