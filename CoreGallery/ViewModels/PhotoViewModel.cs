using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreGallery.ViewModels
{
    public class PhotoViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string UserId { get; set; }

        public IFormFile Photo { get; set; }
    }
}
