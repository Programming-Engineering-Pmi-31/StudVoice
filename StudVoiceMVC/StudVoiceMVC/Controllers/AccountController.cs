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
using System.Security.Cryptography;
using System.Text;
using System.Net.Mail;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace StudVoiceMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private StudVoiceDBContext db;
        public AccountController(StudVoiceDBContext context, SignInManager<User> singInManager)
        {
            db = context;
            _signInManager = singInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View("Login1");
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDTO model)
        {

            if (ModelState.IsValid)
            {
                var md5 = new MD5CryptoServiceProvider();
                var data = Encoding.ASCII.GetBytes(model.Password);
                var md5data = md5.ComputeHash(data);
                var hashedPassword = string.Join("", MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(model.Password)).Select(s => s.ToString("x2")));
                User user = db.Users.Select(t => t).Where(u => u.Email == model.Login && u.PasswordHash == hashedPassword).FirstOrDefault();
                if (user != null)
                {
                    if (!user.EmailConfirmed)
                    {
                        ModelState.AddModelError("", "You haven`t confirmed email. Please, follow the link that that you received on email box from StudVoice");
                    }
                    Teacher t = db.Teachers.FirstOrDefault(x => x.UserId == user.Id);
                    if (t != null)
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimsIdentity.DefaultNameClaimType, t.Name),
                            new Claim(ClaimsIdentity.DefaultRoleClaimType,"Teacher")
                        };
                        ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, "Teacher");
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimsIdentity.DefaultNameClaimType, user.Name),
                            new Claim(ClaimsIdentity.DefaultRoleClaimType,"Student")
                        };
                        ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, "Student");
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
                        
                        return RedirectToAction("Index", "Home");
                    }

                }
                ModelState.AddModelError("", "Invalid Email or Password");
            }
            return View("Login1", model);
        }

        [HttpGet]
        public IActionResult LoginProceed()
        {
            return View("Login");
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginProceed(LoginDTO model)
        {
            
            if (ModelState.IsValid)
            {
                var md5 = new MD5CryptoServiceProvider();
                var data = Encoding.ASCII.GetBytes(model.Password);
                var md5data = md5.ComputeHash(data);
                var hashedPassword = string.Join("", MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(model.Password)).Select(s => s.ToString("x2")));
                User user = db.Users.Select(t => t).Where(u => u.Email == model.Login && u.PasswordHash == hashedPassword).FirstOrDefault();
                if (user != null)
                {
                    if(!user.EmailConfirmed)
                    {
                        ModelState.AddModelError("", "You haven`t confirmed email. Please, follow the link that that you received on email box from StudVoice");
                    }
                    Teacher t = db.Teachers.FirstOrDefault(x => x.UserId == user.Id);
                    if (t!=null)
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimsIdentity.DefaultNameClaimType, t.Name)
                        };
                        ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, "Teacher");
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
                        
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimsIdentity.DefaultNameClaimType, user.Name)
                        };
                        ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, "Student");
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
                        
                        return RedirectToAction("Index", "Home");
                    }
                  
                }
                ModelState.AddModelError("", "Invalid Email or Password");
            }
            return View("Login",model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RegisterStudent()
        {
            return View();
        }

        public bool IsValid(string strIn)
        {
            // Return true if strIn is in valid e-mail format.
            return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
        public void SendEmail(string email_to,string user_id,string email_id)
        {

            MailAddress from = new MailAddress("samarnazar33@gmail.com", "StudVoice");
           
            MailAddress to = new MailAddress(email_to);
      
            MailMessage m = new MailMessage(from, to);

            m.Subject = "Confirmation of Registration";

            m.Body = $"<body><h2>Follow this link to proceed registration of account</h2><a href='https://localhost:44343/Account/ConfirmEmailUser?email={email_to}&user_id={user_id}&email_id={email_id}'>STUDVOICE</a></body>";
        
            m.IsBodyHtml = true;
            
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            
            smtp.Credentials = new NetworkCredential("samarnazar33@gmail.com", "studvoice123");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
        [HttpPost]
        public IActionResult RegisterStudent(RegisterStudentDTO model)
        {
            if (ModelState.IsValid)
            {
                if (!IsValid(model.Email))
                {
                    ModelState.AddModelError("Email", "Invalid email.");
                    return View(model);
                }
                User user = null;

                var us = db.Contacts.FirstOrDefault(u => u.Email == model.Email);
                var id = db.Faculties.Where(x => x.Id == (int)model.Faculty).Select(x => x.Id).FirstOrDefault();
                if (us != null)
                {
                    ModelState.AddModelError("Email", "This email is bound with another user.");
                    return View(model);
                }
                if (db.Contacts.FirstOrDefault(u => u.Phone == model.ContactPhone) != null)
                {
                    ModelState.AddModelError("ContactPhone", "This phone number is bound with another user.");
                    return View(model);
                }
                else
                {
                    var user_db = new User();
                    user_db.Id = Guid.NewGuid().ToString();
                    user_db.Name = model.Name;
                    user_db.Surname = model.Surname;
                    user_db.MiddleName = model.Patronym;
                    user_db.FacultyId = id;
                    user_db.Email = model.Email;

                    var contact = new Contact();
                    contact.Id = db.Contacts.Last().Id + 1;
                    contact.Email = model.Email;
                    contact.Phone = model.ContactPhone;
                    db.Contacts.Add(contact);

                    user_db.ContactId = contact.Id;
                    

                    var hashedPassword = string.Join("", MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(model.Password)).Select(s => s.ToString("x2")));

                    user_db.PasswordHash = hashedPassword;

                    user_db.ConcurrencyStamp = Guid.NewGuid().ToString();

                    SendEmail(user_db.Email, user_db.Id, user_db.ConcurrencyStamp);
                    db.Users.Add(user_db);
                    db.SaveChanges();


                }
                return View("ConfirmEmail");
            }
            return View(model);
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
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
            if (ModelState.IsValid)
            {
                User user = null;
                if (!IsValid(registerTeacher.Email))
                {
                    ModelState.AddModelError("Email", "Invalid email.");
                    return View(registerTeacher);
                }
                var us = db.Contacts.FirstOrDefault(u => u.Email == registerTeacher.Email);
                var id = db.Faculties.Where(x => x.Id == (int)registerTeacher.Faculty).Select(x => x.Id).FirstOrDefault();
                if (us != null)
                {
                    ModelState.AddModelError("Email", "This email is bound with another user.");
                    return View(registerTeacher);
                }
                if (db.Contacts.FirstOrDefault(u => u.Phone == registerTeacher.ContactPhone) != null)
                {
                    ModelState.AddModelError("ContactPhone", "This phone number is bound with another user.");
                    return View(registerTeacher);
                }
                else
                {
                    var user_db = new User();
                    user_db.Id = Guid.NewGuid().ToString();
                    user_db.Name = registerTeacher.Name;
                    user_db.Surname = registerTeacher.Surname;
                    user_db.FacultyId = id;
                    user_db.MiddleName = registerTeacher.Patronym;
                    user_db.Email = registerTeacher.Email;

                    var contact = new Contact();
                    contact.Id = db.Contacts.Last().Id + 1;
                    contact.Email = registerTeacher.Email;
                    contact.Phone = registerTeacher.ContactPhone;
                    db.Contacts.Add(contact);

                    user_db.ContactId = contact.Id;

                    var teacher = new Teacher();
                    teacher.Id = db.Contacts.Last().Id + 1;
                    teacher.Name = registerTeacher.Name;
                    db.Teachers.Add(teacher);

                    var hashedPassword = string.Join("", MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(registerTeacher.Password)).Select(s => s.ToString("x2")));

                    user_db.PasswordHash = hashedPassword;

                    user_db.ConcurrencyStamp = Guid.NewGuid().ToString();

                    SendEmail(user_db.Email, user_db.Id, user_db.ConcurrencyStamp);
                    
                    db.Users.Add(user_db);
                    db.SaveChanges();
                }                
                return View("ConfirmEmail");
            }
            return View(registerTeacher);
        }

        public IActionResult ConfirmEmail()
        {
            return View();
        }
        //https://localhost:44343/account/ConfirmEmail?email_to=nazarsamar32@gmail.com&user_id=1&email_id=1

        public IActionResult ConfirmEmailUser(string email,string user_id,string email_id)
        {
            try
            {
                User user = db.Users.FirstOrDefault(x => x.Id == user_id && x.Email == email && x.ConcurrencyStamp == email_id);
                if(user!=null)
                {
                    return RedirectToAction("LoginProceed");
                }
                else
                {
                    return View("Error");
                }
            }
            catch
            {
                return View("Error");
            }
        }
    }
}