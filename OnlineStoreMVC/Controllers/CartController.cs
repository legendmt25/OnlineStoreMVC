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
                Session["cart"] = new List<ProductCartModel>();
            }
            List<ProductCartModel> cartProducts = (List<ProductCartModel>)Session["cart"];
            return View(cartProducts);
        }

        public ActionResult AddToCart(int id)
        {
            if (Session["cart"] == null)
                Session["cart"] = new List<ProductCartModel>();
            Product productToAdd = db.Products.Where(product => product.Id == id).Single();
            List<ProductCartModel> cartProducts = (List<ProductCartModel>)Session["cart"];
            if (!cartProducts.Where(product => productToAdd.Id == product.Product.Id).Any())
                cartProducts.Add(new ProductCartModel { Product = productToAdd, Quantity = 0 });
            Session["cart"] = cartProducts;
            return Content("");
            //return RedirectToAction("Index", "ListProducts");
        }

        public ActionResult UpdateQuantity(int id, int quantity)
        {
            List<ProductCartModel> cartProducts = (List<ProductCartModel>)Session["cart"];
            cartProducts.ElementAt(id).Quantity = quantity;
            return Content("");
        }

        public ActionResult RemoveFromCart(int id)
        {
            List<ProductCartModel> cartProducts = (List<ProductCartModel>)Session["cart"];
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