using ITS.PMT.Domain.Dto.RoleType;
using MediatR;
using System.Collections.Generic;

namespace ITS.PMT.Api.Application.Queries.RoleType.GetAll
{
    public class GetAllNameRoleTypeQuery : IRequest<List<RoleTypeAllReturnDto>>
    {
    }
}
