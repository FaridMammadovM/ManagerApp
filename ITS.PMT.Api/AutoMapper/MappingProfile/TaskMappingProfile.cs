using AutoMapper;
using ITS.PMT.Api.Application.Commands.Task.CreateTask;
using ITS.PMT.Domain.Dto.TaskDtos;
using ITS.PMT.Domain.Models.Task;

namespace ITS.PMT.Api.AutoMapper.MappingProfile
{
    public class TaskMappingProfile : Profile
    {
        public TaskMappingProfile()
        {
            CreateMap<CreateTaskCommand, TaskModel>();
            CreateMap<UpdateTaskDto, TaskModel>();
            CreateMap<CreateTaskDto, TaskModel>();
            CreateMap<TaskModel, TaskForGetByIdDto>();
        }
    }
}
