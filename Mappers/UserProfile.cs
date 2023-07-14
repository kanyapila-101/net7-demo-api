using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using net7_demo_api.Dtos;
using net7_demo_api.Entities;

namespace net7_demo_api.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserModel, UserDto>()
                .ForMember(t => t.Id, o => o.MapFrom(t => t.Id))
                .ForMember(t => t.UserName, o => o.MapFrom(t => t.UserName))
                .ForMember(t => t.UserCode, o => o.MapFrom(t => t.UserCode))
                .ForMember(t => t.FirstName, o => o.MapFrom(t => t.FirstName))
                .ForMember(t => t.LastName, o => o.MapFrom(t => t.LastName))
                .ForMember(t => t.MobileNo, o => o.MapFrom(t => t.MobileNo))
                .ForMember(t => t.CreatedAt, o => o.MapFrom(t => t.CreatedAt))
                .ForMember(t => t.UpdatedAt, o => o.MapFrom(t => t.UpdatedAt))
                .ReverseMap();
        }
    }
}