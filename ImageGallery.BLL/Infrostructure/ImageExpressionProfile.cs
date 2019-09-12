using AutoMapper;
using ImageGallery.BLL.DTO;
using ImageGallery.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageGallery.BLL.Infrostructure
{
    class ImageExpressionProfile:Profile
    {
        public ImageExpressionProfile()
        {
            CreateMap<ImageDTO,Image>().
                ForMember(dto=>dto.item)
        }
    }
}
