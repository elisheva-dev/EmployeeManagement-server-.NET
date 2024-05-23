using AutoMapper;
using Solid.API.Models;
using Solid.core.Enentities;

namespace Solid.API
{
    public class PostModelsMappingProfile:Profile
    {
        public PostModelsMappingProfile()
        {
            CreateMap<EmployeePostModel, Employee>().ReverseMap();
            CreateMap<EmployeeRolesPostModel, EmployeeRoles>().ReverseMap();
            CreateMap<RolePostModel, Role>().ReverseMap();
        }
    }
}
