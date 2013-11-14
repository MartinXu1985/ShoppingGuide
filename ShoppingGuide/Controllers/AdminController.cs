using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingGuide.Models;
using System.Web.Http;

namespace ShoppingGuide.Controllers
{
    public class AdminController : Controller
    {
        private ShoppingGuideDB storeDB = new ShoppingGuideDB();
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            
            return View();
        }

        
    }
}
