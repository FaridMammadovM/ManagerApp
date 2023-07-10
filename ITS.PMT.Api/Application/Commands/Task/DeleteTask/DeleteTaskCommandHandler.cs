using FluentValidation;
using ITS.PMT.Infrastructure.Repositories.TaskRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Commands.Task.DeleteTask
{
    public sealed class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, int>
    {
        private readonly ITaskRepository taskRepository;
        private readonly IValidator<DeleteTaskCommand> _validator;
        public DeleteTaskCommandHandler(ITaskRepository taskRepository, IValidator<DeleteTaskCommand> validator)
        {
            this.taskRepository = taskRepository;
            _validator = validator;
        }

        public async Task<int> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var result = await taskRepository.DeleteTask(request.Id);
            return result;
        }
    }
}
