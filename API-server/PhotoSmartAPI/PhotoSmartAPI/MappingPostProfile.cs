using AutoMapper;
using PhotoSmart.Api.PostModels;
using PhotoSmart.Api.PostModels;
using PhotoSmart.Core.DTOs;
using PhotoSmart.Core.Models;

namespace PhotoSmart.Api
{
    public class MappingPostProfile : Profile
    {
        public MappingPostProfile()
        {
            CreateMap<PhotoPostModel, PhotoDto>();
            CreateMap<EventPostModel, EventDto>();
            CreateMap<GuestPostModel, GuestDto>();
            //CreateMap<UserPostModel, UserDto>();
            CreateMap<UserRegisterPostModel, UserDto>();
            CreateMap<UserLoginPostModel, UserDto>();
        }
    }
}
