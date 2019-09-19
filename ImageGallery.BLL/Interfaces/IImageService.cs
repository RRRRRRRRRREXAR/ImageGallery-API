using ImageGallery.BLL.DTO;
using ImageGallery.BLL.Models;
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
       Task DeleteImage(ImageDTO image);
       Task<IEnumerable<ImageDTO>> GetImages(Expression<Func<ImageDTO,bool>> predicate);
       Task<ImageDTO> Rotate(ImageDTO image);
       Task<UserDTO> GetUserByEmail(string Email);
    }
}
