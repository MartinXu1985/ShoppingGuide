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
        // POST: /Search/ sort by price by default new repo
        [HttpPost]
        public ActionResult SearchResult(String search)
        {
            //var result = dbStore.Albums.Where(g => g.Title == search);
            var result = db.Product.SqlQuery("SELECT * FROM Products WHERE Name LIKE " + "'%" + search + "%'").ToList();
            result = result.OrderBy(x => x.Price).ToList();
            return View(result);
        }
        //sort by rating
        public ActionResult SortByRating(String search1)
        {
            var result = db.Product.SqlQuery("SELECT * FROM Products WHERE Name LIKE " + "'%" + search1 + "%'").ToList();
            result = result.OrderBy(x => x.Rating).ToList();
            return View(result);
        }

        //method to sort by price back again
        public ActionResult SearchResultBack(String search)
        {
            //var result = dbStore.Albums.Where(g => g.Title == search);
            var result = db.Product.SqlQuery("SELECT * FROM Products WHERE Name LIKE " + "'%" + search + "%'").ToList();
            result = result.OrderBy(x => x.Price).ToList();
            return View(result);
        }

    }
}
