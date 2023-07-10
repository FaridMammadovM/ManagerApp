using ITS.PMT.Domain.Dto.ProjectDtos;
using MediatR;
using System.Collections.Generic;

namespace ITS.PMT.Api.Application.Queries.Project.GetAllProjectName
{
    public class GetAllProjectNameQuery : IRequest<List<GetAllProjectNameDto>>
    {
    }
}
