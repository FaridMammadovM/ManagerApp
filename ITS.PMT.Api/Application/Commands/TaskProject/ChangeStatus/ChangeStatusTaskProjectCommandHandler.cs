using AutoMapper;
using FluentValidation;
using ITS.PMT.Domain.Models.TaskProject;
using ITS.PMT.Infrastructure.Repositories.TaskProjectRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Commands.TaskProject.ChangeStatus
{
    public sealed class ChangeStatusTaskProjectCommandHandler : IRequestHandler<ChangeStatusTaskProjectCommand, int>
    {
        private readonly ITaskProjectRepository _taskRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<ChangeStatusTaskProjectCommand> _validator;

        public ChangeStatusTaskProjectCommandHandler(ITaskProjectRepository taskRepository, IMapper mapper, IValidator<ChangeStatusTaskProjectCommand> validator)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
            _validator = validator;

        }
        public async Task<int> Handle(ChangeStatusTaskProjectCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var result = await _taskRepository.ChangeStatusTaskProject(_mapper.Map<TaskProjectModel>(request));
            return result;
        }
    }
}
