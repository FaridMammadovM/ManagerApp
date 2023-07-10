using MediatR;

namespace ITS.PMT.Api.Application.Commands.Team
{
    public class CreateTeamCommand : IRequest<int>
    {
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }
        public int RoleId { get; set; }

    }
}
