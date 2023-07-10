using ITS.PMT.Domain.Dto.TaskDtos;
using MediatR;
using System.Collections.Generic;

namespace ITS.PMT.Api.Application.Queries.Team.GetTaskById
{
    public class GetTaskByIdQuery : IRequest<List<TaskForGetByIdDto>>
    {
        public int Id { get; set; }
    }
}
