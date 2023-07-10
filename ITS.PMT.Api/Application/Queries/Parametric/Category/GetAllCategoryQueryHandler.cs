using AutoMapper;
using ITS.PMT.Domain.Dto.ParametricDtos;
using ITS.PMT.Infrastructure.Repositories.ParametricRepository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Queries.Parametric.Category
{
    public sealed class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, List<GetAllCategoryDto>>
    {

        private readonly IParametricRepository _parametricRepository;
        private readonly IMapper _mapper;
        public GetAllCategoryQueryHandler(IParametricRepository parametricRepository, IMapper mapper)
        {
            _parametricRepository = parametricRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllCategoryDto>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var result = await _parametricRepository.GetAllCategory();

            return _mapper.Map<List<GetAllCategoryDto>>(result);

        }
    }
}
