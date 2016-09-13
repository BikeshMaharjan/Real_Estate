using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AngularMVC.DAL;
using Microsoft.AspNet.Identity;
using Omu.Drawing;

namespace AngularMVC.UI.Controllers
{
    public class UserProfileController : Controller
    {
        PradeepKandelEntities db = new PradeepKandelEntities();
        // GET: UserProfile
        public ActionResult Index()
        {
            return View();
        }


       

        [Authorize]
        public ActionResult MyProperty()
        {
            var userid = User.Identity.GetUserId();
            var Property = db.Property_Detail.Where(x => x.UserId == userid).ToList();
            if(Property == null)
            {
                TempData["Message"] = "You have not submitted any property yet.  ";
                TempData["MessageValue"] = "0";
                return View();
            }

            ViewBag.NoOfProperty = db.Property_Detail.Where(x => x.UserId == userid).Count();
            //var UserId = User.Identity.GetUserId();
            return View(Property);
            //return View();
        }
    }
}