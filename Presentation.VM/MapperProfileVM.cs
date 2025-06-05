using AutoMapper;
using Presentation.VMs.Auth;
using Business.DTOs.Auth;

namespace Presentation.VMs
{
    public class MapperProfileVM : Profile
    {
        public MapperProfileVM()
        {
            CreateMap<UserDTO, UserVM>().ReverseMap();
        }
    }
}
