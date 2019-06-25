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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
