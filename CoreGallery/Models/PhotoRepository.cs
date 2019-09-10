using CoreGallery.DAL;
using CoreGallery.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreGallery.Models
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PhotoRepository(AppDbContext appDbContext, IHostingEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            _appDbContext = appDbContext;
            _hostingEnvironment = hostingEnvironment;
            _httpContextAccessor = httpContextAccessor;
        }


        public IEnumerable<Photo> GetAllPhotos()
        {
            return _appDbContext.Photos;
        }

        public Photo GetPhotoById(int photoId)
        {
            return _appDbContext.Photos.FirstOrDefault(p => p.Id == photoId);
        }

        public void AddPhoto(HomeViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(stream);
                }

                //var claimsIdentity = (ClaimsIdentity)this.User.Identity;
                //var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
                //var userId = claim.Value;
                var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

                Photo newPhoto = new Photo
                {
                    Description = model.Description,
                    UserId = userId,
                    Path = @"/images/" + uniqueFileName
                };

                _appDbContext.Photos.Add(newPhoto);
                _appDbContext.SaveChanges();
            }
        }

        public IEnumerable<IdentityUser> GetUsers()
        {
            return _appDbContext.Users;
        }

        public void DeletePhoto(int id)
        {
            var photo = GetPhotoById(id);

            if (photo != null)
            {
                var serverPath = _hostingEnvironment.WebRootPath;
                string fullPath = serverPath + photo.Path;
                fullPath = fullPath.Replace(@"\\", @"\").Replace(@"/", @"\");

                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
                _appDbContext.Photos.Remove(photo);
                _appDbContext.SaveChanges();
            }
        }
    }
}
