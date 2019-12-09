using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StudVoiceMVC.Models;
using QRCoder;
using System.DrawingCore;
using System;
using System.IO;
using StudVoice.BLL.DTOs;
using StudVoice.BLL.Services.Interfaces;
using StudVoice.BLL.Factories;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using StudVoice.DAL;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using StudVoice.DAL.Repositories.ImplementedRepositories;

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

        public async Task<IActionResult> Teacher(string name)
        {
            var t = await _teacherService.GetAsyncNameAsync(name);
            var teacherDTO = await _teacherService.GetAsync(t.Id);
            teacherDTO.QrCode = QrCode("https://localhost:44343/Home/Teacher/" + $"{teacherDTO.Id}");
            return View("~/Views/Teacher/TeacherView.cshtml", teacherDTO);
        }

        public IActionResult CreateLessonForm(int teacherid)
        {
            return View("~/Views/Teacher/Lesson/CreateLessonView.cshtml",new LessonDTO() { TeacherId = teacherid});
        }
       
        //public async void AddLesson(LessonDTO lessonDTO)
        //{
        //    var res =await _lessonService.CreateAsync(lessonDTO);
        //    Lesson(res.Id);
        //}

        public async Task<IActionResult> Lesson(int id)
        {
            var lessonDTO = await _lessonService.GetAsync(id);
            lessonDTO.QrCode = QrCode("https://localhost:44343/Home/Lesson/"+$"{lessonDTO.Id}");
            return View("~/Views/Teacher/Lesson/LessonView.cshtml", lessonDTO);
        }

        [HttpPost]
        public Byte[] QrCode(string qrText)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrText,
            QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            return BitmapToBytes(qrCodeImage);
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
