using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingGuide.Models
{
    public class Rating
    {
        public int RatingId { set; get; }

        public string ProductId { set; get; }
        public string UserName { set; get; }
    }
}