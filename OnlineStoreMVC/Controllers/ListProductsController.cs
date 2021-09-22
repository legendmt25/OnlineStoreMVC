using OnlineStoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStoreMVC.Controllers
{
    public class ListProductsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            ListProductsWithFilterModel model = new ListProductsWithFilterModel();
            model.products = db.Products.ToList();
            model.filterByPrice = new FilterPrice();
            ViewBag.maxPrice = (int)db.Products.Max(product => product.Price * (1 - (double)product.Discount / 100)) + 1;
            model.filterByPrice.max = (int)ViewBag.maxPrice;
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(ListProductsWithFilterModel model)
        {
            ViewBag.maxPrice = (int)db.Products.Max(product => product.Price * (1 - (double)product.Discount / 100)) + 1;
            if (model.filterByPrice.max == null)
            {
                model.filterByPrice.max = (int)ViewBag.maxPrice;
            }
            model.products = model.filterByPrice.filter(db.Products);
            if(model.submit != null)
            {
                if (model.submit.Equals("Date"))
                    model.products = Order.orderByDate(model.products);
                if (model.submit.Equals("Orders"))
                    model.products = Order.orderByOrders(model.products);
                if (model.submit.Equals("Price"))
                {
                    if(Session["ascending"] == null) 
                        Session["ascending"] = true;
                    bool ascending = (bool)Session["ascending"];
                    model.products = Order.orderByPrice(model.products, ascending);
                    ascending = !ascending;
                    Session["ascending"] = ascending;
                    ViewBag.Ascending = ascending;
                }
                else
                {
                    Session["ascending"] = null;
                    ViewBag.Ascending = null;
                }

            }
            return View(model);
        }

    }
}