using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NinjasOnlineStore.SqLite.Models
{
    [Table("Cities")]
    public class City
    {
        private ICollection<Shop> shops;
        public City()
        {
            this.shops = new HashSet<Shop>();
        }

        [Key]
        public int Id { get; set; }

        [MinLength(1)]
        [MaxLength(50)]
        [Index(IsUnique = true)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Shop> Shops
        {
            get { return this.shops; }
            set { this.shops = value; }
        }
    }
}
