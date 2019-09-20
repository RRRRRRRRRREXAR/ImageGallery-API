using ImageGallery.BLL.DTO;
using ImageGallery.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ImageGallery.BLL.Interfaces
{
    public interface IUserService
    {
        Task Register(UserDTO user);
        UserDTO Login(string Password,string FirstName);
        UserDTO GetUserByEmail(string Email);
    }
}
