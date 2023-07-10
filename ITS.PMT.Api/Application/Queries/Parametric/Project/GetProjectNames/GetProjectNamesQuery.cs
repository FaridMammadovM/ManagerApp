using ITS.PMT.Domain.Dto.ParametricDtos;
using MediatR;
using System.Collections.Generic;

namespace ITS.PMT.Api.Application.Queries.Project.GetProjectNames
{
    public class GetProjectNamesQuery : IRequest<List<GetProjectNamesDto>>
    {
    }
}
