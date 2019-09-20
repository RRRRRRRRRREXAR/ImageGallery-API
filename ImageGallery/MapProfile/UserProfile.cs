using AutoMapper;
using ImageGallery.BLL.DTO;
using ImageGallery.DAL.Entities;
using ImageGallery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageGallery.MapProfile
{
    public class UserProfile:Profile
    {

        public UserProfile()
        {
            CreateMap<ImageDTO, ImageModel>().
                ForMember(
                dest => dest.Owner,
                opt => opt.MapFrom(src => src.User)
                );
            CreateMap<ImageModel, ImageDTO>().
                ForMember(
                dest => dest.User,
                opt => opt.MapFrom(src => src.Owner)
                );
            CreateMap<Person, UserDTO>();
            CreateMap<UserDTO, Person>().
                ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.Id)
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
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();

        }

    }
}
