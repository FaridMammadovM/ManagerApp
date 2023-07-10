using AutoMapper;
using ITS.PMT.Api.Application.Commands.TaskProject.ChangeStatus;
using ITS.PMT.Api.Application.Commands.TaskProject.Create;
using ITS.PMT.Api.Application.Commands.TaskProject.Update;
using ITS.PMT.Domain.Dto.ProjectDtos;
using ITS.PMT.Domain.Dto.TaskProjectDtos;
using ITS.PMT.Domain.Models.TaskProject;

namespace ITS.PMT.Api.AutoMapper.MappingProfile
{
    public class TaskProjectMappingProfile : Profile
    {
        public TaskProjectMappingProfile()
        {
            CreateMap<CreateTaskProjectCommand, TaskProjectModel>();
            CreateMap<UpdateTaskProjectCommand, TaskProjectModel>();
            CreateMap<TaskProjectByIdDto, TaskProjectModel>().ReverseMap();
            CreateMap<ChangeStatusTaskProjectCommand, TaskProjectModel>().ReverseMap();
            CreateMap<GetAllProjectTaskNumberDto, TaskProjectModel>().ReverseMap();


        }
    }
}
