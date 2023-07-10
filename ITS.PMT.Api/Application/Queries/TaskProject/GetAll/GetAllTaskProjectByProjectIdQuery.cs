using ITS.PMT.Domain.Dto.TaskProjectDtos;
using MediatR;
using System.Collections.Generic;

namespace ITS.PMT.Api.Application.Queries.TaskProject.GetAll
{
    public class GetAllTaskProjectByProjectIdQuery : IRequest<List<GetAllTaskProjectByProjectIdDto>>
    {
        public int ProjectId { get; set; }
    }
}
