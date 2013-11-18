using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using ShoppingGuide.Models;

namespace ShoppingGuide.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        public ApplicationDbContext mUserDb { get; private set; }
        public UserManager<ApplicationUser> mUserManager { get; private set; }
        public RoleManager<IdentityRole> mRoleManager { get; private set; }

        public AdminController()
        {
            mUserDb = new ApplicationDbContext();
            mUserManager = new UserManager<ApplicationUser>
                            (new UserStore<ApplicationUser>(mUserDb));
            mRoleManager = new RoleManager<IdentityRole>
                            (new RoleStore<IdentityRole>(mUserDb));
        }

        //
        // GET: /Admin/
        public ActionResult Index()
        {
            return RedirectToAction("Users", "Admin");
        }

        //
        // GET: /Admin/Users
        public ActionResult Users()
        {
            return View(mUserDb.Users.ToList());
        }

        //
        // GET: /Admin/Create
        public ActionResult Create()
        {
            // Get the list of Roles
            ViewBag.RoleId = roleStringArrayToListItem();
            return View();
        }

        //
        // POST: /Admin/Create
        [HttpPost]
        public async Task<ActionResult> Create(RegisterViewModel userViewModel, int RoleId)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser();
                user.UserName = userViewModel.UserName;
                var adminresult = await mUserManager.CreateAsync(user, userViewModel.Password);

                // Add User to Role Admin
                if (adminresult.Succeeded)
                {
                    var result = await mUserManager.AddToRoleAsync(user.Id, AccountController.roles[RoleId]);
                    if (!result.Succeeded)
                    {
                        ModelState.AddModelError("", result.Errors.First().ToString());
                        ViewBag.RoleId = roleStringArrayToListItem();
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("", adminresult.Errors.First().ToString());
                    ViewBag.RoleId = roleStringArrayToListItem();
                    return View();

                }
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.RoleId = roleStringArrayToListItem();
                return View();
            }
        }

        public IEnumerable<SelectListItem> roleStringArrayToListItem()
        {
            return AccountController.roles.Select((r, index) => 
                new SelectListItem { Text = r, Value = index.ToString() });
        }
    }
}
