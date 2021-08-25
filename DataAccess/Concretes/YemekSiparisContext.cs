using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Concretes.Entities;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concretes
{
    public class YemekSiparisContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-OFJU1E2;Database=YemekSiparis;Trusted_Connection=true");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<RestaurantInfo> RestaurantInfo { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }


    }
}
