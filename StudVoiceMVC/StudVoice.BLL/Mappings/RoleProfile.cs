using AutoMapper;
using StudVoice.BLL.DTOs;
using StudVoice.DAL;

namespace StudVoice.BLL.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, Role>()
                .ForMember(t => t.ConcurrencyStamp, opt => opt.Ignore());
            CreateMap<Role, RoleDTO>()
                .ForMember(t => t.Name, opt => opt.MapFrom(t => t.Name));
            CreateMap<RoleDTO, Role>()
                .ForMember(t => t.UserRoles, opt => opt.Ignore());

        }
    }
}