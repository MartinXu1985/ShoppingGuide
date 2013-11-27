using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingGuide.Models;

namespace ShoppingGuide.Controllers
{
    public class StoreController : Controller
    {
        ShoppingGuideDB db = new ShoppingGuideDB();

        //
        // GET: /Store/Browse?category=Home
        public ActionResult Browse(string category)
        {
            var result = db.Product.Where(g => g.CategoryName == category);

            ViewBag.ProductCategory = category;

            return View(result.ToList());
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
    }
}