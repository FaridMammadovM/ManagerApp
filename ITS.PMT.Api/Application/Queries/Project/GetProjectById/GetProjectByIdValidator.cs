using FluentValidation;

namespace ITS.PMT.Api.Application.Queries.Project.GetProjectById
{
    public sealed class GetProjectByIdValidator : AbstractValidator<GetProjectByIdQuery>
    {
        public GetProjectByIdValidator()
        {
            RuleFor(t => t.Id).NotEqual(0).NotNull().WithMessage("Id cannot be 0!");

        }
    }
}
