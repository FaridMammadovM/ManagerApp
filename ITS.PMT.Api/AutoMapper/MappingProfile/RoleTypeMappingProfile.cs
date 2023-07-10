using AutoMapper;
using ITS.PMT.Api.Application.Commands.Auth.AddGroupUser;
using ITS.PMT.Api.Application.Commands.Auth.DeleteGroupUser;
using ITS.PMT.Api.Application.Commands.Auth.GroupPermission.AddRolePermission;
using ITS.PMT.Api.Application.Commands.Auth.GroupPermission.DeleteGroupPermission;
using ITS.PMT.Api.Application.Commands.RoleType.Create;
using ITS.PMT.Api.Application.Commands.RoleType.Update;
using ITS.PMT.Domain.Dto.RoleType;
using ITS.PMT.Domain.Dto.RoleTypePermissionDtos;
using ITS.PMT.Domain.Dto.RoleTypeUserDtos;
using ITS.PMT.Domain.Models.RoleType;

namespace ITS.PMT.Api.AutoMapper.MappingProfile
{
    public class RoleTypeMappingProfile : Profile
    {
        public RoleTypeMappingProfile()
        {
            CreateMap<RoleTypeModel, CreateRoleTypeCommand>().ReverseMap();
            CreateMap<RoleTypeModel, UpdateRoleTypeCommand>().ReverseMap();
            CreateMap<RoleTypeModel, RoleTypeGetByIdDto>().ReverseMap();

            //Add Permission

            CreateMap<RoleTypeAddPermissionDto, AddGroupPermissionCommand>().ReverseMap();
            CreateMap<RoleTypeUserDto, AddGroupUserCommand>().ReverseMap();

            CreateMap<RoleTypeDeletePermissionDto, DeleteGroupPermissionCommand>().ReverseMap();
            CreateMap<RoleTypeDeleteUserDto, DeleteGroupUserCommand>().ReverseMap();

        }
    }
}
