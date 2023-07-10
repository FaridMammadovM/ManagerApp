using FluentValidation;
using ITS.PMT.Domain.Dto.TaskDtos;
using ITS.PMT.Infrastructure.Repositories.TaskRepository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Queries.Task.GetTasksByProjectIdForGanttChart
{
    public sealed class GetTasksByProjectIdForGanttChartQueryHandler : IRequestHandler<GetTasksByProjectIdForGanttChartQuery, List<GetTasksByProjectIdForGanttChartDto>>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IValidator<GetTasksByProjectIdForGanttChartQuery> _validator;
        public GetTasksByProjectIdForGanttChartQueryHandler(ITaskRepository taskRepository, IValidator<GetTasksByProjectIdForGanttChartQuery> validator)
        {
            _taskRepository = taskRepository;
            _validator = validator;
        }

        public async Task<List<GetTasksByProjectIdForGanttChartDto>> Handle(GetTasksByProjectIdForGanttChartQuery request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            return await _taskRepository.GetTasksByProjectIdForGanttChart(request.ProjectId);
        }
    }
}
