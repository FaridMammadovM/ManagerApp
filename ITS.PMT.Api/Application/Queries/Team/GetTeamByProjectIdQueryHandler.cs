using FluentValidation;
using ITS.PMT.Domain.Dto.TeamDtos;
using ITS.PMT.Infrastructure.Repositories.TeamRepository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Queries.Team
{
    public sealed class GetTeamByProjectIdQueryHandler : IRequestHandler<GetTeamByProjectIdQuery, List<GetTeamByProjectIdDto>>
    {
        //private readonly IMapper _mapper;
        private readonly IValidator<GetTeamByProjectIdQuery> _validator;
        private readonly ITeamRepository _teamRepository;
        public GetTeamByProjectIdQueryHandler(ITeamRepository teamRepository, IValidator<GetTeamByProjectIdQuery> validator)
        {
            _teamRepository = teamRepository;
            _validator = validator;
            //_mapper = mapper;
        }

        public async Task<List<GetTeamByProjectIdDto>> Handle(GetTeamByProjectIdQuery request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var result = await _teamRepository.GetTeambyProjectId(request.ProjectId);
            return result;
            //throw new System.NotImplementedException();
        }
    }
}
