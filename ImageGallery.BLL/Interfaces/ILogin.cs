using ImageGallery.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ImageGallery.BLL.Interfaces
{
    public interface ILogin
    {
        Task<TokenModel> Login(LoginModel user);
    }
}
