using ITS.PMT.Domain.Dto.TaskDtos;
using MediatR;
using System.Collections.Generic;

namespace ITS.PMT.Api.Application.Queries.Task.GetTaskByProjectId
{
    public class GetAllTaskByProjectIdQuery : IRequest<List<GetAllTaskByProjectIdDto>>
    {
        public int ProjectId { get; set; }
    }
}
