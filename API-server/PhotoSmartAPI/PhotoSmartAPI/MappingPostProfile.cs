using AutoMapper;
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
            CreateMap<AlbumPostModel, AlbumDto>();
            CreateMap<TagPostModel, TagDto>();
            CreateMap<UserPostModel, UserDto>();
        }
    }
}
