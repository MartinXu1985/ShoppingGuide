using System.Web;
using System.Web.Optimization;
using ShoppingGuide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace ShoppingGuide
{
    public class LoadDbSampleData
    {
        public static void loadData()
        {
            // Drop the database first..
            System.Data.Entity.Database.SetInitializer
                (new DropCreateDatabaseAlways<ShoppingGuideDB>());

            ShoppingGuideDB db = new ShoppingGuideDB();

            new List<Product>
           {
               new Product { CategoryId = 0, Name = "desk", Price = 59.99, ProductUrl ="/content/", Description = "test", CategoryName = "Home" },
               new Product { CategoryId = 1, Name = "ball", Price = 19.99, ProductUrl ="/content/", Description = "test", CategoryName = "Sports" },
               new Product { CategoryId = 2, Name = "textbook", Price = 29.99, ProductUrl ="/content/", Description = "test", CategoryName = "Books" },
               new Product { CategoryId = 3, Name = "T-shirt", Price = 9.99, ProductUrl ="/content/", Description = "test", CategoryName = "Clothes" },
               new Product { CategoryId = 4, Name = "computer", Price = 599.99, ProductUrl ="/content/", Description = "test", CategoryName = "Electronics" },
           }.ForEach(a => db.Product.Add(a));

            db.SaveChanges();
        }
    }
}
