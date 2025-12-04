using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHamburger.Models.Entities
{
    [Table("Sandwiches")]
    public class Sandwich
    {
        [Key]
        public string Id { get; set; } = string.Empty;
        public string SandwichName { get; set; } = string.Empty;
        public double Price { get; set; } = 0;
    }
}
