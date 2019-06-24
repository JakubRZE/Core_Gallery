using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreGallery.Models
{
    public interface IPhotoRepository
    {
        List<Photo> GetAllPhotos();

        Photo GetPhotoById(int photoId);
    }
}
