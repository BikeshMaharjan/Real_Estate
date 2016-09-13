using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AngularMVC.DAL;

namespace AngularMVC.UI.Areas.SuperAdmin.Controllers
{
    public class Manage_Product_CategoryController : Controller
    {
        private PradeepKandelEntities db = new PradeepKandelEntities();

        // GET: SuperAdmin/Manage_Product_Category
        public ActionResult Index()
        {
            return View(db.Product_Category.ToList());
        }

        // GET: SuperAdmin/Manage_Product_Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Category product_Category = db.Product_Category.Find(id);
            if (product_Category == null)
            {
                return HttpNotFound();
            }
            return View(product_Category);
        }

        // GET: SuperAdmin/Manage_Product_Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuperAdmin/Manage_Product_Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryID,Name,Description,ParentID,CategoryLevel,IsShowInSearch,IsShowInCatalog,IsShowInMenu,ActiveFrom,ActiveTo,DisplayOrder,Thumbnail,IsService,IsActive,IsDeleted,IsModified,AddedOn,UpdatedOn,DeletedOn,AddedBy,UpdatedBy,DeletedBy")] Product_Category product_Category)
        {
            if (ModelState.IsValid)
            {
                db.Product_Category.Add(product_Category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product_Category);
        }

        // GET: SuperAdmin/Manage_Product_Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Category product_Category = db.Product_Category.Find(id);
            if (product_Category == null)
            {
                return HttpNotFound();
            }
            return View(product_Category);
        }

        // POST: SuperAdmin/Manage_Product_Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryID,Name,Description,ParentID,CategoryLevel,IsShowInSearch,IsShowInCatalog,IsShowInMenu,ActiveFrom,ActiveTo,DisplayOrder,Thumbnail,IsService,IsActive,IsDeleted,IsModified,AddedOn,UpdatedOn,DeletedOn,AddedBy,UpdatedBy,DeletedBy")] Product_Category product_Category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product_Category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product_Category);
        }

        // GET: SuperAdmin/Manage_Product_Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Category product_Category = db.Product_Category.Find(id);
            if (product_Category == null)
            {
                return HttpNotFound();
            }
            return View(product_Category);
        }

        // POST: SuperAdmin/Manage_Product_Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product_Category product_Category = db.Product_Category.Find(id);
            db.Product_Category.Remove(product_Category);
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
