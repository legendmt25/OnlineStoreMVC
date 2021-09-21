using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineStoreMVC.Models;

namespace OnlineStoreMVC.Controllers
{
    public class CartController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Cart
        public ActionResult Index()
        {
            if (Session["cart"] == null)
            {
                Session["cart"] = new List<Product>();
            }
            List<Product> cartProducts = (List<Product>)Session["cart"];
            return View(cartProducts);
        }
        public ActionResult AddToCart(int id)
        {
            if (Session["cart"] == null)
            {
                Session["cart"] = new List<Product>();
            }
            List<Product> cartProducts = (List<Product>)Session["cart"];
            cartProducts.Add((from product in db.Products
                             where product.Id == id
                             select product).Single());
            Session["cart"] = cartProducts;
            return RedirectToAction("Index", "ListProducts");
        }

        public ActionResult RemoveFromCart(int id)
        {
            List<Product> cartProducts = (List<Product>)Session["cart"];
            if (cartProducts.Count > 0)
            {
                cartProducts.RemoveAt(id);
                Session["cart"] = cartProducts;
            }
            return View("Index", cartProducts);
        }
        public ActionResult ClearCart()
        {
            Session.Clear();
            return View("Index");
        }
    }
}