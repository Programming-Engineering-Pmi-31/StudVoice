using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StudVoiceMVC.Models;

namespace StudVoiceMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Teacher()
        {
            return View("~/Views/Teacher/TeacherView.cshtml");
        }

        public IActionResult CreateLesson()
        {
            return View("~/Views/Teacher/Lesson/CreateLessonView.cshtml");
        }
       
        public IActionResult Lesson()
        {
            return View("~/Views/Teacher/Lesson/LessonView.cshtml");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
