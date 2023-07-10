using FluentValidation;

namespace ITS.PMT.Api.Application.Queries.TaskProject.GetTaskProjectById
{
    public sealed class GetTaskProjectByIdQueryValidator : AbstractValidator<GetTaskProjectByIdQuery>
    {

        public GetTaskProjectByIdQueryValidator()
        {
            RuleFor(t => t.Id).NotEqual(0).WithMessage("Id can't be empty!");
        }

    }
}

