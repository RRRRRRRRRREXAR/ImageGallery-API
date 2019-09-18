using AutoMapper;
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

        public async Task DeleteImage(ImageDTO image)
        {
            unit.Images.Delete(image.Id);
            await Task.Run(() => { File.Delete(image.Link); });
        }

        public async Task<IEnumerable<ImageDTO>> GetImages(Expression<Func<ImageDTO, bool>> predicate)
        {
            var mapper = new Mapper(config);
            Expression<Func<Image, bool>> expression = mapper.Map<Expression<Func<Image, bool>>>(predicate);
            List<ImageDTO> images= mapper.Map<List<ImageDTO>>(unit.Images.Find(expression));
            return images;
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

        public async Task UploadImage(ImageModel model,UserDTO user)
        {
            var mapper = new Mapper(config);
            var filePath = Path.GetTempFileName();
            var stream = new FileStream(filePath, FileMode.Create);
            Image uploadedImage = new Image { Link = filePath, User = mapper.Map<User>(user) };
            await Task.WhenAll(unit.Images.Create(uploadedImage), model.img.CopyToAsync(stream));
            unit.Save();
        }

    }
}
