using AutoMapper;
using ITS.PMT.Domain.Dto.ProjectDtos;
using ITS.PMT.Infrastructure.Repositories.ProjectRepository;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Queries.Project
{
    public sealed class GetProjectQueryHandler : IRequestHandler<GetProjectQuery, List<GetProjectDto>>
    {
        private readonly IMapper _mapper;
        private readonly IProjectRepository _projectRepository;
        public GetProjectQueryHandler(IMapper mapper, IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<List<GetProjectDto>> Handle(GetProjectQuery request, CancellationToken cancellationToken)
        {
            var result = await _projectRepository.GetAllProject();
            return _mapper.Map<List<GetProjectDto>>(result.ToList());
        }
    }
}
