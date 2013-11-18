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
    [Authorize(Roles="admin")]
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
