using ITS.PMT.Domain.Dto.RoleType;
using MediatR;

namespace ITS.PMT.Api.Application.Queries.RoleType.GetAllGroupPermissionById
{
    public class GetAllGroupPermissionByIdQuery : IRequest<RoleTypePermissionAllReturnDto>
    {
        public int Id { get; set; }
    }
}
