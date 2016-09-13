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
    public class Manage_PropertyController : Controller
    {
        private PradeepKandelEntities db = new PradeepKandelEntities();

        // GET: SuperAdmin/Manage_Property
        public ActionResult Index()
        {
            return View(db.Property_Detail.ToList());
        }

        public ActionResult ListProperty()
        {
            return Json(db.Property_Detail.ToList(), JsonRequestBehavior.AllowGet);
        }


        // GET: SuperAdmin/Manage_Property/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property_Detail property_Detail = db.Property_Detail.Find(id);
            if (property_Detail == null)
            {
                return HttpNotFound();
            }
            return View(property_Detail);
        }

        // GET: SuperAdmin/Manage_Property/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuperAdmin/Manage_Property/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Property_Detail property_Detail)
        {
            string articleThumbnail = "";
            foreach (string file in Request.Files)
            {
                try
                {
                    HttpPostedFileBase posted = (HttpPostedFileBase)Request.Files[file];
                    var fileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(posted.FileName);
                    var fullPath = "~/Upload/Property/" + fileName;
                    var thumbPath = Server.MapPath("~/Upload/Property/thumb/" + fileName);
                    posted.SaveAs(Server.MapPath(fullPath));


                    //property_Detail.img1 = fileName;

                    //resizing the image and save to thumbnail folder
                    using (var image = System.Drawing.Image.FromFile(Server.MapPath(fullPath)))
                    {
                        var resized = Imager.Resize(image, 850, 850, true);
                        Imager.SaveJpeg(thumbPath, resized);
                    }
                    //store thumbnail path 
                    articleThumbnail = fileName;
                } 
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = "Error" + ex.Message;
                    TempData["Message"] = "Your Image has problem try another one. Error: " + ex.Message;
                    TempData["MessageValue"] = "0";
                    return View(property_Detail);
                }

                property_Detail.img1 = articleThumbnail;
            }


            if (ModelState.IsValid)
            {
               
                property_Detail.PropertyId = Guid.NewGuid().ToString();
                property_Detail.UserId = User.Identity.Name;
              
                property_Detail.SubmittedDate = DateTime.Now;
                db.Property_Detail.Add(property_Detail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(property_Detail);
        }

        // GET: SuperAdmin/Manage_Property/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property_Detail property_Detail = db.Property_Detail.Find(id);
            if (property_Detail == null)
            {
                return HttpNotFound();
            }
            return View(property_Detail);
        }

        // POST: SuperAdmin/Manage_Property/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PropertyId,Title,TypeId,LocationId,UserId,Price,SubmittedDate,PublishedDate,ExpiredDate,img1,img2,img3,img4,img5,img6,LalPurja_ScanCopy,Status,IsVerified,AllowAuction,IsApplyLocked,Category,Length,Breath,Area,Description,NO_Of_Floor,NO_Of_Room,NO_Of_BedRoom,NO_Of_Kitchen,NO_Of_BathRoom,HouseColor,NO_Of_Hall,NO_Of_GuestRoom,NO_Of_Car_For_Parking,NO_Of_Bike_For_Parking,Compound,Under_Ground_Water_Tank,FloorType,HouseType,Country,State,Zone,District,City,Street,HouseNo")] Property_Detail property_Detail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(property_Detail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(property_Detail);
        }

        // GET: SuperAdmin/Manage_Property/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property_Detail property_Detail = db.Property_Detail.Find(id);
            if (property_Detail == null)
            {
                return HttpNotFound();
            }
            return View(property_Detail);
        }

        // POST: SuperAdmin/Manage_Property/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Property_Detail property_Detail = db.Property_Detail.Find(id);
            db.Property_Detail.Remove(property_Detail);
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
