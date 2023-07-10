using AutoMapper;
using FluentValidation;
using ITS.PMT.Domain.Models.TaskProject;
using ITS.PMT.Infrastructure.Repositories.TaskProjectRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Commands.TaskProject.Create
{
    public sealed class CreateTaskProjectCommandHandler : IRequestHandler<CreateTaskProjectCommand, int>
    {
        private readonly ITaskProjectRepository _taskRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateTaskProjectCommand> _validator;

        public CreateTaskProjectCommandHandler(ITaskProjectRepository taskRepository, IMapper mapper, IValidator<CreateTaskProjectCommand> validator)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
            _validator = validator;

        }
        public async Task<int> Handle(CreateTaskProjectCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var result = await _taskRepository.CreateTaskProject(_mapper.Map<TaskProjectModel>(request));
            return result;
        }
    }
}
