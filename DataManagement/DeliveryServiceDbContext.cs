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
        public DeliveryServiceDbContext() : base()
        {
           
        }
        public DeliveryServiceDbContext(DbContextOptions<DeliveryServiceDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //optionsBuilder.UseSqlServer("Data Source=DESKTOP-5M6Q2B4;Initial Catalog=DeliveryDB;Integrated Security=True");
            optionsBuilder.UseMySql(
                "Server = localhost; Database = DeliveryDB; Uid = root; Pwd = 11111111;");
        }
      
    }
}



