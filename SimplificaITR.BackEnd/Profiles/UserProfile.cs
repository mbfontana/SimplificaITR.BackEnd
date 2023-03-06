using AutoMapper;
using SimplificaITR.BackEnd.Data.Dtos.User;
using SimplificaITR.BackEnd.Models;

namespace SimplificaITR.BackEnd.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterUserDto, User>();
            CreateMap<User, GetUserByIdDto>();
            CreateMap<UpdateUserDto, User>();
        }
    }
}
