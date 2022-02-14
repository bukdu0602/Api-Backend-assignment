using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Api_day1_Assignment.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options) { }

        // Define entity collections.
        public DbSet<Produce> Produces { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<ProduceSupplier> ProduceSuppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define composite primary keys.
            modelBuilder.Entity<ProduceSupplier>()
                .HasKey(ps => new { ps.ProduceID, ps.SupplierID });

            // Define foreign keys here. Do not use foreign key annotations.
            modelBuilder.Entity<ProduceSupplier>()
                .HasOne(p => p.Produce)
                .WithMany(p => p.ProduceSuppliers)
                .HasForeignKey(fk => new { fk.ProduceID })
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            modelBuilder.Entity<ProduceSupplier>()
                .HasOne(p => p.Supplier)
                .WithMany(p => p.ProduceSuppliers)
                .HasForeignKey(fk => new { fk.SupplierID })
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            modelBuilder.Entity<Produce>().HasData(
                new Produce { ProduceID = 1, Description = "Oranges" },
                new Produce { ProduceID = 2, Description = "Apples" },
                new Produce { ProduceID = 3, Description = "Peaches" },
                new Produce { ProduceID = 4, Description = "Strawberries" },
                new Produce { ProduceID = 5, Description = "Watermelon" });

            modelBuilder.Entity<Supplier>().HasData(
                new Supplier { SupplierID = 1, SupplierName = "Kin's Market" },
                new Supplier { SupplierID = 2, SupplierName = "Fresh Street Market" },
                new Supplier { SupplierID = 3, SupplierName = "Fresh Street Market" },
                new Supplier { SupplierID = 4, SupplierName = "Fresh Street Market" },
                new Supplier { SupplierID = 5, SupplierName = "Fresh Street Market" });


            modelBuilder.Entity<ProduceSupplier>().HasData(
                new ProduceSupplier { SupplierID = 1, ProduceID = 1, Qty = 25 },
                new ProduceSupplier { SupplierID = 2, ProduceID = 2, Qty = 12 },
                new ProduceSupplier { SupplierID = 3, ProduceID = 3, Qty = 12 },
                new ProduceSupplier { SupplierID = 4, ProduceID = 4, Qty = 12 },
                new ProduceSupplier { SupplierID = 2, ProduceID = 5, Qty = 12 },
                new ProduceSupplier { SupplierID = 5, ProduceID = 1, Qty = 12 },
                new ProduceSupplier { SupplierID = 3, ProduceID = 2, Qty = 30 });
        }

        // Entity Classes.
        


        
    }

}
