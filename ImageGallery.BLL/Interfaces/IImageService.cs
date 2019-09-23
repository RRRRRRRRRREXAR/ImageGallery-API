using ImageGallery.BLL.DTO;
using ImageGallery.BLL.Models;
using ImageGallery.DAL.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ImageGallery.BLL.Interfaces
{
   public interface IImageService
    {
       Task UploadImage(IHostingEnvironment _appEnvironment, IFormFile image, UserDTO user);
       Task DeleteImage(int id);
       Task<IEnumerable<ImageDTO>> GetImages(Expression<Func<Image,bool>> predicate);
       Task<ImageDTO> Rotate(ImageDTO image);
        Task<ImageDTO> GetImage(int id);
       Task Resize(int id,int height,int width);
       
    }
}
