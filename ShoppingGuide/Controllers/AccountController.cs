using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingGuide.Models;

namespace ShoppingGuide.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        private ShoppingGuideDB db = new ShoppingGuideDB();

        // GET: /Account/
        public ViewResult Index() 
        {
            var users = db.Users;
            return View(users.ToList()); 
        }
    }
}
