using AutoMapper;
using ITS.PMT.Domain.Dto.ParametricDtos;
using ITS.PMT.Infrastructure.Repositories.ParametricRepository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Queries.Parametric.Priority
{
    public sealed class GetAllPriorityQueryHandler : IRequestHandler<GetAllPriorityQuery, List<GetAllPriorityDto>>
    {

        private readonly IParametricRepository _employeeRepository;
        private readonly IMapper _mapper;
        public GetAllPriorityQueryHandler(IParametricRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllPriorityDto>> Handle(GetAllPriorityQuery request, CancellationToken cancellationToken)
        {
            var result = await _employeeRepository.GetAllPriority();

            return _mapper.Map<List<GetAllPriorityDto>>(result);

        }
    }
}
