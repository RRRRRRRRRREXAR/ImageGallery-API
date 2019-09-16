using AutoMapper;
using ImageGallery.BLL.DTO;
using ImageGallery.BLL.Infrostructure;
using ImageGallery.BLL.Interfaces;
using ImageGallery.BLL.Models;
using ImageGallery.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ImageGallery.BLL.Services
{
    public class UserService:IUserService
    {
        IUnitOfWork unit;
        public UserService(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        MapperConfiguration config = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MapProfile());
        });
        public UserDTO Login(string Password, string FirstName)
        {
            var mapper = new Mapper(config);
            return  mapper.Map<UserDTO>(unit.Users.Find(user => user.Password == Password && user.FirstName == FirstName));
        }

        public Task Register(UserDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
