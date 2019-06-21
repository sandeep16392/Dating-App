using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using DatingApp.Model.DataModels;
using DatingApp.Model.EntityModels;

namespace DatingApp.Model.Mappers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserListDm>()
                .ForMember(dest => dest.PhotoUrl,
                    opt => { opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url); })
                .ForMember(dest=> dest.Age, opt => { opt.MapFrom(x => x.DateOfBirth.CalculateAge()); });
            CreateMap<User, UserDetailsDm>()
                .ForMember(dest => dest.PhotoUrl,
                    opt => { opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url); })
                .ForMember(dest => dest.Age, opt => { opt.MapFrom(x => x.DateOfBirth.CalculateAge()); });
            CreateMap<Photo, PhotosDm>();
            CreateMap<UserUpdateDm, User>();
            CreateMap<UserPhotoDm, Photo>();
            CreateMap<Photo, UserPhotoDm>();
            CreateMap<UserDm, User>();
            CreateMap<User, UserDm>();
            CreateMap<UserDetailsDm, User>();
        }
    }
}
