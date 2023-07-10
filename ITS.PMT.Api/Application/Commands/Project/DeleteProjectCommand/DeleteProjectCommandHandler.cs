using FluentValidation;
using ITS.PMT.Infrastructure.Repositories.ProjectRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Commands.Project.DeleteProjectCommand
{
    public sealed class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, int>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IValidator<DeleteProjectCommand> _validator;

        public DeleteProjectCommandHandler(IProjectRepository projectRepository, IValidator<DeleteProjectCommand> validator)
        {
            _projectRepository = projectRepository;
            _validator = validator;
        }


        public async Task<int> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var result = await _projectRepository.DeleteProject(request.Id);
            return result;
        }
    }
}
