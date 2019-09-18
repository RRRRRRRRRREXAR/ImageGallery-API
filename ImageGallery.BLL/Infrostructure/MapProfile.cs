using AutoMapper;
using ImageGallery.BLL.DTO;
using ImageGallery.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageGallery.BLL.Infrostructure
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<ImageDTO, Image>();
            CreateMap<Image, ImageDTO>();
            CreateMap<Request, RequestDTO>();
            CreateMap<RequestDTO, Request>();
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

        }
    }
}
