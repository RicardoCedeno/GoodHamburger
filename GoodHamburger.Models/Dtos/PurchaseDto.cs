using GoodHamburger.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHamburger.Models.Dtos
{
    public class PurchaseDto
    {
        [Key]
        public string Id { get; set; } = string.Empty;
        public string OrderId { get; set; } = string.Empty;

        public string ItemTypeId { get; set; } = string.Empty;
        public string ItemTypeName {  get; set; } = string.Empty; 
        public string ProductId { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; } = 0;
        public double UnitPrice { get; set; } = 0;
        public double SubTotal { get; set; } = 0;
        //public ItemType? ItemType { get; set; } = new();

        //public Order? Order { get; set; } = new();
    }
}
