using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreGallery.Models
{
    public interface IPhotoRepository
    {
        IEnumerable<Photo> GetAllPhotos();

        Photo GetPhotoById(int photoId);

        void AddPhoto(Photo photo);

        void DeletePhoto(int id);

        IEnumerable<IdentityUser> GetUsers();
    }
}
