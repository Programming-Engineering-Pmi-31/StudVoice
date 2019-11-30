using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudVoice.BLL;
using StudVoice.BLL.DTOs;
using StudVoice.DAL;
using StudVoice.DAL.UnitOfWork;
using System.Web;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace StudVoiceMVC.Controllers
{
    public class AccountController : Controller
    {
        UnitOfWork unitOfWork;
        public AccountController()
        {
            unitOfWork = new UnitOfWork();
        }
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginDTO loginDTO)
        {
            if(ModelState.IsValid)
            {
                User user = null;
                using (StudVoiceContext db = new StudVoiceContext())
                {
                    var us = db.Users.FirstOrDefault(u => u.Name == loginDTO.Login && u.Surname == loginDTO.Password);
                    if(us!=null)
                    {
                        user = new User(us.Name, us.Surname, us.MiddleName, Convert.ToInt32(us.ContactId), Convert.ToInt32(us.FacultyId));
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Invalid email or password.");
                    }
                }
                if (user != null)
                {
                    var claims = new[] { new Claim(ClaimTypes.Name, user.Name) };

                    var identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);

                    HttpContext.Authentication.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(identity));
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Password", "Invalid email or password.");
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogOff()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult RegisterTeacher()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult RegisterTeacher(RegisterTeacherDTO registerTeacher)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [AllowAnonymous]
        public ActionResult RegisterStudent()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult RegisterStudent(RegisterStudentDTO registerStudent)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}