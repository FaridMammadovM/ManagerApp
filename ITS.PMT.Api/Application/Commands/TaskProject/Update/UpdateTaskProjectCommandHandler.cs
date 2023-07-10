using AutoMapper;
using FluentValidation;
using ITS.PMT.Domain.Models.TaskProject;
using ITS.PMT.Infrastructure.Repositories.TaskProjectRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Commands.TaskProject.Update
{
    public sealed class UpdateTaskProjectCommandHandler : IRequestHandler<UpdateTaskProjectCommand, int>
    {
        private readonly ITaskProjectRepository _taskRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateTaskProjectCommand> _validator;

        public UpdateTaskProjectCommandHandler(ITaskProjectRepository taskRepository, IMapper mapper, IValidator<UpdateTaskProjectCommand> validator)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
            _validator = validator;

        }
        public async Task<int> Handle(UpdateTaskProjectCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var result = await _taskRepository.UpdateTaskProject(_mapper.Map<TaskProjectModel>(request));
            return result;
        }
    }
}
