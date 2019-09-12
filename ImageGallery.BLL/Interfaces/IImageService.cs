using ImageGallery.BLL.DTO;
using ImageGallery.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ImageGallery.BLL.Interfaces
{
   public interface IImageService
    {
       Task UploadImage(ImageModel image);
       Task DeleteImage(ImageDTO image);
       Task GetImages(Expression<Func<ImageDTO,bool>> predicate);
    }
}
