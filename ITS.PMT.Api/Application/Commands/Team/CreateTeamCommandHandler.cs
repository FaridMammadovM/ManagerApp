using AutoMapper;
using FluentValidation;
using ITS.PMT.Domain.Models.Team;
using ITS.PMT.Infrastructure.Repositories.TeamRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Commands.Team
{
    public sealed class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommand, int>
    {

        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateTeamCommand> _validator;


        public CreateTeamCommandHandler(ITeamRepository teamRepository, IMapper mapper, IValidator<CreateTeamCommand> validator)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<int> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var team = await _teamRepository.CreateTeam(_mapper.Map<TeamModel>(request));
            return team;

        }
    }
}
