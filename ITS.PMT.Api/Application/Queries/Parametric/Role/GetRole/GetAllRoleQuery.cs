using ITS.PMT.Domain.Dto.ParametricDtos;
using MediatR;
using System.Collections.Generic;

namespace ITS.PMT.Api.Application.Queries.Parametric.Role.GetRole
{
    public class GetAllRoleQuery : IRequest<List<GetAllRoleDto>>
    {
    }
}
