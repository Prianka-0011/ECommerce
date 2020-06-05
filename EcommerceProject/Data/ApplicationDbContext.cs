using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EcommerceProject.Models;

namespace EcommerceProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<EcommerceProject.Models.ProductTypes> ProductTypes { get; set; }
        public DbSet<EcommerceProject.Models.SpecialTag> SpecialTag { get; set; }
        public DbSet<EcommerceProject.Models.Product> Products { get; set; }
        public DbSet<EcommerceProject.Models.CartItem> CartItems { get; set; }
        public DbSet<EcommerceProject.Models.Order> Orders { get; set; }
        public DbSet<EcommerceProject.Models.OrderDetails> OrderDetails { get; set; }
    }
}
