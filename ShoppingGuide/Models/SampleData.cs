using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ShoppingGuide.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<ShoppingGuideDB>
    {
        protected override void Seed(ShoppingGuideDB context)
        {
            /*
            var objects = new List<Object>
            {
                new Object { Variable = "value1" },
                new Object { Variable = "value2" },
                new Object { Variable = "value3" },
                new Object { Variable = "value4" },
                new Object { Variable = "value5" },
                new Object { Variable = "value6" },
                new Object { Variable = "value7" },
            };
            */
            var Product = new List<Product>
           {
               new Product { Name = "desk", CategoryName = "Home", Price = 59.99, ProductUrl ="/content/"},
               new Product { Name = "ball", CategoryName = "Sports", Price = 19.99, ProductUrl ="/content/"},
               new Product { Name = "textbook", CategoryName = "Books", Price = 29.99, ProductUrl ="/content/"},
               new Product { Name = "T-shirt", CategoryName = "Clothes", Price = 9.99, ProductUrl ="/content/"},
               new Product { Name = "computer", CategoryName = "Electronics", Price = 599.99, ProductUrl ="/content/"},
           };
        }
    }
}