using ITS.PMT.Domain.Dto.ParametricDtos;
using MediatR;
using System.Collections.Generic;

namespace ITS.PMT.Api.Application.Queries.Parametric.Priority
{
    public class GetAllPriorityQuery : IRequest<List<GetAllPriorityDto>>
    {
    }
}
