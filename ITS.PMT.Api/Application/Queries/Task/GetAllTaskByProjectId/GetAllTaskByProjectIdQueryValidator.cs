using FluentValidation;

namespace ITS.PMT.Api.Application.Queries.Task.GetTaskByProjectId
{
    public sealed class GetAllTaskByProjectIdQueryValidator : AbstractValidator<GetAllTaskByProjectIdQuery>
    {
        public GetAllTaskByProjectIdQueryValidator()
        {
            RuleFor(x => x.ProjectId).NotEqual(0).WithMessage("ProjecId is not empty");
        }
    }
}
