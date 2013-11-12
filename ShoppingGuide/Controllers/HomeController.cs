using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShoppingGuide.Controllers
{
    public class HomeController : ApiController
    {
        public string Index()
        {
            return "Hello from Home";
        }
    }
}
