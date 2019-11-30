﻿using System;
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
using System.Security.Cryptography;
using System.Text;

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
                    var md5 = new MD5CryptoServiceProvider();
                    var data = Encoding.ASCII.GetBytes(loginDTO.Password);
                    var md5data = md5.ComputeHash(data);
                    var hashedPassword = Encoding.ASCII.GetString(md5data);
                    var us = db.Users.FirstOrDefault(u => u.Contact.Email == loginDTO.Login && u.Password == hashedPassword);
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
                User user = null;
                using (StudVoiceContext db = new StudVoiceContext())
                {
                    var us = db.Users.FirstOrDefault(u => u.Contact.Email == registerTeacher.Email);
                    var id = db.Faculties.Where(x => x.Name == registerTeacher.Faculty).Select(x => x.Id).FirstOrDefault();
                    if (us!=null)
                    {
                        ModelState.AddModelError("Email", "This email is bound with another user.");
                        return View(registerTeacher);
                    }
                    if(db.Users.FirstOrDefault(u => u.Contact.Phone == registerTeacher.ContactPhone)!=null)
                    {
                        ModelState.AddModelError("ContactPhone", "This phone number is bound with another user.");
                        return View(registerTeacher);
                    }
                    else
                    {
                        var user_db = new Users();
                        user_db.Id = Guid.NewGuid().ToString();
                        user_db.Name = registerTeacher.Name;
                        user_db.Surname = registerTeacher.Surname;
                        user_db.FacultyId = id;
                        user_db.MiddleName = registerTeacher.Patronym;

                        var contact = new Contacts();
                        contact.Id = db.Contacts.Last().Id + 1;
                        contact.Email = registerTeacher.Email;
                        contact.Phone = registerTeacher.ContactPhone;
                        db.Contacts.Add(contact);                        

                        user_db.ContactId = contact.Id;

                        var teacher = new Teachers();
                        teacher.Id = db.Contacts.Last().Id + 1;
                        teacher.Name = registerTeacher.Name;
                        db.Teachers.Add(teacher);

                        var md5 = new MD5CryptoServiceProvider();
                        var data = Encoding.ASCII.GetBytes(registerTeacher.Password);
                        var md5data = md5.ComputeHash(data);
                        var hashedPassword = Encoding.ASCII.GetString(md5data);

                        user_db.Password = hashedPassword;

                        db.Users.Add(user_db);
                        db.SaveChanges();
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            return View(registerTeacher);
        }

        [AllowAnonymous]
        public ActionResult RegisterStudent()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult RegisterStudent(RegisterStudentDTO registerStudent)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                using (StudVoiceContext db = new StudVoiceContext())
                {
                    var us = db.Users.FirstOrDefault(u => u.Contact.Email == registerStudent.Email);
                    var id = db.Faculties.Where(x => x.Name == registerStudent.Faculty).Select(x => x.Id).FirstOrDefault();
                    if (us != null)
                    {
                        ModelState.AddModelError("Email", "This email is bound with another user.");
                        return View(registerStudent);
                    }
                    if (db.Users.FirstOrDefault(u => u.Contact.Phone == registerStudent.ContactPhone) != null)
                    {
                        ModelState.AddModelError("ContactPhone", "This phone number is bound with another user.");
                        return View(registerStudent);
                    }
                    else
                    {
                        var user_db = new Users();
                        user_db.Id = Guid.NewGuid().ToString();
                        user_db.Name = registerStudent.Name;
                        user_db.Surname = registerStudent.Surname;
                        user_db.FacultyId = id;
                        user_db.MiddleName = registerStudent.Patronym;

                        var contact = new Contacts();
                        contact.Id = db.Contacts.Last().Id + 1;
                        contact.Email = registerStudent.Email;
                        contact.Phone = registerStudent.ContactPhone;
                        db.Contacts.Add(contact);

                        user_db.ContactId = contact.Id;

                        var md5 = new MD5CryptoServiceProvider();
                        var data = Encoding.ASCII.GetBytes(registerStudent.Password);
                        var md5data = md5.ComputeHash(data);
                        var hashedPassword = Encoding.ASCII.GetString(md5data);

                        user_db.Password = hashedPassword;

                        db.Users.Add(user_db);
                        db.SaveChanges();
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                                       .Where(y => y.Count > 0)
                                       .ToList();
            }
            return View(registerStudent);
        }
    }
}