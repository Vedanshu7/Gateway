using SourceControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SourceControl.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Login Ln)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Contact");
            }
            return View(Ln);
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Register std)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Contact");
            }
            return View(std);
        }


      
        public ActionResult Contact()
        {
            ViewBag.Message = "Date Are Validated on Sever side and Clien Side Both";

            return Content(ViewBag.Message);
        }
    }
}