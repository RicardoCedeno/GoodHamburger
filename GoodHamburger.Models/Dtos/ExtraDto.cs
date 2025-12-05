using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHamburger.Models.Dtos
{
    public class ExtraDto
    {
        public string Id { get; set; } = string.Empty;
        public string ExtraName { get; set; } = string.Empty;
        public double Price { get; set; } = 0;

        public ExtraDto(ExtraDto extra)
        {
            Id = extra.Id;
            ExtraName = extra.ExtraName;
            Price = extra.Price;
        }
        public ExtraDto() { }
    }
}
