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
                  new Photo { Description = "pierwsze", Path = @"/images/img1.jpg" },
                  new Photo { Description = "drugie", Path = @"/images/img2.jpg" },
                  new Photo { Description = "trzecie", Path = @"/images/img3.jpg" },
                  new Photo { Description = "czwarte", Path = @"/images/img4.jpg" },
                  new Photo { Description = "five", Path = @"/images/img5.jpg" }
                );

                context.SaveChanges();
            }
        }

    }
}
