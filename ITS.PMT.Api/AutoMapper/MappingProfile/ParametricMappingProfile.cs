using AutoMapper;
using ITS.PMT.Domain.Dto.ParametricDtos;
using ITS.PMT.Domain.Models.Category;
using ITS.PMT.Domain.Models.Employee;
using ITS.PMT.Domain.Models.MeetingTypes;
using ITS.PMT.Domain.Models.Priority;
using ITS.PMT.Domain.Models.Role;
using ITS.PMT.Domain.Models.Status;
using System.Collections.Generic;

namespace ITS.PMT.Api.AutoMapper.MappingProfile
{
    public class ParametricMappingProfile : Profile
    {
        public ParametricMappingProfile()
        {
            CreateMap<RoleModel, GetAllRoleDto>();
            CreateMap<StatusModel, GetAllStatusDto>();

            CreateMap<List<EmployeeModel>, GetAllEmployeeDto>();
            CreateMap<MeetingTypes, GetMeetingTypesDto>();

            CreateMap<CategoryModel, GetAllCategoryDto>();

            CreateMap<PriorityModel, GetAllPriorityDto>();
        }
    }
}
