using AutoMapper;
using ITS.PMT.Api.Application.Commands.Project.CreateProject;
using ITS.PMT.Api.Application.Commands.Project.UpdateProjectPriority;
using ITS.PMT.Api.Application.Queries.Project.GetAllManagment;
using ITS.PMT.Domain.Dto.ParametricDtos;
using ITS.PMT.Domain.Dto.ProjectDetailsDtos;
using ITS.PMT.Domain.Dto.ProjectDtos;
using ITS.PMT.Domain.Models.Project;
using ITS.PMT.Domain.Models.ProjectDetails;

namespace ITS.PMT.Api.AutoMapper.MappingProfile
{
    public class ProjectMappingProfile : Profile
    {
        public ProjectMappingProfile()
        {
            CreateMap<CreateProjectCommand, ProjectModel>();
            CreateMap<ProjectForCreationDto, ProjectModel>();
            CreateMap<ProjectModel, GetProjectByIdDto>();
            CreateMap<ProjectModel, GetProjectDto>();
            CreateMap<ProjectForUpdateDto, ProjectModel>();
            CreateMap<GetProjectNamesDto, ProjectModel>().ReverseMap();
            CreateMap<InsertAddtionallInfoDto, ProjectDetailsModel>();
            CreateMap<UpdateAdditionallInfoDto, ProjectDetailsModel>();
            CreateMap<ProjectDetailsModel, GetAdditionallInfoDto>();
            CreateMap<ManagmentRequestDto, GetAllManagmentQuery>().ReverseMap();
            CreateMap<ProjectDetailsModel, UpdateProjectPriorityCommand>().ReverseMap();




            //CreateMap<List<GetAllProjectNumberDto>, GetAllProjectTaskNumberDto>().ReverseMap();

            //CreateMap<GetAllProjectTaskNumberDto, GetAllProjectNumberDto>()
            //.ForMember(dest => dest.GetAllProject, opt => opt.MapFrom(src => new List<GetAllProjectTaskNumberDto>() { src }))
            //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProjectId));

            //CreateMap<GetAllProjectNumberDto, GetAllProjectTaskNumberDto>()
            //    .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.Id));



        }
    }
}
