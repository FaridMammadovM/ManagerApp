using MediatR;

namespace ITS.PMT.Api.Application.Commands.RoleType.Create
{
    public class CreateRoleTypeCommand : IRequest<int>
    {
        public string Name { get; set; }
        public int UserId { get; set; }
    }
}
