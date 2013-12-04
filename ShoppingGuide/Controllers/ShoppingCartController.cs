using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingGuide.Models;
using ShoppingGuide.ViewModels;

namespace ShoppingGuide.Controllers
{
    public class ShoppingCartController : Controller
    {
        ShoppingGuideDB storeDB = new ShoppingGuideDB();
        //
        // GET: /ShoppingCart/
        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = (cart.GetCartItems()),
                //CartTotal = cart.getTotal()
               CartTotal = (cart.GetTotal())
            };
            // Return the view
            return View(viewModel);
        }
        //
        // GET: /ShoppingCart/AddToCart/5
        public ActionResult AddToCart(int id)
        {
            // Retrieve the product from the database
            var addedProduct = storeDB.Product
                .Single(Product => Product.ProductId == id);

            // Add it to the shopping cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            cart.AddToCart(addedProduct);

            // Go back to the main store page for more shopping
            return View(addedProduct);
        }
        //
        // AJAX: /ShoppingCart/RemoveFromCart/5
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // Remove the item from the cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Get the name of the album to display confirmation
            string ProductName = storeDB.Carts
                .Single(item => item.RecordId == id).AssociatedProduct.Title;

            // Remove from cart
            int itemCount = cart.RemoveFromCart(id);

            // Display the confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(ProductName) +
                    " has been removed from your shopping cart.",
                CartTotal = System.Convert.ToDecimal(cart.GetTotal()),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }
        //
        // GET: /ShoppingCart/CartSummary
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }
    }
}
