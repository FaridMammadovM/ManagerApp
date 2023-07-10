using AutoMapper;
using ITS.PMT.Domain.Dto.ParametricDtos;
using ITS.PMT.Infrastructure.Repositories.ParametricRepository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Queries.Project.GetProjectNames
{
    public sealed class GetProjectNamesQueryHandler : IRequestHandler<GetProjectNamesQuery, List<GetProjectNamesDto>>
    {
        private readonly IMapper _mapper;
        private readonly IParametricRepository _parametricRepository;
        public GetProjectNamesQueryHandler(IMapper mapper, IParametricRepository parametricRepository)
        {
            _parametricRepository = parametricRepository;
            _mapper = mapper;
        }

        public async Task<List<GetProjectNamesDto>> Handle(GetProjectNamesQuery request, CancellationToken cancellationToken)
        {
            var result = await _parametricRepository.GetProjectNames();
            return result;
        }
    }
}
