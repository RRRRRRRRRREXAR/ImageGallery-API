using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ImageGallery.BLL.Interfaces;
using ImageGallery.DAL.Entities;
using ImageGallery.Models;
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
        private readonly IMapper mapper;

        public ImageController(IImageService service,IHostingEnvironment hostingEnviroment,IUserService userService,IMapper mapper)
        {
            this.service = service;
            this.userService = userService;
            this.hostingEnviroment = hostingEnviroment;
            this.mapper = mapper;
        }
        [Authorize]
        public async Task Post(IFormFile image)
        {
            var user= userService.GetUserByEmail(User.Identity.Name);
            await service.UploadImage(hostingEnviroment,image,user);
        }
        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<ImageModel>> Get()
        {
            var user = mapper.Map<User>(userService.GetUserByEmail(User.Identity.Name));
            var images = await service.GetImages(us => us.User == user);
            return mapper.Map<IEnumerable<ImageModel>>(images);
        }
        [HttpGet("/GetImage")]
        [Authorize]
        public async Task<ImageModel> GetImage(int id)
        {
           // var user = mapper.Map<User>(userService.GetUserByEmail(User.Identity.Name));
            var image = await service.GetImage(id);
            return mapper.Map<ImageModel>(image);
        }
        [HttpDelete]
        [Authorize]
        public async Task Delete(string id)
        {
            await service.DeleteImage(Convert.ToInt32(id));
        }
    }
}