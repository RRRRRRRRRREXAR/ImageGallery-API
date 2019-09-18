using ImageGallery.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageGallery.DAL.DB
{
    public class GalleryContext : DbContext
    {
        DbSet<Image> Images { get; set; }
        DbSet<Request> Requests { get; set; }
        DbSet<User> Users { get; set; }
            
        public GalleryContext(DbContextOptions<GalleryContext> options):base(options)
        {
            Database.EnsureCreated();
        }
    }
}
