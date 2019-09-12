using ImageGallery.BLL.DTO;
using ImageGallery.BLL.Interfaces;
using ImageGallery.BLL.Models;
using ImageGallery.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ImageGallery.BLL.Services
{
    public class ImageService:IImageService
    {
        private IUnitOfWork unit;
        public ImageService(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public Task DeleteImage(ImageDTO image)
        {
            throw new NotImplementedException();
        }

        public Task GetImages(Expression<Func<ImageDTO, bool>, predicate> )
        {
            throw new NotImplementedException();
        }

        public Task UploadImage(ImageModel image)
        {
            throw new NotImplementedException();
        }
    }
}
