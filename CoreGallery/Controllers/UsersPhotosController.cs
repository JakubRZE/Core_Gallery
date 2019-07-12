using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreGallery.Models;
using CoreGallery.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CoreGallery.Controllers
{
    public class UsersPhotosController : Controller
    {
        private readonly IPhotoRepository _photoRepository;

        public UsersPhotosController(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }


        public IActionResult Index(string userId)
        {
            var photos = _photoRepository.GetAllPhotos().Where(x => x.UserId == userId).OrderBy(p => p.Id);

            var UsersPhotosVM = new UsersPhotosViewModel()
            {
                Count = photos.Count(),
                Photos = photos.ToList(),
                UserName = _photoRepository.GetUsers().Where(p => p.Id == userId).Select(x => x.UserName).FirstOrDefault()
            };

            return View(UsersPhotosVM);
        }
    }
}