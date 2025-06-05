using AutoMapper;
using Business.DTOs.Auth;
using Data.Access.Entities.Auth;

namespace Business.DTOs
{
    public class MapperProfileDTO : Profile
    {
        public MapperProfileDTO()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
