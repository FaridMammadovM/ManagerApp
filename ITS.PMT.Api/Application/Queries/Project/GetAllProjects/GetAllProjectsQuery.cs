using ITS.PMT.Domain.Dto.ProjectDtos;
using MediatR;
using System.Collections.Generic;

namespace ITS.PMT.Api.Application.Queries.Project.GetAllProjects
{
    public class GetAllProjectsQuery : IRequest<List<GetAllProjectsDto>>
    {
    }
}
