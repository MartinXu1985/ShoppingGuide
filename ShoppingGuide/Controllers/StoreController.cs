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
        //
        // GET: /Store/
        public ActionResult Index()
        {
            var categories = new List<Category>
    {
        new Category { CategoryName = "Sports"},
        new Category { CategoryName = "Books"},
        new Category { CategoryName = "Home"},
        new Category { CategoryName = "Clothes"},
        new Category { CategoryName = "Electronics"}

    };
            return View(categories);
        }
        //
        // GET: /Store/Browse?category=Home
        public ActionResult Browse(string category)
        {
            var categoryModel = new Category { CategoryName = category };
            return View(categoryModel);
        }
        //
        // GET: /Store/Details/5
        public ActionResult Details(int id)
        {
            var product = new Product { Title = "Product " + id };
            return View(product);
        }
    }
}