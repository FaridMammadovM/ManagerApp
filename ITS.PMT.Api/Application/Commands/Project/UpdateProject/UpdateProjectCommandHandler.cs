using AutoMapper;
using FluentValidation;
using ITS.PMT.Domain.Models.Project;
using ITS.PMT.Infrastructure.Repositories.ProjectRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Commands.Project.UpdateProject
{
    public sealed class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, int>
    {
        private readonly IProjectRepository projectRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateProjectCommand> _validator;
        public UpdateProjectCommandHandler(IProjectRepository projectRepository, IMapper mapper, IValidator<UpdateProjectCommand> validator)
        {
            this.projectRepository = projectRepository;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task<int> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var result = await projectRepository.UpdateProject(_mapper.Map<ProjectModel>(request.ProjectForUpdateDto));
            return result;
        }
    }
}
