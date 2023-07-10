using AutoMapper;
using FluentValidation;
using ITS.PMT.Domain.Dto.TeamDtos;
using ITS.PMT.Infrastructure.Repositories.TeamRepository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Queries.Team.GetTeam
{
    public sealed class GetTeamForComboQueryHandler : IRequestHandler<GetTeamForComboQuery, IEnumerable<GetTeamForComboDto>>
    {
        private readonly IMapper _mapper;
        private readonly ITeamRepository _teamRepository;
        private readonly IValidator<GetTeamForComboQuery> _validator;

        public GetTeamForComboQueryHandler(IMapper mapper, ITeamRepository teamRepository, IValidator<GetTeamForComboQuery> validator)
        {
            _mapper = mapper;
            _teamRepository = teamRepository;
            _validator = validator;
        }

        public async Task<IEnumerable<GetTeamForComboDto>> Handle(GetTeamForComboQuery request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var res = await _teamRepository.GetTeamForCombo(request.Projectid);
            return res;
        }
    }
}
