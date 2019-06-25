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
                new Photo { Id=1, Description ="pierwsze", PhotoThumbnailUrl=@"#", PhotoUrl=@"/image/img1.jpg"},
                new Photo { Id=2, Description ="drugie", PhotoThumbnailUrl=@"#", PhotoUrl=@"/image/img2.jpg"},
                new Photo { Id=3, Description ="trzecie",PhotoThumbnailUrl=@"#", PhotoUrl=@"/image/img3.jpg"},
                new Photo { Id=4, Description ="czwarte", PhotoThumbnailUrl=@"#", PhotoUrl=@"/image/img4.jpg"},
                 new Photo { Id=5, Description ="czwarte", PhotoThumbnailUrl=@"#", PhotoUrl=@"/image/img5.jpg"},
                  new Photo { Id=6, Description ="czwarte", PhotoThumbnailUrl=@"#", PhotoUrl=@"/image/img6.jpg"},
                   new Photo { Id=7, Description ="czwarte", PhotoThumbnailUrl=@"#", PhotoUrl=@"/image/img7.jpg"},
                    new Photo { Id=8, Description ="czwarte", PhotoThumbnailUrl=@"#", PhotoUrl=@"/image/img8.jpg"},
                     new Photo { Id=9, Description ="czwarte", PhotoThumbnailUrl=@"#", PhotoUrl=@"/image/img9.jpg"},
                      new Photo { Id=10, Description ="czwarte", PhotoThumbnailUrl=@"#", PhotoUrl=@"/image/img10.jpg"},
                       new Photo { Id=11, Description ="czwarte", PhotoThumbnailUrl=@"#", PhotoUrl=@"/image/img11.jpg"},
                        new Photo { Id=12, Description ="czwarte", PhotoThumbnailUrl=@"#", PhotoUrl=@"/image/img12.jpg"},
                         new Photo { Id=13, Description ="czwarte", PhotoThumbnailUrl=@"#", PhotoUrl=@"/image/img13.jpg"},
                          new Photo { Id=14, Description ="czwarte", PhotoThumbnailUrl=@"#", PhotoUrl=@"/image/img14.jpg"},
                           new Photo { Id=15, Description ="czwarte", PhotoThumbnailUrl=@"#", PhotoUrl=@"/image/img15.jpg"},
                            new Photo { Id=16, Description ="czwarte", PhotoThumbnailUrl=@"#", PhotoUrl=@"/image/img16.jpg"},
                             new Photo { Id=17, Description ="czwarte", PhotoThumbnailUrl=@"#", PhotoUrl=@"/image/img17.jpg"}

                             //new Photo { Id=18, Description ="czwarte", PhotoThumbnailUrl=@"#", PhotoUrl=@"/image/img6.jpg"},
                             // new Photo { Id=18, Description ="czwarte", PhotoThumbnailUrl=@"#", PhotoUrl=@"/image/img6.jpg"}
            };
        }

        public IEnumerable<Photo> GetAllPhotos()
        {
            return _photos;
        }

        public Photo GetPhotoById(int photoId)
        {
            return _photos.FirstOrDefault(p => p.Id == photoId);
        }
    }
}
