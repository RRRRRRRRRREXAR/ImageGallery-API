using AutoMapper;
using ImageGallery.BLL.DTO;
using ImageGallery.BLL.Infrostructure;
using ImageGallery.BLL.Interfaces;
using ImageGallery.DAL.Entities;
using ImageGallery.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ImageGallery.BLL.Services
{
    public class RequestService : IRequestService
    {
        IUnitOfWork unit;
        MapperConfiguration config = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MapProfile());
        });
        public RequestService(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public async Task CreateRecord(RequestDTO request)
        {
            var mapper = new Mapper(config);
            await unit.Requests.Create(mapper.Map<Request>(request));
            unit.Save();
        }
    }
}
