using AutoMapper;
using ITS.PMT.Domain.Dto.StageDtos;
using ITS.PMT.Infrastructure.Repositories.ParametricRepository;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Queries.Stage
{
    public sealed class GetStageQueryHandler : IRequestHandler<GetStageQuery, List<GetStageDto>>
    {
        private readonly IMapper _mapper;
        private readonly IParametricRepository _parametricRepository;
        public GetStageQueryHandler(IMapper mapper, IParametricRepository parametricRepository)
        {
            _parametricRepository = parametricRepository;
            _mapper = mapper;
        }

        public async Task<List<GetStageDto>> Handle(GetStageQuery request, CancellationToken cancellationToken)
        {
            var result = await _parametricRepository.GetAllStages();
            return _mapper.Map<List<GetStageDto>>(result.ToList());
        }
    }
}
