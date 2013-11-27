using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingGuide.Models;
using System.IO;

namespace ShoppingGuide.Controllers
{
    [Authorize(Roles="admin")]
    public class ProductManageController : Controller
    {
        private ShoppingGuideDB db = new ShoppingGuideDB();
        //
        // GET: /ProductManage/

        public ActionResult Index()
        {
            return View(db.Product.ToList());
        }

        //
        // GET: /ProductManage/Details/5

        public ActionResult Details(int id = 0)
        {
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // GET: /ProductManage/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ProductManage/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                // Verify that the user selected a file
                if (file != null && file.ContentLength > 0)
                {
                    // extract only the fielname
                    var fileName = Path.GetFileName(file.FileName);
                    // store the file inside ~/Content/Uploads folder
                    var path = Path.Combine(Server.MapPath("~/Content/Uploads"), fileName);
                    file.SaveAs(path);

                    // Save the image url
                    product.Image = "~/Content/Uploads/" + fileName.ToString();
                }

                db.Product.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        //
        // GET: /ProductManage/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // POST: /ProductManage/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        //
        // GET: /ProductManage/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // POST: /ProductManage/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Product.Find(id);
            db.Product.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}