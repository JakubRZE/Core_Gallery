using CoreGallery.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreGallery.ViewModels
{
    public class HomeViewModel
    {
        public int Count { get; set; }
        public List<Photo> Photos { get; set; }

        public string Description { get; set; }
        public IFormFile Photo { get; set; }
    }
}
