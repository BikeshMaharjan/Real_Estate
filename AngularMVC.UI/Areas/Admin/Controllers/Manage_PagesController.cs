using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AngularMVC.DAL;

using System.Net;

namespace VHub.UI.Areas.Admin.Controllers
{
    //[Authorize(Roles = "superuser")]
    public class Manage_PagesController : Controller
    {
        private PradeepKandelEntities db = new AngularMVC.DAL.PradeepKandelEntities();

        //    // GET: Admin/Pages
        //    public ActionResult Index()
        //    {
        //        return View(db.Pages.ToList());
        //    }

        //    // GET: Admin/Pages/Details/5
        //    public ActionResult Details(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        Page page = db.Pages.Find(id);
        //        if (page == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(page);
        //    }

        //    // GET: Admin/Pages/Create
        //    public ActionResult AddNewPage()
        //    {
        //        ViewData["ParentPage"] = new SelectList(db.Pages.AsEnumerable(), "Id", "PageName");
        //        //ViewData["SpecialCode"] = new SelectList(db.Pages.AsEnumerable(), "SpecialCode", "SpecialCode");
        //        return View();
        //    }

        //    // POST: Admin/Pages/Create
        //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    [ValidateInput(false)]
        //    public ActionResult AddNewPage(Page page)
        //    {
        //        string articleThumbnail = "";
        //        foreach (string file in Request.Files)
        //        {
        //            try
        //            {
        //                HttpPostedFileBase posted = (HttpPostedFileBase)Request.Files[file];
        //                var fileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(posted.FileName);
        //                var fullPath = "~/Upload/Page/" + fileName;
        //                var thumbPath = Server.MapPath("~/Upload/Page/thumb/" + fileName);
        //                posted.SaveAs(Server.MapPath(fullPath));
        //                page.FeaturedImage = fileName;

        //                //resizing the image and save to thumbnail folder
        //                using (var image = System.Drawing.Image.FromFile(Server.MapPath(fullPath)))
        //                {
        //                    var resized = Imager.Resize(image, 350, 200, true);
        //                    Imager.SaveJpeg(thumbPath, resized);
        //                }
        //                //store thumbnail path 
        //                articleThumbnail = fileName;
        //            }
        //            catch (Exception ex)
        //            {
        //                TempData["Message"] = "Your Image has problem try another one. Error: " + ex.Message;
        //                TempData["MessageValue"] = "0";
        //                return View(page);
        //            }

        //            page.FeaturedImage = articleThumbnail;
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            page.ParentPageID = Request.Form["ParentPageID"].Trim().ToString();

        //            page.AddedOn = DateTime.Now.AddHours(5).AddMinutes(45);
        //            page.AddedBy = "superuser";
        //            db.Pages.Add(page);
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }

        //        return View(page);
        //    }

        //    // GET: Admin/Pages/Edit/5
        //    public ActionResult Edit(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        Page page = db.Pages.Find(id);
        //        if (page == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(page);
        //    }

        //    // POST: Admin/Pages/Edit/5
        //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    [ValidateInput(false)]
        //    public ActionResult Edit([Bind(Include = "Id,ParentPageID,PageHeadTitle,Keywords,PageDescription,PageName,CultureCode,Short,FullDescription,Highlights,ShowOnMenu,IsActive,AddedOn,AddedBy,AddedIP,ModifiedBy,ModifiedOn,ModifiedIP,DeletedOn,DeletedBy,Remarks")] Page page)
        //    {
        //        string articleThumbnail = "";
        //        foreach (string file in Request.Files)
        //        {
        //            try
        //            {
        //                HttpPostedFileBase posted = (HttpPostedFileBase)Request.Files[file];
        //                var fileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(posted.FileName);
        //                var fullPath = "~/Upload/Page/" + fileName;
        //                var thumbPath = Server.MapPath("~/Upload/Page/thumb/" + fileName);
        //                posted.SaveAs(Server.MapPath(fullPath));
        //                page.FeaturedImage = fileName;

        //                //resizing the image and save to thumbnail folder
        //                using (var image = System.Drawing.Image.FromFile(Server.MapPath(fullPath)))
        //                {
        //                    var resized = Imager.Resize(image, 350, 200, true);
        //                    Imager.SaveJpeg(thumbPath, resized);
        //                }
        //                //store thumbnail path 
        //                articleThumbnail = fileName;
        //            }
        //            catch (Exception ex)
        //            {
        //                page.ModifiedOn = DateTime.Now.AddHours(5).AddMinutes(45);
        //                page.ModifiedBy = "superuser";
        //                TempData["Message"] = "Your Image has problem try another one. Error: " + ex.Message;
        //                TempData["MessageValue"] = "0";
        //                return View(page);
        //            }

        //            page.FeaturedImage = articleThumbnail;
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            db.Entry(page).State = System.Data.Entity.EntityState.Modified;
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //        return View(page);
        //    }

        //    // GET: Admin/Pages/Delete/5
        //    public ActionResult Delete(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        Page page = db.Pages.Find(id);
        //        if (page == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(page);
        //    }

        //    // POST: Admin/Pages/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult DeleteConfirmed(int id)
        //    {
        //        Page page = db.Pages.Find(id);
        //        db.Pages.Remove(page);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    protected override void Dispose(bool disposing)
        //    {
        //        if (disposing)
        //        {
        //            db.Dispose();
        //        }
        //        base.Dispose(disposing);
        //    }
        //}
    }
}