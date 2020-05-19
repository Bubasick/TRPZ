using System;
using System.Collections.Generic;
using System.Text;
using DataManagement.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataManagement
{
    public class DeliveryServiceDbContext : DbContext
    {
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DeliveryServiceDbContext()
        {

        }
        public DeliveryServiceDbContext(DbContextOptions<DeliveryServiceDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=localhost; Database=Delivery; Trusted_Connection=True;");
        }
    }

}

