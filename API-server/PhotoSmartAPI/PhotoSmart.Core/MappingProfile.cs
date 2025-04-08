using AutoMapper;
using PhotoSmart.Core.DTOs;
using PhotoSmart.Core.Models;

namespace PhotoSmart.Core
{
    /// <summary>
    /// ///
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>()
           .ForMember(dest => dest.Password, opt => opt.Ignore());
            CreateMap<UserDto, User>()
                     .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password)); 
            CreateMap<Event, EventDto>().ReverseMap();
            CreateMap<Photo, PhotoDto>().ReverseMap();
            CreateMap<Guest, GuestDto>().ReverseMap();
        }
        
    }
}
