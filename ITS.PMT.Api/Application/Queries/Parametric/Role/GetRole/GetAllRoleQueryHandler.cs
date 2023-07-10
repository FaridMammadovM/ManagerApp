using AutoMapper;
using ITS.PMT.Domain.Dto.ParametricDtos;
using ITS.PMT.Infrastructure.Repositories.ParametricRepository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Queries.Parametric.Role.GetRole
{
    public sealed class GetAllRoleQueryHandler : IRequestHandler<GetAllRoleQuery, List<GetAllRoleDto>>
    {
        private readonly IParametricRepository _roleRepository;
        private readonly IMapper _mapper;
        public GetAllRoleQueryHandler(IParametricRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }
        public async Task<List<GetAllRoleDto>> Handle(GetAllRoleQuery request, CancellationToken cancellationToken)
        {
            var result = await _roleRepository.GetAllRole();
            return _mapper.Map<List<GetAllRoleDto>>(result);
        }
    }
}
