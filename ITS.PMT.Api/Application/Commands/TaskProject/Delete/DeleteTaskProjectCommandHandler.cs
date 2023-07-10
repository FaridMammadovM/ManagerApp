using FluentValidation;
using ITS.PMT.Infrastructure.Repositories.TaskProjectRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Commands.TaskProject.Delete
{
    public sealed class DeleteTaskProjectCommandHandler : IRequestHandler<DeleteTaskProjectCommand, int>
    {
        private readonly ITaskProjectRepository _taskRepository;
        private readonly IValidator<DeleteTaskProjectCommand> _validator;

        public DeleteTaskProjectCommandHandler(ITaskProjectRepository taskRepository, IValidator<DeleteTaskProjectCommand> validator)
        {
            _taskRepository = taskRepository;
            _validator = validator;
        }


        public async Task<int> Handle(DeleteTaskProjectCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var result = await _taskRepository.DeleteTask(request.Id);
            return result;
        }
    }
}