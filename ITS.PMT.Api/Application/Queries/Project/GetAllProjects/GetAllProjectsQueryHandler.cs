using ITS.PMT.Domain.Dto.ProjectDtos;
using ITS.PMT.Infrastructure.Repositories.ProjectRepository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Queries.Project.GetAllProjects
{
    public sealed class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, List<GetAllProjectsDto>>
    {

        private readonly IProjectRepository _projectRepository;
        public GetAllProjectsQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<List<GetAllProjectsDto>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            var result = await _projectRepository.GetAllProjects();
            return result;
        }
    }
}
