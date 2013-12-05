using System;
using System.Linq;
using System.Web.Mvc;
using ShoppingGuide.Models;

namespace MvcMusicStore.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        ShoppingGuideDB storeDB = new ShoppingGuideDB();
        const string PromoCode = "SJSUFREE";
        //
        // GET: /Checkout/AddressAndPayment
        public ActionResult AddressAndPayment()
        {
            return View();
        }
        //
        // POST: /Checkout/AddressAndPayment
        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection values, String EnteredPromoCode)
        {
            var order = new Order();
            TryUpdateModel(order);

            try
            {
                if (PromoCode.Equals(EnteredPromoCode))
                {
                    return RedirectToAction("Complete");
                }
                else
                {
                    ViewBag.Error = "Invalid promo code!";
                    return View(order);
                }
            }
            catch
            {
                //Invalid - redisplay with errors
                return View(order);
            }
        }
        //
        // GET: /Checkout/Complete
        public ActionResult Complete()
        {
            // Clear the cart
            var cart = ShoppingCart.GetCart(this.HttpContext);
            cart.EmptyCart();

            return View();
        }
    }
}