using AutoMapper;
using ITS.PMT.Api.Application.Commands.Auth.UserPermission.AddUserPermission;
using ITS.PMT.Api.Application.Commands.Auth.UserPermission.DeleteUserPermission;
using ITS.PMT.Domain.Dto.ParametricDtos;
using ITS.PMT.Domain.Dto.UserPermissionDtos;
using ITS.PMT.Domain.Models.Employee;

namespace ITS.PMT.Api.AutoMapper.MappingProfile
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<EmployeeModel, GetAllEmployeeDto>();
            CreateMap<UserPermissionDto, AddUserPermissionCommand>().ReverseMap();
            CreateMap<UserDeletePermissionDto, DeleteUserPermissionCommand>().ReverseMap();
        }
    }
}
