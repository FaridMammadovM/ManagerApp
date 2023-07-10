using FluentValidation;
using ITS.PMT.Api.Application.Queries.Team.GetTaskById;

namespace ITS.PMT.Api.Application.Queries.Task.GetTaskById
{
    public sealed class GetTaskByIdQueryValidator : AbstractValidator<GetTaskByIdQuery>
    {

        public GetTaskByIdQueryValidator()
        {
            RuleFor(t => t.Id).NotEqual(0).WithMessage("Id can't be empty!");
        }

    }
}
