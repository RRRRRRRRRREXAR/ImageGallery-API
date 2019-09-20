using AutoMapper;
using ImageGallery.BLL.DTO;
using ImageGallery.BLL.Infrostructure;
using ImageGallery.BLL.Interfaces;
using ImageGallery.BLL.Models;
using ImageGallery.DAL.Entities;
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
        public UserDTO Login(string Password, string Email)
        {
            var mapper = new Mapper(config);
            var result=  mapper.Map<UserDTO>(unit.Users.Find(user => user.Password == Password && user.Email == Email));
            return result;
        }

        public UserDTO GetUserByEmail(string Email)
        {
            var mapper = new Mapper(config);
            var smt = unit.Users.Find(user => user.Email == Email).Result;
            var foundedUser= mapper.Map<UserDTO>(smt[0]);
            return foundedUser;
        }
        public async Task Register(UserDTO user)
        {
            var mapper = new Mapper(config);
            await unit.Users.Create(mapper.Map<User>(user));
            unit.Save();
        }
    }
}
