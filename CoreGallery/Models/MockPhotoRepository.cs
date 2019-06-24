using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreGallery.Models
{
    public class MockPhotoRepository : IPhotoRepository
    {
        private List<Photo> _photos;

        public MockPhotoRepository()
        {
            if (_photos == null)
            {
                InitializePhotos();
            }
        }

        private void InitializePhotos()
        {
            _photos = new List<Photo>
            {
                new Photo { Id=1, Description ="pierwsze", PhotoThumbnailUrl=@"/image/img1.jpg", PhotoUrl=@"/image/img2-full.jpeg"},
                new Photo { Id=2, Description ="drugie", PhotoThumbnailUrl=@"/image/img2.jpg", PhotoUrl=@"/image/img2-full.jpeg"},
                new Photo { Id=3, Description ="trzecie", PhotoThumbnailUrl=@"/image/img3.jpg", PhotoUrl=@"/image/img2-full.jpeg"},
                new Photo { Id=3, Description ="czwarte", PhotoThumbnailUrl=@"/image/img4.jpg", PhotoUrl=@"/image/img2-full.jpeg"}
            };
        }

        public List<Photo> GetAllPhotos()
        {
            return _photos;
        }

        public Photo GetPhotoById(int photoId)
        {
            return _photos.FirstOrDefault(p => p.Id == photoId);
        }
    }
}
