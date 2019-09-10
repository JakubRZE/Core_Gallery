using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CoreGallery.Models;
using CoreGallery.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreGallery.Controllers
{
    public class UsersPhotosController : Controller
    {
        private readonly IPhotoRepository _photoRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHostingEnvironment _hostingEnvironment;

        public UsersPhotosController(IPhotoRepository photoRepository, UserManager<IdentityUser> userManager, IHostingEnvironment hostingEnvironment)
        {
            _photoRepository = photoRepository;
            _userManager = userManager;
            _hostingEnvironment = hostingEnvironment;
        }

    
        public IActionResult Index(string searchName)
        {

            var userId = _photoRepository.GetUsers().Where(u => u.UserName == searchName).Select( o => o.Id).FirstOrDefault();
            var photos = _photoRepository.GetAllPhotos().Where(x => x.UserId == userId).OrderBy(p => p.Id);

            var UsersPhotosVM = new UsersPhotosViewModel()
            {
                Count = photos.Count(),
                Photos = photos.ToList(),
                UserName = searchName
            };

            return View(UsersPhotosVM);
        }

        public JsonResult GetMyPhotos()
        {
            var userId = _userManager.GetUserId(User);
            var photos = _photoRepository.GetAllPhotos().Where(x => x.UserId == userId).OrderBy(p => p.Id).ToList();

            return Json(photos);
        }

        [HttpPost]
        public JsonResult DeletePhoto(int id)
        {
            _photoRepository.DeletePhoto(id);
            return Json("success");
        }
    }
}