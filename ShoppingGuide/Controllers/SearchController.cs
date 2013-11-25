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

        // POST: /Search/
        [HttpPost]
        public ActionResult SearchResult(String search)
        {
            //var result = dbStore.Albums.Where(g => g.Title == search);
            var result = db.Product.SqlQuery("SELECT * FROM Products WHERE Name LIKE " + "'%" + search + "%'").ToList();
            return View(result);
        }
    }
}
