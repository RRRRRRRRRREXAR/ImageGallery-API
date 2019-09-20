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
            CreateMap<ImageDTO, Image>().
                ForMember(
                dest=>dest.User,
                opt=>opt.MapFrom(src=>src.User)
                ).
                ForMember(
                dest => dest.Link,
                opt => opt.MapFrom(src => src.Link));
            CreateMap<Image, ImageDTO>().
                ForMember(
                dest=>dest.User,
                opt=>opt.MapFrom(src=>src.User)).
                ForMember(
                dest=>dest.Link,
                opt=>opt.MapFrom(src=>src.Link));
            CreateMap<Request, RequestDTO>();
            CreateMap<RequestDTO, Request>();
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>().
                ForMember(
                dest=>dest.Id,
                opt=>opt.MapFrom(src=>src.Id)
                ).
                ForMember(
                dest => dest.Password,
                opt => opt.MapFrom(src => src.Password)
                ).
                ForMember(
                dest => dest.FirstName,
                opt => opt.MapFrom(src => src.FirstName)
                ).
                ForMember(
                dest => dest.Role,
                opt => opt.MapFrom(src => src.Role)
                ).
                ForMember(
                dest => dest.Email,
                opt => opt.MapFrom(src => src.Email)
                )
                ;

        }
    }
}
