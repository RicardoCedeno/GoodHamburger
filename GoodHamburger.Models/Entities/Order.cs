using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHamburger.Models.Entities
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        public string Id { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public string CustomerName { get; set; } = string.Empty;
        public double Total { get; set; } = 0;

        public List<OrderDetail> OrderDetails { get; set; } = [];
    }
}
