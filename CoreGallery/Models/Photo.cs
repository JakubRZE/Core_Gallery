using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreGallery.Models
{
    public class Photo
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string PhotoUrl { get; set; }

        public string PhotoThumbnailUrl { get; set; }
    }
}
