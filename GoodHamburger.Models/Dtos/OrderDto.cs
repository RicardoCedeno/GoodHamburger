using GoodHamburger.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHamburger.Models.Dtos
{
    public class OrderDto
    {
        public string Id { get; set; } = string.Empty;
        public double Total { get; set; } = 0;
        public List<PurchaseDto>? Purchases { get; set; } = [];
    }
}
