using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHamburger.Models.Dtos
{
    public class SandwichDto
    {
        public string Id { get; set; } = string.Empty;
        public string SandwichName { get; set; } = string.Empty;
        public double Price { get; set; } = 0;

        public SandwichDto(SandwichDto sandwich)
        {
            Id = sandwich.Id;
            SandwichName = sandwich.SandwichName;
            Price = sandwich.Price;
        }

        public SandwichDto() { }
    }
}
