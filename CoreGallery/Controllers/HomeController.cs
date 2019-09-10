using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreGallery.Models;
using CoreGallery.ViewModels;

namespace CoreGallery.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPhotoRepository _photoRepository;

        public HomeController(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
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

        [HttpPost]
        public IActionResult UploadPhoto(HomeViewModel model)
        {
            if (ModelState.IsValid)
            {    
                    _photoRepository.AddPhoto(model);
            }
            return RedirectToAction("Index", "Home");
        }

        public JsonResult GetUsers()
        {
            var users = _photoRepository.GetUsers().Select(x => x.UserName);
            return Json(users);
        }
    }
}
