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
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<Sandwich> Sandwiches { get; set; }
        public DbSet<Extra> Extras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Purchase>()
                .HasOne(p => p.Order)
                .WithMany(o => o.Purchases)
                .HasForeignKey(p => p.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
            // 🔸 Relaciones (ItemType -> Orders)
        }
    }
}
