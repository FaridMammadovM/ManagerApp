using ITS.PMT.Domain.Dto.RoleType;
using MediatR;

namespace ITS.PMT.Api.Application.Queries.RoleType.GetById
{
    public class GetByIdRoleTypeQuery : IRequest<RoleTypeGetByIdDto>
    {
        public int Id { get; set; }
    }
}
