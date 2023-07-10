using AutoMapper;
using ITS.PMT.Domain.Dto.ProjectDtos;
using ITS.PMT.Infrastructure.Repositories.ProjectRepository;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Queries.Project.GetAllManagment
{
    public sealed class GetAllManagmentQueryHandler : IRequestHandler<GetAllManagmentQuery, List<GetAllProjectManagmentDto>>
    {
        private readonly IMapper _mapper;
        private readonly IProjectRepository _projectRepository;
        public GetAllManagmentQueryHandler(IMapper mapper, IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllProjectManagmentDto>> Handle(GetAllManagmentQuery request, CancellationToken cancellationToken)
        {
            ManagmentRequestDto managment = _mapper.Map<ManagmentRequestDto>(request);
            var resultTask = await _projectRepository.GetAllTaskByNumber();

            var resultProject = await _projectRepository.GetAllProjectByPO(managment);

            var result = await _projectRepository.GetAllPO(managment);

            resultProject.ForEach(x => x.GetAllProject = resultTask.Where(y => y.ProjectId == x.Id).ToList());

            result.ForEach(x => x.GetAll = resultProject.Where(y => y.Po == x.Id).ToList());

            for (int i = result.Count - 1; i >= 0; i--)
            {
                if (result[i].GetAll.Count == 0)
                {
                    result.RemoveAt(i);
                }
            }

            return result;
        }
    }
}
