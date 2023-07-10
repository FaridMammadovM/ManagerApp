using MediatR;

namespace ITS.PMT.Api.Application.Commands.RoleType.Delete
{
    public class DeleteRoleTypeCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
