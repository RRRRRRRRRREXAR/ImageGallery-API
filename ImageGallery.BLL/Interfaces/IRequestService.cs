using ImageGallery.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ImageGallery.BLL.Interfaces
{
    public interface IRequestService
    {
        Task CreateRecord(RequestDTO request);
    }
}
