using AutoMapper;
using FluentValidation;
using ITS.PMT.Domain.Dto.TaskDtos;
using ITS.PMT.Infrastructure.Repositories.TaskRepository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Queries.Task.GetTaskByProjectId
{
    public sealed class GetAllTaskByProjectIdQueryHandler : IRequestHandler<GetAllTaskByProjectIdQuery, List<GetAllTaskByProjectIdDto>>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IValidator<GetAllTaskByProjectIdQuery> _validator;
        public GetAllTaskByProjectIdQueryHandler(ITaskRepository taskRepository, IMapper mapper, IValidator<GetAllTaskByProjectIdQuery> validator)
        {
            _taskRepository = taskRepository;
            _validator = validator;
        }

        async Task<List<GetAllTaskByProjectIdDto>> IRequestHandler<GetAllTaskByProjectIdQuery, List<GetAllTaskByProjectIdDto>>.Handle(GetAllTaskByProjectIdQuery request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var result = await _taskRepository.GetAllTaskByProjectId(request.ProjectId);
            return result;
        }
    }
}
