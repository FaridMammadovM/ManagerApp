using MediatR;

namespace ITS.PMT.Api.Application.Commands.RoleType.Update
{
    public class UpdateRoleTypeCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
    }
}
