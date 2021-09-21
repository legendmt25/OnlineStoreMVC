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
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(ListProductsWithFilterModel model)
        {
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