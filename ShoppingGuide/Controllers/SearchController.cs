using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingGuide.Models;

namespace ShoppingGuide.Controllers
{
    public class SearchController : Controller
    {
        ShoppingGuideDB db = new ShoppingGuideDB();

        //
        // GET: /Search/

        public ActionResult Index()
        {
            return View();
        }

        // POST: /Search/SearchResult
        [HttpPost]
        public ActionResult SearchResult(String search)
        {
            var result = db.Product.SqlQuery("SELECT * FROM Products WHERE Name LIKE " + "'%" + search + "%'").ToList();
            ViewBag.searchQuery = search;
            ViewBag.abc = search;

            return View(result);
        }

        public ActionResult SearchSort(String sort, string search)
        {
            var result = db.Product.SqlQuery("SELECT * FROM Products WHERE Name LIKE " + "'%" + search + "%'").ToList();
            ViewBag.searchQuery = search;

            if (sort.Equals("Price"))
            {
                result = result.OrderBy(x => x.Price).ToList();
            }
            else if (sort.Equals("Rating"))
            {
                result = result.OrderBy(x => x.Rating).ToList();
            }

            return View("../Search/SearchResult", result);
        }
    }
}
