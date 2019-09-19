using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageGallery.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImageGallery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        IImageService service;
        public ImageController(IImageService service)
        {
            this.service = service;
        }
        [Authorize]
        public async Task Post(IFormFile image)
        {
            await service.UploadImage(new BLL.Models.ImageModel { img=image },new BLL.DTO.UserDTO { });
        }
    }
}