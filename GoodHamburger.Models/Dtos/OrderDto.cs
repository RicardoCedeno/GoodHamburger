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
        public string ItemTypeId { get; set; } = string.Empty;
        public string ProductId { get; set; } = string.Empty;
        public int Quantity { get; set; } = 0;
        public double UnitPrice { get; set; } = 0;
        public double SubTotal { get; set; } = 0;
        public string ItemTypeName {  get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
    }
}
