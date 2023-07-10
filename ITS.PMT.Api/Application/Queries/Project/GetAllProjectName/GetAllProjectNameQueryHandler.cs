using AutoMapper;
using ITS.PMT.Domain.Dto.ProjectDtos;
using ITS.PMT.Infrastructure.Repositories.ProjectRepository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Queries.Project.GetAllProjectName
{
    public sealed class GetAllProjectNameQueryHandler : IRequestHandler<GetAllProjectNameQuery, List<GetAllProjectNameDto>>
    {

        private readonly IProjectRepository _employeeRepository;
        private readonly IMapper _mapper;
        public GetAllProjectNameQueryHandler(IProjectRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllProjectNameDto>> Handle(GetAllProjectNameQuery request, CancellationToken cancellationToken)
        {
            var result = await _employeeRepository.GetAllProjectName();

            return result;

        }
    }
}
