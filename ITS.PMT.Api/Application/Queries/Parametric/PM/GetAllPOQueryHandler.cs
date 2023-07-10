using AutoMapper;
using ITS.PMT.Domain.Dto.ParametricDtos;
using ITS.PMT.Infrastructure.Repositories.ParametricRepository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Queries.Parametric.PM
{
    public sealed class GetAllPOQueryHandler : IRequestHandler<GetAllPOQuery, List<GetAllPODto>>
    {

        private readonly IParametricRepository _employeeRepository;
        private readonly IMapper _mapper;
        public GetAllPOQueryHandler(IParametricRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllPODto>> Handle(GetAllPOQuery request, CancellationToken cancellationToken)
        {
            var result = await _employeeRepository.GetAllPO();

            return result;

        }
    }
}
