﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace ShoppingGuide.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Hello from Home";
        }
    }
}
