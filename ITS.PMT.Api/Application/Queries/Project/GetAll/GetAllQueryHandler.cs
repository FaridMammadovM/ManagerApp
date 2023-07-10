using AutoMapper;
using ITS.PMT.Domain.Dto.ProjectDtos;
using ITS.PMT.Infrastructure.Repositories.ProjectRepository;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Queries.Project.GetAll
{
    public sealed class GetAllQueryHandler : IRequestHandler<GetAllQuery, List<GetAllProjectNumberDto>>
    {

        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public GetAllQueryHandler(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllProjectNumberDto>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {

            var resultTask = await _projectRepository.GetAllTaskByNumber();
            var resultPoId = await _projectRepository.GetAllPoId();
            var resultProject = await _projectRepository.GetAllProjectByNumber();

            resultProject.ForEach(x => x.PoId = resultPoId.Where(y => y.Id == x.Id).Select(y => y.Poid).ToArray());
            resultProject.ForEach(x => x.GetAllProject = resultTask.Where(y => y.ProjectId == x.Id).ToList());


            return resultProject;
        }
    }
}




