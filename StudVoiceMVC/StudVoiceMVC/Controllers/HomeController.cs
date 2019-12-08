using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StudVoiceMVC.Models;
using StudVoice.BLL.Services.ImplementedServices;
using QRCoder;
using System.DrawingCore;
using System;
using System.IO;
using StudVoice.BLL.DTOs;
using System.Collections.Generic;
using StudVoice.BLL.Services.Interfaces;
using StudVoice.BLL.Factories;
using System.Threading.Tasks;

namespace StudVoiceMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly ILessonService _lessonService;


        public HomeController(IServiceFactory serviceFactory)
        {
            _teacherService = serviceFactory.TeacherService;
            _lessonService = serviceFactory.LessonService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Teacher(int id)
        {
            var res = await _teacherService.GetAsync(id);
            return View("~/Views/Teacher/TeacherView.cshtml",res);
        }

        public IActionResult CreateLesson()
        {
            return View("~/Views/Teacher/Lesson/CreateLessonView.cshtml");
        }
       
        public IActionResult Lesson(int id)
        {   
            return View("~/Views/Teacher/Lesson/LessonView.cshtml", _lessonService.GetAsync(id));
        }

        [HttpPost]
        public IActionResult QrCode(string qrText)
        {
            qrText = "Text";
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrText,
            QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            return File(BitmapToBytes(qrCodeImage),"image/jpeg");
        }

        private static Byte[] BitmapToBytes(Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.DrawingCore.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
