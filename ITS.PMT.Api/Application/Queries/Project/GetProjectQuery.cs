using ITS.PMT.Domain.Dto.ProjectDtos;
using MediatR;
using System.Collections.Generic;

namespace ITS.PMT.Api.Application.Queries.Project
{
    public class GetProjectQuery : IRequest<List<GetProjectDto>>
    {
    }
}
