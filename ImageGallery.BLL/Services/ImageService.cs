using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using ImageGallery.BLL.DTO;
using ImageGallery.BLL.Infrostructure;
using ImageGallery.BLL.Interfaces;
using ImageGallery.BLL.Models;
using ImageGallery.DAL.Entities;
using ImageGallery.DAL.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using Image = ImageGallery.DAL.Entities.Image;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;

namespace ImageGallery.BLL.Services
{
    public class ImageService:IImageService
    {
        MapperConfiguration config = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MapProfile());
        });
        private IUnitOfWork unit;
        public ImageService(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public async Task DeleteImage(int id)
        {
            unit.Images.Delete(id);
            //var img = await unit.Images.Find(d => d.Id == id);
            // File.Delete(img[0].);
            unit.Save();
        }

        public async Task<ImageDTO> GetImage(int id)
        {
            var mapper = new Mapper(config);
            var images = await unit.Images.Find(d => d.Id == id);
            return mapper.Map<ImageDTO>(images[0]);
        }

        public async Task<IEnumerable<ImageDTO>> GetImages(Expression<Func<Image, bool>> predicate)
        {
            var mapper = new Mapper(config);
            var lit = unit.Images.Find(predicate).Result;
            List<ImageDTO> images= mapper.Map<List<ImageDTO>>(lit);
            return images;
        }

        public async Task<ImageDTO> Resize(int id, int height, int width)
        {
            var mapper = new Mapper(config);
            ImageDTO image = await GetImage(id);
            using (SixLabors.ImageSharp.Image img = SixLabors.ImageSharp.Image.Load(image.Link, out var imageFormat))
            {
                img.Mutate(x => x.Resize(width,height));
                image.Link = image.Link + width.ToString() + height.ToString();
                img.Save(image.Link);
                await unit.Images.Create(mapper.Map<Image>(image));
            }
            return image;

        }

        public async Task<ImageDTO> Rotate(ImageDTO image)
        {
          return await Task<ImageDTO>.Run(()=> {
               using (SixLabors.ImageSharp.Image img = SixLabors.ImageSharp.Image.Load(image.Link, out var imageFormat))
               {
                   img.Mutate(x => x.Rotate(RotateMode.Rotate90));
                   img.Save(image.Link);
               }
               return image;
           });
        }

        public async Task UploadImage(IHostingEnvironment _appEnvironment, IFormFile image,UserDTO user)
        {
            var mapper = new Mapper(config);
            var fileName = ContentDispositionHeaderValue.Parse(image.ContentDisposition).FileName.Trim('"');
            string path = "/Images/" + fileName;
            using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
            {
               await image.CopyToAsync(fileStream);
            }
            ImageDTO uploadedImage = new ImageDTO { Link = "https://localhost:44327" + path, User=user };
            await unit.Images.Create(mapper.Map<Image>(uploadedImage));
            unit.Save();
        }

        Task IImageService.Resize(int id, int height, int width)
        {
            throw new NotImplementedException();
        }
    }
}
