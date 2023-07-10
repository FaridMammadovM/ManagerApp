using AutoMapper;
using FluentValidation;
using ITS.PMT.Domain.Models.Task;
using ITS.PMT.Infrastructure.Repositories.TaskRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Commands.Task.CreateTask
{
    public sealed class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, int>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateTaskCommand> _validator;

        public CreateTaskCommandHandler(ITaskRepository taskRepository, IMapper mapper, IValidator<CreateTaskCommand> validator)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
            _validator = validator;

        }
        public async Task<int> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var result = await _taskRepository.CreateTask(_mapper.Map<TaskModel>(request.taskForCreationDto));
            return result;
        }
    }
}
