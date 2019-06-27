using CoreGallery.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreGallery.Models
{
    public class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Photos.Any())
            {
                context.AddRange
                (
                  new Photo { Description = "pierwsze", Path = @"/image/img1.jpg" },
                  new Photo { Description = "drugie", Path = @"/image/img2.jpg" },
                  new Photo { Description = "trzecie", Path = @"/image/img3.jpg" },
                  new Photo { Description = "czwarte", Path = @"/image/img4.jpg" },
                  new Photo { Description = "five", Path = @"/image/img5.jpg" }
                );

                context.SaveChanges();
            }
        }

    }
}
