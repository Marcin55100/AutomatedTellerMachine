using AutomatedTellerMachine.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutomatedTellerMachine.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

       // [OutputCache(Duration =20)]
       [Authorize]
        public ActionResult Index()
        {
            string role;
            var userId = User.Identity.GetUserId();
            var checkingAccountId = db.CheckingAccounts.Where(c => c.ApplicationUserId == userId).First().Id;
            ViewBag.CheckingAccountId = checkingAccountId;


            var manager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(userId);
            if(user.Roles.Count>0)
            {
                ViewBag.Admin = true;
            }



            return View();
            //return PartialView(); bez layoutu
        }
        //[ActionName("about-this-atm")]
        public ActionResult About()
        {
            ViewBag.Message = "Having trouble send us a message";

            return View("About");
        }

        public ActionResult Contact()
        {
            ViewBag.TheMessage = "Your contact page.";
            
            return View();
        }

        [HttpPost]
        public ActionResult Contact(string message)
        {
            ViewBag.TheMessage = "Thanks, we got your message";

            return PartialView("_ContactThanks");
        }



        public ActionResult Foo()
        {
            return View("About");
        }
        public ActionResult Serial(string letterCase)
        {
            var serial = "ASPNETMVC5ATM1";
            if (letterCase == "lower")
                return Content(serial.ToLower());
            else
                //  return Json(new { name = "serial", value = serial }, JsonRequestBehavior.AllowGet);
                return RedirectToAction("Index");

        }



    }
}