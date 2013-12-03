using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ShoppingGuide.Models;

namespace ShoppingGuide.Models
{
    public class ShoppingGuideDB : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<Cart>
Carts { get; set; }
        public DbSet<Order> Orders
        { get; set; }
        public DbSet<OrderDetail>
OrderDetails { get; set; }
        public DbSet<Comments> Comments { get; set; }

    }
}