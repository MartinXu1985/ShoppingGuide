using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShoppingGuide.Models;
using ShoppingGuide.Helpers;

namespace ShoppingGuide.Controllers
{
    public class AccountController : ApiController
    {
        AccountDbAccess accDb = new AccountDbAccess();

        /* TODO: This is just temporary for testing.  We definitely won't send
         * back username and password! Most likely will just send back 
         * result.*/
        [HttpGet]
        public Account FindAccount(string username, string password)
        {
            return accDb.findAccount(username, password);
        }
    }
}
