using ITS.PMT.Domain.Dto.TaskDtos;
using MediatR;

namespace ITS.PMT.Api.Application.Commands.Task.CreateTask
{
    public class CreateTaskCommand : IRequest<int>
    {
        public CreateTaskDto taskForCreationDto { get; set; }
    }
}
