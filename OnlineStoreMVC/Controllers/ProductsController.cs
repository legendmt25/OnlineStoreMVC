using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OnlineStoreMVC.Models;

namespace OnlineStoreMVC.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Products
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            return View(db.Products.Where(s => s.ownerId == currentUserId).ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ProductImageViewModel product = new ProductImageViewModel();
            return View(product);
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductImageViewModel product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string currentUserId = User.Identity.GetUserId().ToString();
                    Product newProduct = new Product(User.Identity.GetUserId().ToString(), product.Price, product.Discount, product.Title);
                    db.Products.Add(newProduct);
                    db.SaveChanges();
                    string[] imgSources = product.ImgSources.Split('\n');
                    foreach (var imgSrc in imgSources)
                        if(!imgSrc.Equals(""))
                            db.Images.Add(new ImageModel { ImageSrc = imgSrc, Product = newProduct });
                    db.SaveChanges();
                }
                catch(System.Data.Entity.Validation.DbEntityValidationException e)
                {
                    string s = "";
                    foreach(var exe in e.EntityValidationErrors)
                    {
                        foreach(var ex in exe.ValidationErrors)
                        {
                            s += ex.PropertyName + " " + ex.ErrorMessage;
                        }
                    }
                        return Content(s);
                }
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ownerId,AddedOn,Price,Discount,OrdersNumber,Title")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
