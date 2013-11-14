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
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}