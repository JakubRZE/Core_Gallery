using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreGallery.Models;
using CoreGallery.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace CoreGallery.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPhotoRepository _photoRepository;
        private readonly IHostingEnvironment _appEnvironment;

        public HomeController(IPhotoRepository photoRepository, IHostingEnvironment appEnvironment)
        {
            _photoRepository = photoRepository;
            _appEnvironment = appEnvironment;
        }

        public IActionResult Index()
        {
            var photos = _photoRepository.GetAllPhotos().OrderBy(p => p.Id);

            var homeViewModel = new HomeViewModel()
            {
                Count = photos.Count(),
                Photos = photos.ToList()
            };

            return View(homeViewModel);
        }

        //Add photo
        [HttpPost]
        public async Task<IActionResult> PhotoUpload(IFormFile file)
        {
            //< check >
            if (file == null || file.Length == 0) return Content("file not selected");

            //< get Path >
            string path_Root = _appEnvironment.WebRootPath;
            string path_to_Images = path_Root + "\\User_Files\\Images\\" + file.FileName;

            //< Copy File to Target >
            using (var stream = new FileStream(path_to_Images, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            //< output >
            ViewData["FilePath"] = path_to_Images;
            return RedirectToAction("Index", "Home");

        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
