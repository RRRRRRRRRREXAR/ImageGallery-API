using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageGallery.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImageGallery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        IImageService service;
        IHostingEnvironment hostingEnviroment;
        IUserService userService;
        public ImageController(IImageService service,IHostingEnvironment hostingEnviroment)
        {
            this.service = service;
            this.hostingEnviroment = hostingEnviroment;
        }
        [Authorize]
        public async Task Post(IFormFile image)
        {
            await service.UploadImage(hostingEnviroment,image,userService.);
        }
    }
}