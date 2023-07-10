using AutoMapper;
using FluentValidation;
using ITS.PMT.Domain.Models.Task;
using ITS.PMT.Infrastructure.Repositories.TaskRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Commands.Task.UpdateTask
{
    public sealed class UpdateTaskCommandHandle : IRequestHandler<UpdateTaskCommand, int>
    {
        private readonly ITaskRepository taskRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateTaskCommand> _validator;
        public UpdateTaskCommandHandle(ITaskRepository taskRepository, IMapper mapper, IValidator<UpdateTaskCommand> validator)
        {
            this.taskRepository = taskRepository;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task<int> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var res = taskRepository.UpdateTask(_mapper.Map<TaskModel>(request));
            return await res;
        }
    }
}
