using ITS.PMT.Domain.Dto.ParametricDtos;
using MediatR;
using System.Collections.Generic;

namespace ITS.PMT.Api.Application.Queries.Parametric.GetAllCategoryCountProject
{
    public class GetAllCategoryCountProjectQuery : IRequest<List<GetAllCategoryCountProjectDto>>
    {
    }
}
