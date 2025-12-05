using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoodHamburger.Models.Entities
{
    [Table("ItemTypes")]
    public class ItemType
    {
        [Key]
        public string Id { get; set; } = string.Empty;
        public string ItemName { get; set; } = string.Empty;
        public List<Purchase> Orders { get; set; } = [];
    }
}
