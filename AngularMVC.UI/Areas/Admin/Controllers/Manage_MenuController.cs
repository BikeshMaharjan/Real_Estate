using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AngularMVC.DAL;

namespace VHub.UI.Areas.Admin.Controllers
{
    public class Manage_MenuController : Controller
    {
        //    private PradeepKandelEntities db = new PradeepKandelEntities();

        //    // GET: Admin/Manage_Menu
        //    public ActionResult Index()
        //    {
        //        return View(db.MenuItems.ToList());
        //    }

        //    // GET: Admin/Manage_Menu/Details/5
        //    public ActionResult Details(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        MenuItem menuItem = db.MenuItems.Find(id);
        //        if (menuItem == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(menuItem);
        //    }

        //    // GET: Admin/Manage_Menu/Create
        //    public ActionResult AddMenuItem()
        //    {
        //        ViewData["MenuID"] = new SelectList(db.Menus.Where(x => x.IsActive == true).AsEnumerable(), "MenuID", "MenuName");
        //        ViewData["PageID"] = new SelectList(db.Pages.Where(x => x.IsActive == true).AsEnumerable(), "Id", "PageName");
        //        ViewData["ParentID"] = new SelectList(db.MenuItems.Where(x => x.IsActive == true).AsEnumerable(), "MenuItemID", "Title");

        //        return View();
        //    }

        //    // POST: Admin/Manage_Menu/Create
        //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateInput(false)]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult AddMenuItem(MenuItem menuItem)
        //    {

        //        if (ModelState.IsValid)
        //        {
        //            var ParentMenu = Request.Form["ParentID"].Trim().ToString();
        //            var PageID = Request.Form["PageID"].Trim().ToString();
        //            var MenuTypeID = Request.Form["MenuID"].Trim().ToString();

        //            menuItem.ParentID = Convert.ToInt32(ParentMenu);
        //            menuItem.PageID = PageID;
        //            menuItem.MenuID = Convert.ToInt32(MenuTypeID);
        //            menuItem.AddedBy = User.Identity.Name;
        //            menuItem.AddedOn = DateTime.UtcNow.AddHours(5).AddMinutes(45);

        //            db.MenuItems.Add(menuItem);
        //            db.SaveChanges();
        //            return RedirectToAction("Index", "Manage_Menu", new { area = "Admin"});
        //        }

        //        return View(menuItem);
        //    }

        //    // GET: Admin/Manage_Menu/Edit/5
        //    public ActionResult EditMenuItem(int? id)
        //    {
        //        ViewData["MenuID"] = new SelectList(db.Menus.Where(x => x.IsActive == true).AsEnumerable(), "MenuID", "MenuName");
        //        ViewData["PageID"] = new SelectList(db.Pages.Where(x => x.IsActive == true).AsEnumerable(), "Id", "PageName");
        //        ViewData["ParentID"] = new SelectList(db.MenuItems.Where(x => x.IsActive == true).AsEnumerable(), "MenuItemID", "Title");

        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        MenuItem menuItem = db.MenuItems.Find(id);
        //        if (menuItem == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(menuItem);
        //    }

        //    // POST: Admin/Manage_Menu/Edit/5
        //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult EditMenuItem(MenuItem menuItem)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.Entry(menuItem).State = EntityState.Modified;
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //        return View(menuItem);
        //    }

        //    // GET: Admin/Manage_Menu/Delete/5
        //    public ActionResult DeleteMenuItem(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        MenuItem menuItem = db.MenuItems.Find(id);
        //        if (menuItem == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(menuItem);
        //    }

        //    // POST: Admin/Manage_Menu/Delete/5
        //    [HttpPost, ActionName("DeleteMenuItem")]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult DeleteConfirmed(int id)
        //    {
        //        MenuItem menuItem = db.MenuItems.Find(id);
        //        db.MenuItems.Remove(menuItem);
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
