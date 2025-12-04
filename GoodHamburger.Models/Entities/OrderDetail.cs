using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHamburger.Models.Entities
{
    [Table("OrderDetails")]
    public class OrderDetail
    {
        [Key]
        public string Id { get; set; } = string.Empty;
        [ForeignKey("Order")]
        public string OrderId { get; set; } = string.Empty;
        [ForeignKey("ItemType")]
        public string ItemTypeId { get; set; } = string.Empty;
        public string ItemId {  get; set; } = string.Empty;
        public int Quantity { get; set; } = 0;
        public double UnitPrice { get; set; } = 0;
        public double SubTotal {  get; set; } = 0;

        public Order Order { get; set; } = new();
        public ItemType ItemType { get; set; } = new();
    }
}
