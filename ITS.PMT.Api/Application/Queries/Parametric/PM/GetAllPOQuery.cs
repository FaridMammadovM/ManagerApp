using ITS.PMT.Domain.Dto.ParametricDtos;
using MediatR;
using System.Collections.Generic;

namespace ITS.PMT.Api.Application.Queries.Parametric.PM
{
    public class GetAllPOQuery : IRequest<List<GetAllPODto>>
    {
    }
}
