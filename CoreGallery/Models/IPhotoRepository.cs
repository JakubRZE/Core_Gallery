using CoreGallery.ViewModels;
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

        void AddPhoto(HomeViewModel model);

        void DeletePhoto(int id);

        IEnumerable<IdentityUser> GetUsers();
    }
}
