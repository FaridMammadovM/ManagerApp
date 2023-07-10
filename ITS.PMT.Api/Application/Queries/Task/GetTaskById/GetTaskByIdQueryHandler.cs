using AutoMapper;
using FluentValidation;
using ITS.PMT.Domain.Dto.TaskDtos;
using ITS.PMT.Infrastructure.Repositories.TaskRepository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Queries.Team.GetTaskById
{
    public sealed class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, List<TaskForGetByIdDto>>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<GetTaskByIdQuery> _validator;
        public GetTaskByIdQueryHandler(ITaskRepository taskRepository, IMapper mapper, IValidator<GetTaskByIdQuery> validator)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<List<TaskForGetByIdDto>> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var result = await _taskRepository.GetTaskById(request.Id);
            return _mapper.Map<List<TaskForGetByIdDto>>(result);
        }
    }
}
