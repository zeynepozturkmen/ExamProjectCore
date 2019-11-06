using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Web.Providers.Entities;
using ExamProjectCore.Business.Abstract;
using ExamProjectCore.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamCoreProject.UI.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
     

        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User uc)
        {
            var login = _userService.GetAll().Where(x => x.UserName == uc.UserName && x.Password == uc.Password).FirstOrDefault();
            if (login != null)
            {           
                return RedirectToAction("CreateExam", "Exam");
            }
            else
            {
                ViewBag.Message = "Username or password is wrong.Please try again.";
                return View();
            }
        }

        //----------------------------------Admin Kayıt -------------------------------------------------
        [HttpPost]
        public IActionResult Register(User uc)
        {
            if (uc != null)
            {
                _userService.Create(uc);
                //TempData["message"] = "Success";
                ViewBag.Message = "Success";
                return View("Login");
            }
            else
            {
                ViewBag.Message = "Error";
                return View("Login");
            }

        }

        //---------------------------------Çıkış Butonu --------------------------------------------------
        public IActionResult Logout()
        {
            //HttpContext.Session.Clear();
           //Session.Clear();
            return RedirectToAction("Login", "Account");
        }
    }
}