using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AngularMVC.DAL;
using Omu.Drawing;

namespace AngularMVC.UI.Areas.SuperAdmin.Controllers
{
    public class Manage_Product_ItemController : Controller
    {
        private PradeepKandelEntities db = new PradeepKandelEntities();

        // GET: SuperAdmin/Manage_Product_Item
        public ActionResult Index()
        {
            //return Json(db.Blogs.ToList(), JsonRequestBehavior.AllowGet);
            return View(db.Product_Item.ToList());
        }

        public ActionResult ListProduct()
        {
            return Json(db.Product_Item.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddItem()
        {
            ViewData["CategoryName"] = new SelectList(db.Product_Category.AsEnumerable(), "Name", "Name");
            return View();
        }

        // POST: SuperAdmin/Manage_Product_Item/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult AddItem(Product_Item product_Item)
        {
            string articleThumbnail = "";
            foreach (string file in Request.Files)
            {
                try
                {
                    HttpPostedFileBase posted = (HttpPostedFileBase)Request.Files[file];
                    var fileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(posted.FileName);
                    var fullPath = "~/Upload/Product/" + fileName;
                    var thumbPath = Server.MapPath("~/Upload/Product/thumb/" + fileName);
                    posted.SaveAs(Server.MapPath(fullPath));
                    product_Item.Thumbnail = fileName;

                    //resizing the image and save to thumbnail folder
                    using (var image = System.Drawing.Image.FromFile(Server.MapPath(fullPath)))
                    {
                        var resized = Imager.Resize(image, 350, 200, true);
                        Imager.SaveJpeg(thumbPath, resized);
                    }
                    //store thumbnail path 
                    articleThumbnail = fileName;
                }
                catch (Exception ex)
                {
                    TempData["Message"] = "Your Image has problem try another one. Error: " + ex.Message;
                    TempData["MessageValue"] = "0";
                    return View(product_Item);
                }

                product_Item.Thumbnail = articleThumbnail;
            }

            if (ModelState.IsValid)
            {
                
                //product_Item.CategoryName = Request.Form["CategoryName"].Trim().ToString();
                db.Product_Item.Add(product_Item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product_Item);
        }




        // GET: SuperAdmin/Manage_Product_Item/Details/5
        public ActionResult Details(int? id)
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

        // GET: SuperAdmin/Manage_Product_Item/Create
        public ActionResult Create()
        {
            ViewData["CategoryName"] = new SelectList(db.Product_Category.AsEnumerable(), "Name", "Name");
            return View();
        }

        // POST: SuperAdmin/Manage_Product_Item/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product_Item product_Item)
        {
            string articleThumbnail = "";
            foreach (string file in Request.Files)
            {
                try
                {
                    HttpPostedFileBase posted = (HttpPostedFileBase)Request.Files[file];
                    var fileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(posted.FileName);
                    var fullPath = "~/Upload/Product/" + fileName;
                    var thumbPath = Server.MapPath("~/Upload/Product/thumb/" + fileName);
                    posted.SaveAs(Server.MapPath(fullPath));
                    product_Item.Thumbnail = fileName;

                    //resizing the image and save to thumbnail folder
                    using (var image = System.Drawing.Image.FromFile(Server.MapPath(fullPath)))
                    {
                        var resized = Imager.Resize(image, 350, 200, true);
                        Imager.SaveJpeg(thumbPath, resized);
                    }
                    //store thumbnail path 
                    articleThumbnail = fileName;
                }
                catch (Exception ex)
                {
                    TempData["Message"] = "Your Image has problem try another one. Error: " + ex.Message;
                    TempData["MessageValue"] = "0";
                    return View(product_Item);
                }

                product_Item.Thumbnail = articleThumbnail;
            }

            if (ModelState.IsValid)
            {
                product_Item.CategoryName = Request.Form["CategoryName"].Trim().ToString();
                db.Product_Item.Add(product_Item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product_Item);
        }

        // GET: SuperAdmin/Manage_Product_Item/Edit/5
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

        // POST: SuperAdmin/Manage_Product_Item/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemID,HidePrice,HideToAnonymous,ActiveFrom,ActiveTo,SKU,Thumbnail,Highlight,CategoryName,CategoryID,Description,Weight,NewFromDate,NewToDate,Price,ListPrice,Visibility,Quantity,IsFeatured,FeaturedFromDate,FeaturedToDate,IsSpecial,SpecialFromDate,SpecialToDate,ViewCount,Length,Height,Width,HasCostVariants,IsActive,IsDeleted,IsModified,AddedOn,UpdatedOn,DeletedOn,AddedBy,UpdatedBy,DeletedBy,RatedValue,LowStockQuantity,OutOfStockQuantity,MinCartQuantity,MaxCartQuantity,CostPrice,SpecialPrice,SpecialPriceFromDate,SpecialPriceToDate,ManufacturerPrice,IsNotifiacationViewed,TotalDiscount")] Product_Item product_Item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product_Item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product_Item);
        }

        // GET: SuperAdmin/Manage_Product_Item/Delete/5
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

        // POST: SuperAdmin/Manage_Product_Item/Delete/5
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
