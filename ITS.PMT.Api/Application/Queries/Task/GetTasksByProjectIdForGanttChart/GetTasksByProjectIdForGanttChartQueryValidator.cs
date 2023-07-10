using FluentValidation;


namespace ITS.PMT.Api.Application.Queries.Task.GetTasksByProjectIdForGanttChart
{
    public sealed class GetTasksByProjectIdForGanttChartQueryValidator : AbstractValidator<GetTasksByProjectIdForGanttChartQuery>
    {
        public GetTasksByProjectIdForGanttChartQueryValidator()
        {
            RuleFor(x => x.ProjectId).NotEqual(0).WithMessage("Project Id can't be empty!");
        }
    }
}
