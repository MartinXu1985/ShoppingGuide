using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using ShoppingGuide.Models;

namespace ShoppingGuide.Controllers
{
    public class HomeController : Controller
    {
        ShoppingGuideDB db = new ShoppingGuideDB();
        private const int MAX_FEATURED_ITEMS = 4;

        public ActionResult Index()
        {

            //// Create a list to store the products
            //List<Product> products = new List<Product>();
            //Random randGen = new Random();
            //Product tempProd;

            //// For random product selection, we don't want to display the same
            //// product twice.
            //Dictionary<string, int> dictionary = new Dictionary<string, int>();

            //// Get the number of products available as it should be our max.
            //// Loop through the max featured items and put it into a list
            //int maxDbCount = db.Product.Count();

            //for(int i = 0; (i < MAX_FEATURED_ITEMS) && (i < maxDbCount);)
            //{
            //    // Get a random number setting maxDbCount as max.
            //    int rand = randGen.Next(maxDbCount);

            //    // Use the random number within range to get a product at this
            //    // index.
            //    tempProd = db.Product.ElementAt(rand);

            //    // Add it to our dictionary list if it doesn't already exist
            //    if (!dictionary.ContainsKey(tempProd.Name))
            //    {
            //        // Since it doesn't exist, add it to our dictionary.
            //        dictionary.Add(tempProd.Name, i);

            //        // Now add it to our products list
            //        products.Add(tempProd);

            //        // Increment our i, indicating that we've successfully
            //        // added an element
            //        i++;
            //    }
            //}
            //var result = dbStore.Albums.Where(g => g.Title == search);
            //return View(products.ToList());
            string query = "SELECT TOP " + MAX_FEATURED_ITEMS + " * FROM Products ORDER BY NEWID()";
            var result = db.Product.SqlQuery(query).ToList();

            return View(result.ToList());
        }
    }
}
