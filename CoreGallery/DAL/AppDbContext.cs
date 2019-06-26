using CoreGallery.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreGallery.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Photo> Photos { get; set; }
    }


    //public class AppDbContext:IdentityDbContext<IdentityUser>
    //{
    //    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    //    {

    //    }
    //}
}
