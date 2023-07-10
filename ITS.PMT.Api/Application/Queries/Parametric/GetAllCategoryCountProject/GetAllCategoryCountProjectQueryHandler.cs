using AutoMapper;
using ITS.PMT.Domain.Dto.ParametricDtos;
using ITS.PMT.Infrastructure.Repositories.ParametricRepository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Queries.Parametric.GetAllCategoryCountProject
{
    public sealed class GetAllCategoryCountProjectQueryHandler : IRequestHandler<GetAllCategoryCountProjectQuery, List<GetAllCategoryCountProjectDto>>
    {

        private readonly IParametricRepository _parametricRepository;
        private readonly IMapper _mapper;
        public GetAllCategoryCountProjectQueryHandler(IParametricRepository parametricRepository, IMapper mapper)
        {
            _parametricRepository = parametricRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllCategoryCountProjectDto>> Handle(GetAllCategoryCountProjectQuery request, CancellationToken cancellationToken)
        {
            var result = await _parametricRepository.GetAllCategoryCountProject();
            return result;

        }
    }
}

