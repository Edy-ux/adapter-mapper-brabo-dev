using AutoMapper;
using MapperVsAdapter.Application.Entities;
using MapperVsAdapter.Application.Models;

namespace MapperVsAdapter.Application.Mapper
{
    public class UserMapper : Profile
    {
        public UserMapper() 
        {
            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();
        }
    }
}
