using AutoMapper;
using ITS.PMT.Domain.Dto.ParametricDtos;
using ITS.PMT.Infrastructure.Repositories.ParametricRepository;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Queries.Parametric.Status
{
    public sealed class GetStatusQueryHandler : IRequestHandler<GetStatusQuery, List<GetAllStatusDto>>
    {
        private readonly IMapper _mapper;
        private readonly IParametricRepository _parametricRepository;
        public GetStatusQueryHandler(IMapper mapper, IParametricRepository parametricRepository)
        {
            _parametricRepository = parametricRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllStatusDto>> Handle(GetStatusQuery request, CancellationToken cancellationToken)
        {
            var result = await _parametricRepository.GetAllStatus();
            return _mapper.Map<List<GetAllStatusDto>>(result.ToList());
        }
    }
}
