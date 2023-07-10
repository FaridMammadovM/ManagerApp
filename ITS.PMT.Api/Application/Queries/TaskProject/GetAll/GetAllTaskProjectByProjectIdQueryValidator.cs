using FluentValidation;

namespace ITS.PMT.Api.Application.Queries.TaskProject.GetAll
{
    public sealed class GetAllTaskProjectByProjectIdQueryValidator : AbstractValidator<GetAllTaskProjectByProjectIdQuery>
    {
        public GetAllTaskProjectByProjectIdQueryValidator()
        {
            RuleFor(x => x.ProjectId).NotEqual(0).WithMessage("ProjecId is not empty");
        }
    }
}
