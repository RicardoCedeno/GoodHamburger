using GoodHamburger.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHamburger.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<Sandwich> Sandwiches { get; set; }
        public DbSet<Extra> Extras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 🔸 Relaciones (Order -> OrderDetails)
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId);

            // 🔸 Relaciones (ItemType -> OrderDetails)
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.ItemType)
                .WithMany(it => it.OrderDetails)
                .HasForeignKey(od => od.ItemTypeId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
