using FluentValidation;
using ITS.PMT.Infrastructure.Repositories.TeamRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Commands.Team.DeleteTeam
{
    public sealed class DeleteTeamCommandHandler : IRequestHandler<DeleteTeamCommand, int>
    {
        private readonly ITeamRepository teamRepository;
        private readonly IValidator<DeleteTeamCommand> _validator;
        public DeleteTeamCommandHandler(ITeamRepository teamRepository, IValidator<DeleteTeamCommand> validator)
        {
            this.teamRepository = teamRepository;
            _validator = validator;
        }

        public async Task<int> Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var result = await teamRepository.DeleteTeam(request.Id);
            return result;
        }
    }
}
