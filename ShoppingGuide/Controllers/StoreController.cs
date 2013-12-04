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
    public class StoreController : Controller
    {
        ShoppingGuideDB db = new ShoppingGuideDB();
        
        //
        // GET: /Store/Browse?category=Home
        public ActionResult Browse(string category, string sort = "None")
        {
            var result = db.Product.Where(g => g.CategoryName == category).ToList();

            ViewBag.ProductCategory = category;

            if (sort.Equals("None"))
            {
                // Don't need to do anything
            }
            else if (sort.Equals("Price"))
            {
                result = result.OrderBy(x => x.Price).ToList();
            }
            else if (sort.Equals("Rating"))
            {
                result = result.OrderBy(x => x.Rating).ToList();
            }

            return View(result);
        }

        //
        // GET: /Store/Details/5
        public ActionResult Details(int id)
        {
            Product product = db.Product.Find(id);

            if (product != null)
            {
                ViewBag.ProductCategory = product.CategoryName;

                // Check if there is already a rating for this product and this user.
                var result = db.Rating.SqlQuery("SELECT * From Ratings WHERE ProductId ='" + id + "' AND UserName = '" + User.Identity.Name + "'").ToList();

                ViewBag.alreadyRated = false;
                if (result.Count != 0)
                {
                    ViewBag.alreadyRated = true;
                }
            }

            return View(product);
        }

        // 
        public ActionResult DetailsUpdate(int id)
        {
            var result = db.Comments.SqlQuery("Select * from Comments").ToList();
            var prodResult = db.Product.SqlQuery("Select * from Products WHERE  ProductId ='" + id + "'").ToList();
            var myFlag = false;
            foreach (Comments cmt in prodResult[0].Comments)
                if (cmt.Username == User.Identity.Name)
                    myFlag = true;
            if (myFlag == false)
            {
                Product product = db.Product.Find(id);
                if (Request["comment"] != null)
                {
                    //String sqlString = "INSERT into Comments values (" +Request["comment"] +","+ id +","+ User.Identity.Name+")";
                    //db.Database.ExecuteSqlCommand(sqlString);
                    Comments c = new Comments();
                    c.CommentId = result.Count + 1;
                    c.Comment = Request["comment"];
                    c.Username = User.Identity.Name;

                    if (product.Comments == null)
                    {
                        product.Comments = new List<Comments>();
                    }

                    product.Comments.Add(c);
                    db.Comments.Add(c);
                    db.SaveChanges();

                    // Take a note that the user Comment.
                    ViewBag.alreadyCommented = true;
                }
            }
            return RedirectToAction("Details", new { id = id });
        }

        // GET: /Store/Rate
        [Authorize]
        public ActionResult Rate(String rating, int iD)
        {
            // Check if there is already a rating for this product and this user.
            var result = db.Rating.SqlQuery("SELECT * From Ratings WHERE ProductId ='" + iD + "' AND UserName = '" + User.Identity.Name + "'").ToList();

            // Only permit rating if an entry is not found
            if (result.Count == 0)
            {
                Product product = db.Product.Find(iD);
                int votes = product.Votes + 1;
                double average = ((product.Rating * product.Votes) + Convert.ToDouble(rating)) / votes;
                String sqlString = "UPDATE Products SET Votes =  " + votes + ", Rating = " + average + " WHERE ProductId = " + iD;
                db.Database.ExecuteSqlCommand(sqlString);

                Rating newRating = new Rating();
                newRating.ProductId = iD.ToString();
                newRating.UserName = User.Identity.Name;

                // Now add a new rating entry to the DB.
                db.Rating.Add(newRating);
                db.SaveChanges();

                // Take a note that the user rated.
                ViewBag.alreadyRated = true;
            }
            return RedirectToAction("Details",new{id = iD});
        }

        public ActionResult BrowseSort(String sort, string category)
        {
            var result = db.Product.Where(g => g.CategoryName == category).ToList();
            ViewBag.ProductCategory = category;

            if (sort.Equals("Price"))
            {
                result = result.OrderBy(x => x.Price).ToList();
            }
            else if (sort.Equals("Rating"))
            {
                result = result.OrderBy(x => x.Rating).ToList();
            }

            return View("../Store/Browse", result);
        }
    }
}