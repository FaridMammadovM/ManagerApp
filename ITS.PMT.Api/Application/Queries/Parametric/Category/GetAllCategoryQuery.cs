using ITS.PMT.Domain.Dto.ParametricDtos;
using MediatR;
using System.Collections.Generic;

namespace ITS.PMT.Api.Application.Queries.Parametric.Category
{
    public class GetAllCategoryQuery : IRequest<List<GetAllCategoryDto>>
    {
    }
}
