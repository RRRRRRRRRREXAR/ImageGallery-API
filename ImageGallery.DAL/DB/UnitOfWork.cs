using ImageGallery.DAL.Entities;
using ImageGallery.DAL.Interfaces;
using ImageGallery.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageGallery.DAL.DB
{
    public class UnitOfWork:IUnitOfWork
    {
        private GalleryContext db;
        private Repository<Image> imageRepository;
        private Repository<Request> requestRepository;
        private Repository<User> userRepository;
       
        public UnitOfWork(GalleryContext context)
        {
            this.db = context;
        }
       public IRepository<Image> Images
        {
            get
            {
                if (imageRepository == null)
                {
                    imageRepository = new Repository<Image>(db);
                }
                return imageRepository;
            }
        }

        public IRepository<Request> Requests
        {
            get
            {
                if (requestRepository == null)
                {
                    requestRepository = new Repository<Request>(db);
                }
                return requestRepository;
            }
        }
        public IRepository<User> Users
        {
            get
            {
                if (userRepository==null)
                {
                    userRepository = new Repository<User>(db);
                }
                return userRepository;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
