using ITS.PMT.Domain.Dto.TaskDtos;
using MediatR;

namespace ITS.PMT.Api.Application.Commands.Task.UpdateTask
{
    public class UpdateTaskCommand : UpdateTaskDto, IRequest<int>
    {
    }
}
