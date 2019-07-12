using CoreGallery.DAL;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreGallery.Models
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly AppDbContext _appDbContext;

        public PhotoRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public IEnumerable<Photo> GetAllPhotos()
        {
            return _appDbContext.Photos;
        }

        public Photo GetPhotoById(int photoId)
        {
            return _appDbContext.Photos.FirstOrDefault(p => p.Id == photoId);
        }

        public void AddPhoto(Photo photo)
        {
            _appDbContext.Photos.Add(photo);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<IdentityUser> GetUsers()
        {
            return _appDbContext.Users;
        }
    }
}
