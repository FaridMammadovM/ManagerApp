using ITS.PMT.Domain.Dto.TaskDtos;
using MediatR;
using System.Collections.Generic;

namespace ITS.PMT.Api.Application.Queries.Task.GetTasksByProjectIdForGanttChart
{
    public class GetTasksByProjectIdForGanttChartQuery : IRequest<List<GetTasksByProjectIdForGanttChartDto>>
    {
        public int ProjectId { get; set; }
    }
}
