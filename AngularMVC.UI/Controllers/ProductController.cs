using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;

using System.Web.Mvc;
using AngularMVC.DAL;

namespace AngularMVC.UI.Controllers
{
    public class ProductController : Controller
    {
        private PradeepKandelEntities db = new PradeepKandelEntities();

        // GET: Product
        public ActionResult Index()
        {
            ViewBag.TodayDate = System.DateTime.Now.Year;
            return View(db.Product_Item.ToList());

        }

        public ActionResult AllBlogs()
        {
            return View();
        }

        /// <summary>
        /// THis function return the list of Products of Category passed
        /// </summary>
        /// <param name="CategoryName">Be be of String Type and should be of lenght 100 Letters</param>
        /// <param name="Count"></param>
        /// <returns></returns>
        public ActionResult ProductsByCategory(string CategoryName, int Count)
        {
            return View();
        }


        // GET: Product/Details/5
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Item product_Item = db.Product_Item.Find(id);
            var CategoryName = product_Item.CategoryName;
            ViewBag.RecommendedItems = db.Product_Item.Where(x => x.CategoryName == CategoryName).ToList();
            if (product_Item == null)
            {
                return HttpNotFound();
            }
            return View(product_Item);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemID,Name,SKU,Thumbnail,ShortDescription,Highlight,CategoryName,Description,Weight,HidePrice,Price,ListPrice,CostPrice,ManufacturerPrice,Visibility,ActiveFrom,HideToAnonymous,IsFeatured,IsSpecial,SpecialPrice,ViewCount,Quantity,Length,Height,Width,IsActive,IsDeleted,IsModified,AddedOn,UpdatedOn,DeletedOn,AddedBy,UpdatedBy,DeletedBy,RatedValue,IsNotifiacationViewed,TotalDiscount")] Product_Item product_Item)
        {
            if (ModelState.IsValid)
            {
                db.Product_Item.Add(product_Item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product_Item);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Item product_Item = db.Product_Item.Find(id);
            if (product_Item == null)
            {
                return HttpNotFound();
            }
            return View(product_Item);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemID,Name,SKU,Thumbnail,ShortDescription,Highlight,CategoryName,Description,Weight,HidePrice,Price,ListPrice,CostPrice,ManufacturerPrice,Visibility,ActiveFrom,HideToAnonymous,IsFeatured,IsSpecial,SpecialPrice,ViewCount,Quantity,Length,Height,Width,IsActive,IsDeleted,IsModified,AddedOn,UpdatedOn,DeletedOn,AddedBy,UpdatedBy,DeletedBy,RatedValue,IsNotifiacationViewed,TotalDiscount")] Product_Item product_Item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product_Item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product_Item);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Item product_Item = db.Product_Item.Find(id);
            if (product_Item == null)
            {
                return HttpNotFound();
            }
            return View(product_Item);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product_Item product_Item = db.Product_Item.Find(id);
            db.Product_Item.Remove(product_Item);
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
