using ITS.PMT.Domain.Dto.RoleTypeUserDtos;
using MediatR;

namespace ITS.PMT.Api.Application.Queries.RoleType.GetAllGroupUserById
{
    public class GetAllGroupUserByIdQuery : IRequest<RoleTypeUserGetAllDto>
    {
        public int Id { get; set; }
    }
}

