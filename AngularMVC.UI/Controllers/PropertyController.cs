using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AngularMVC.DAL;
using Microsoft.AspNet.Identity;
using Omu.Drawing;
using System.Net.Mail;
using System.Net;

namespace AngularMVC.UI.Controllers
{
    public class PropertyController : Controller
    {
        PradeepKandelEntities db = new PradeepKandelEntities();
        String expired_date="";

        // GET: Property
        public ActionResult Index()
        {
            return View();
        }

        protected string ExpiredDate {
            get
            {
                return expired_date;
            }
        }

        public ActionResult Detail(string id)
        {
            var Category = db.Property_Detail.Find(id).Category.Trim().ToString();
            ViewBag.Recommended = db.Property_Detail.Where(x => x.Category == Category).Take(6).ToList();
            expired_date = db.Property_Detail.Find(id).ExpiredDate.ToString();
            return View(db.Property_Detail.Find(id));
        }

        public ActionResult SeeBidders(string PropertyId)
        {
            var Category = db.Property_Detail.Find(PropertyId).Category.Trim().ToString();
            ViewBag.Bidders = db.Bid_Property_User.Where(x => x.PropertyId == PropertyId).ToList();
            return View(db.Property_Detail.Find(PropertyId));
        }


        public ActionResult SellNow(string Id)
        {
            Bid_Property_User property = db.Bid_Property_User.Find(Id);
            var PropertyId = db.Bid_Property_User.Find(Id).PropertyId;

            Property_Detail property_Detail = db.Property_Detail.Find(PropertyId);

            property.IsSold = true;
            db.Entry(property).State = System.Data.Entity.EntityState.Modified;

            property_Detail.IsApplyLocked = true;

            db.Entry(property_Detail).State = System.Data.Entity.EntityState.Modified;

            db.SaveChanges();

            MailMessage objMail = new MailMessage("bks_maharjan7@hotmail.com", "Aakeshkunwar1@gmail.com", "Online Real Estate", "You won Bidding.");
            NetworkCredential objNC = new NetworkCredential("bks_maharjan7@hotmail.com", "");
            SmtpClient objsmtp = new SmtpClient("smtp.live.com", 587); // for hotmail
            objsmtp.EnableSsl = true;
            objsmtp.Credentials = objNC;
            objsmtp.Send(objMail);

            // return RedirectToAction("SellNow", "Property", Id = PropertyId);
            return RedirectToAction("SeeBidders", "Property", Id = PropertyId);
        }

        [Authorize]
        public ActionResult BIDNOW(string PropertyId, int Price, String Message)
        {
            var UserId = User.Identity.GetUserId();
            var Username = User.Identity.Name;
            //IdeasVoting ideasVoting = new IdeasVoting();
            Bid_Property_User checkBidder;
            try
            {
                //checkVoter = db.IdeasVotings.Single(x => x.UserId == UserId && x.IdeasDetailId == IdeasDetailId);
                checkBidder = db.Bid_Property_User.Single(x => x.UserName == Username && x.PropertyId == PropertyId);
            }
            catch
            {
                checkBidder = null;
            }
            
            if (ModelState.IsValid)
            {
                if (checkBidder == null)
                {
                    Bid_Property_User bidding = new Bid_Property_User();
                    bidding.Id = Guid.NewGuid().ToString();

                    bidding.PropertyId = PropertyId;

                    bidding.UserId = UserId;


                    var User = db.AspNetUsers.Find(UserId);

                    bidding.FName = User.FirstName;
                    bidding.MName = User.MiddleName;
                    bidding.LName = User.LastName;
                    bidding.PhoneNo = User.PhoneNumber;
                    bidding.Email = User.Email;
                    bidding.Address = User.Address;
 
                    bidding.Price = Price;
                    bidding.Message = Message;

                    bidding.PostedOn = DateTime.Now;
                    bidding.PostedBy = Username;
                    bidding.UserName = Username;



                    db.Entry(bidding).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();

                    TempData["Message"] = "You have successfully bid on" + bidding.Title;
                    TempData["MessageValue"] = 1;
                }
                else
                {
                    TempData["Message"] = "You have already bid on this Property" ;
                    TempData["MessageValue"] = 0;
                }
            }
            
            return RedirectToAction("Detail", "Property", new { id = PropertyId });


        }


        //GET Property/SearchProperty 
        public ActionResult SearchProperty(string CategoryName)
        {            
            return View(db.Property_Detail.Where(x => x.Category == CategoryName).ToList());
        }



        // GET: SuperAdmin/Manage_Property/Create
        [Authorize]
        public ActionResult AddNewProperty()
        {
            var userid = User.Identity.GetUserId();
            ViewBag.NoOfProperty = db.Property_Detail.Where(x => x.UserId == userid).Count();
            return View();
        }

        // POST: SuperAdmin/Manage_Property/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult AddNewProperty(Property_Detail property_Detail)
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
                property_Detail.UserId = User.Identity.GetUserId();
                property_Detail.SubmittedDate = DateTime.Now;
                db.Property_Detail.Add(property_Detail);
                db.SaveChanges();
                return RedirectToAction("MyProperty", "UserProfile", new { area = "" });
            }
            return View(property_Detail);
        }
    }
}