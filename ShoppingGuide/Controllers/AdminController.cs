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
using System.Net;

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

        //
        // GET: /Admin/Edit/1
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.RoleId = roleStringArrayToListItem();

            var user = await mUserManager.FindByIdAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "UserName,Id")] ApplicationUser formuser, string id, int RoleId)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.RoleId = roleStringArrayToListItem();
            var user = await mUserManager.FindByIdAsync(id);
            user.UserName = formuser.UserName;

            if (ModelState.IsValid)
            {
                //Update the user details
                await mUserManager.UpdateAsync(user);

                //If user has existing Role then remove the user from the role
                // This also accounts for the case when the Admin selected Empty from the drop-down and
                // this means that all roles for the user must be removed
                var rolesForUser = await mUserManager.GetRolesAsync(id);
                if (rolesForUser.Count() > 0)
                {
                    foreach (var item in rolesForUser)
                    {
                        var result = await mUserManager.RemoveFromRoleAsync(id, item);
                    }
                }

                //Add user to new role
                var addResult = await mUserManager.AddToRoleAsync(id, AccountController.roles[RoleId]);
                if (!addResult.Succeeded)
                {
                    ModelState.AddModelError("", addResult.Errors.First().ToString());
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


        //
        // GET: /Users/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = await mUserManager.FindByIdAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string button, string id)
        {
            if (ModelState.IsValid)
            {
                if (button == "Cancel")
                    return RedirectToAction("Users");

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var user = await mUserManager.FindByIdAsync(id);

                var logins = user.Logins;
                foreach (var login in logins)
                {
                    mUserManager.RemoveLogin(id, new UserLoginInfo(login.LoginProvider, login.ProviderKey));
                }

                //If user has existing Role then remove the user from the role
                // This also accounts for the case when the Admin selected Empty from the drop-down and
                // this means that all roles for the user must be removed
                var rolesForUser = await mUserManager.GetRolesAsync(id);
                if (rolesForUser.Count() > 0)
                {
                    foreach (var item in rolesForUser)
                    {
                        var result = await mUserManager.RemoveFromRoleAsync(id, item);
                    }
                }

                mUserDb.Users.Remove(user);
                await mUserDb.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
