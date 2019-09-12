using ImageGallery.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ImageGallery.BLL.Interfaces
{
    public interface IRegister
    {
        Task Register(UserDTO user);
    }
}
