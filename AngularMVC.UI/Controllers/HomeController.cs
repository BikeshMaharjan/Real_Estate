using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using AngularMVC.DAL;

namespace AngularMVC.UI.Controllers
{
 
    public class HomeController : Controller
    {
        PradeepKandelEntities db = new PradeepKandelEntities();
        public ActionResult Index()
        {
            ViewBag.ListSoldProperty = db.Property_Detail.Where(x => x.IsApplyLocked == true).Take(12).ToList();
            return View();
        }

        [ChildActionOnly]
        public ActionResult PartialSoldProducts()
        {
            return View(db.Property_Detail.Where(x => x.IsApplyLocked == true).Take(12).ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}