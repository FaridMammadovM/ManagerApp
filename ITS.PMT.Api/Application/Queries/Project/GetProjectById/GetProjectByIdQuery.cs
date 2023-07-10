using ITS.PMT.Domain.Dto.ProjectDtos;
using MediatR;
using System.Collections.Generic;

namespace ITS.PMT.Api.Application.Queries.Project.GetProjectById
{
    public class GetProjectByIdQuery : IRequest<List<GetProjectByIdDto>>
    {
        public int Id { get; set; }
    }
}
