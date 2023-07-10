using AutoMapper;
using FluentValidation;
using ITS.PMT.Domain.Models.ProjectDetails;
using ITS.PMT.Infrastructure.Repositories.ProjectRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Commands.Project.UpdateProjectPriority
{
    public sealed class UpdateProjectPriorityCommandHandler : IRequestHandler<UpdateProjectPriorityCommand, int>
    {
        private readonly IProjectRepository projectRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateProjectPriorityCommand> _validator;
        public UpdateProjectPriorityCommandHandler(IProjectRepository projectRepository, IMapper mapper, IValidator<UpdateProjectPriorityCommand> validator)
        {
            this.projectRepository = projectRepository;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task<int> Handle(UpdateProjectPriorityCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var result = await projectRepository.UpdateProjectPriority(_mapper.Map<ProjectDetailsModel>(request));
            return result;
        }
    }
}
