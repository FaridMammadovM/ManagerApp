using AutoMapper;
using FluentValidation;
using ITS.PMT.Domain.Dto.TaskProjectDtos;
using ITS.PMT.Infrastructure.Repositories.TaskProjectRepository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Queries.TaskProject.GetAll
{
    public sealed class GetAllTaskProjectByProjectIdQueryHandler : IRequestHandler<GetAllTaskProjectByProjectIdQuery, List<GetAllTaskProjectByProjectIdDto>>
    {
        private readonly ITaskProjectRepository _taskRepository;
        private readonly IValidator<GetAllTaskProjectByProjectIdQuery> _validator;
        public GetAllTaskProjectByProjectIdQueryHandler(ITaskProjectRepository taskRepository, IMapper mapper, IValidator<GetAllTaskProjectByProjectIdQuery> validator)
        {
            _taskRepository = taskRepository;
            _validator = validator;
        }

        async Task<List<GetAllTaskProjectByProjectIdDto>> IRequestHandler<GetAllTaskProjectByProjectIdQuery,
            List<GetAllTaskProjectByProjectIdDto>>.Handle(GetAllTaskProjectByProjectIdQuery request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var result = await _taskRepository.GetAllTaskProjectByProjectId(request.ProjectId);
            return result;
        }
    }
}