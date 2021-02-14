using SBS.BAL.Interface;
using SBS.MDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBS.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationManager _authenticationManager;

        public AuthenticationController(IAuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;
        }
        // GET: Authentication
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel Login)
        {
            var result = _authenticationManager.Login(Login);
            if (result.attempt)
            {
                Session["loginId"] = result.loginuserid;
                return RedirectToAction("Index","Customer");
            }
            else
            {
                return Content("Failed");
            }
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel register)
        {
            var result = _authenticationManager.Register(register,null);
            if (result)
            {
                return Content("registerd");
            }
            else
            {
                return Content("Failed");
            }
        }
        [HttpGet]
        public ActionResult LogOFF()
        {
            Session.Clear();
            return View("Login");
        }
    }
}
