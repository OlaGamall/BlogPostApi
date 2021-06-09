using AutoMapper;
using _360ImagingTask.Dtos;
using _360ImagingTask.Models;

namespace Souqly_API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {

            CreateMap<UserDto, User>();// Create
            
            CreateMap<PostDto, Post>();

            CreateMap<CommentDto, Comment>();

        }
    }
}