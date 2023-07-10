using AutoMapper;
using FluentValidation;
using ITS.PMT.Domain.Models.Project;
using ITS.PMT.Infrastructure.Repositories.DeadlineOutInfoRepository;
using ITS.PMT.Infrastructure.Repositories.ProjectRepository;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Commands.Project.CreateProject
{
    public sealed class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IValidator<CreateProjectCommand> _validator;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IDeadlineOutInfoRepository _deadlineOutInfoRepository;
        public CreateProjectCommandHandler(IDeadlineOutInfoRepository deadlineOutInfoRepository, IProjectRepository projectRepository, IValidator<CreateProjectCommand> validator, IMapper mapper, IConfiguration configuration)
        {
            _projectRepository = projectRepository;
            _validator = validator;
            _mapper = mapper;
            _configuration = configuration;
            _deadlineOutInfoRepository = deadlineOutInfoRepository;
        }
        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var result = await _projectRepository.CreateProject(_mapper.Map<ProjectModel>(request.projectForCreationDto));
            _deadlineOutInfoRepository.CreateDeadlineOutInfo(result);
            return result;
        }

    }
}
