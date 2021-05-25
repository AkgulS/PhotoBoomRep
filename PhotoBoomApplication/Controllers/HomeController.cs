using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhotoBoomApplication.Models;
using PhotoBoomApplicationCore;
using PhotoBoomApplicationCore.Domain;
using PhotoBoomApplicationCore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoBoomApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment Environment;
        private readonly IPhotoService _photoService;
        public HomeController(IHostingEnvironment _environment, IPhotoService photoService)
        {
            Environment = _environment;
            _photoService = photoService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MyPhotos()
        {
            var photos = _photoService.GetAll();
            return View(photos);
        }
        public IActionResult AddPhoto()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddPhoto([FromForm] PhotoDto data)
        {
            var a = Request.Form.Files;
            string wwwPath = this.Environment.WebRootPath;
            string contentPath = this.Environment.ContentRootPath;
            string path = Path.Combine(this.Environment.WebRootPath, "Uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            List<string> uploadedFiles = new List<string>();

            string fileName = Path.GetFileName(data.Photo.FileName);
            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                data.Photo.CopyTo(stream);
                uploadedFiles.Add(fileName);
                ViewBag.Message += string.Format("&lt;b&gt;{0}&lt;/b&gt; uploaded.&lt;br /&gt;", fileName);
            }
            Photo photos = new Photo()
            {
                PhotoName = fileName,
                Tags = data.Tags,
                Title = data.Title
            };
            _photoService.Add(photos);
            var models = _photoService.GetAll();
            return RedirectToAction("MyPhotos", models);
        }
        public IActionResult ViewPhoto(int Id)
        {
            var photo = _photoService.Get(x => x.Id == Id);
            return View(photo);
        }
        public IActionResult DeletePhoto(int Id)
        {
            var deletePhoto = _photoService.Get(x => x.Id == Id);
            _photoService.Delete(deletePhoto);
            var models = _photoService.GetAll();
            return RedirectToAction("MyPhotos", models);
        }
    }
}
