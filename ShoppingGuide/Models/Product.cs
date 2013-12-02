using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingGuide.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public int CategoryId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public double Rating { get; set; }

        public int Votes { get; set; }

        public string ProductUrl { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }

        public string Image { get; set; }

        public string Title { get; set; }
        //attributes;
    }
}