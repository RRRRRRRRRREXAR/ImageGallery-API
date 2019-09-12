using ImageGallery.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageGallery.DAL.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<Image> Images { get; }
        IRepository<Request> Requests { get; }
        IRepository<User> Users { get; }
        void Save();
    }
}
