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
using System.Security.Claims;

namespace CoreGallery.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPhotoRepository _photoRepository;
        private readonly IHostingEnvironment _hostingEnvironment;

        public HomeController(IPhotoRepository photoRepository, IHostingEnvironment hostingEnvironment)
        {
            _photoRepository = photoRepository;
            _hostingEnvironment = hostingEnvironment;
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
        public IActionResult UploadPhoto(HomeViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.Photo != null)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                // get logged user id
                var claimsIdentity = (ClaimsIdentity)this.User.Identity;
                var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
                var userId = claim.Value;

                Photo newPhoto = new Photo
                {
                    Description = model.Description,
                    UserId = userId,
                    Path = @"/images/" + uniqueFileName
                };

                _photoRepository.AddPhoto(newPhoto);

                return RedirectToAction("Index", "Home");
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
