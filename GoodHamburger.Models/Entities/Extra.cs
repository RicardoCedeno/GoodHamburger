using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHamburger.Models.Entities
{
    [Table("Extras")]
    public class Extra
    {
        [Key]
        public string Id { get; set; } = string.Empty;
        public string ExtraName { get; set; } = string.Empty;
        public double Price { get; set; } = 0;
    }
}
