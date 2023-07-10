using MediatR;

namespace ITS.PMT.Api.Application.Commands.Team.DeleteTeam
{
    public class DeleteTeamCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
