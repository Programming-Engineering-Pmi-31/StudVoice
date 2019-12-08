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
            TeacherDTO teacherdto = new TeacherDTO()
            {
                Id = 1,
                Name = "Ostap",
                Lessons = new List<LessonDTO>()
                {
                    new LessonDTO()
                    {
                        Name = "LessonName1",
                        DateTime = DateTime.Now,
                        Description = "descriptionafafadadasd",
                        Theme = "Astronomy",
                        LessonFeedbacks = new List<LessonFeedbackDTO>()
                        {
                            { new LessonFeedbackDTO() { FeedBack = "Heello Feedback for Astronomy 1", LessonId = 1, Point = 10 } },
                            { new LessonFeedbackDTO() { FeedBack = "Heello Feedback for Astronomy 2", LessonId = 1, Point = 11 } }
                        },
                    },
                    new LessonDTO()
                    {
                        Name = "LessonName2",
                        DateTime = DateTime.Now,
                        Description = "descriptionafafadadasd",
                        Theme = "Matan",
                        LessonFeedbacks = new List<LessonFeedbackDTO>()
                        {
                            { new LessonFeedbackDTO() { FeedBack = "Heello Feedback for Matan 1", LessonId = 2, Point = 5 } },
                            { new LessonFeedbackDTO() { FeedBack = "Heello Feedback for Matan 2", LessonId = 2, Point = 4 } }
                        },
                    }
                },
                TeacherFeedBacks = new List<TeacherFeedbackDTO>()
                {
                    {new TeacherFeedbackDTO(){Feedback = "Good teacher",Point = 12,TeacherId = 1 } },
                    {new TeacherFeedbackDTO(){Feedback = "Bad teacher",Point = 2,TeacherId = 1 } }
                }
            };
            return View("~/Views/Teacher/TeacherView.cshtml",teacherdto);
        }

        public IActionResult CreateLesson()
        {
            return View("~/Views/Teacher/Lesson/CreateLessonView.cshtml");
        }
       
        public IActionResult Lesson()
        {
            return View("~/Views/Teacher/Lesson/LessonView.cshtml");
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
