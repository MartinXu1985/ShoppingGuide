using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingGuide.Models;
using System.Data;
using System.Data.Entity;

namespace ShoppingGuide.Controllers
{
    public class StoreController : Controller
    {
        ShoppingGuideDB db = new ShoppingGuideDB();
        
        //
        // GET: /Store/Browse?category=Home
        public ActionResult Browse(string category, string sort = "None")
        {
            var result = db.Product.Where(g => g.CategoryName == category).ToList();

            ViewBag.ProductCategory = category;

            if (sort.Equals("None"))
            {
                // Don't need to do anything
            }
            else if (sort.Equals("Price"))
            {
                result = result.OrderBy(x => x.Price).ToList();
            }
            else if (sort.Equals("Rating"))
            {
                result = result.OrderBy(x => x.Rating).ToList();
            }

            return View(result);
        }

        //
        // GET: /Store/Details/5
        public ActionResult Details(int id)
        {
            Product product = db.Product.Find(id);

            if (product != null)
            {
                ViewBag.ProductCategory = product.CategoryName;
            }

            return View(product);
        }

        //POST: /Store/Rate
        [HttpPost]
        public ActionResult Rate(String rating, int iD)
        {
            Product product = db.Product.Find(iD);
            int votes = product.Votes + 1;
            double average = ((product.Rating * product.Votes) + Convert.ToDouble(rating)) / votes;
            String sqlString = "UPDATE Products SET Votes =  " + votes + ", Rating = " + average + " WHERE ProductId = " + iD;
            db.Database.ExecuteSqlCommand(sqlString);
            db.SaveChanges();
            return RedirectToAction("Details",new{id = iD});
        }

        public ActionResult BrowseSort(String sort, string category)
        {
            var result = db.Product.Where(g => g.CategoryName == category).ToList();
            ViewBag.ProductCategory = category;

            if (sort.Equals("Price"))
            {
                result = result.OrderBy(x => x.Price).ToList();
            }
            else if (sort.Equals("Rating"))
            {
                result = result.OrderBy(x => x.Rating).ToList();
            }

            return View("../Store/Browse", result);
        }
    }
}