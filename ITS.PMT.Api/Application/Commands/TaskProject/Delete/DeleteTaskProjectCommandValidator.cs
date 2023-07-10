using FluentValidation;

namespace ITS.PMT.Api.Application.Commands.TaskProject.Delete
{
    public sealed class DeleteTaskProjectCommandValidator : AbstractValidator<DeleteTaskProjectCommand>
    {
        public DeleteTaskProjectCommandValidator()
        {
            RuleFor(x => x.Id).NotEqual(0).WithMessage("Id cannot be empty!");
        }
    }
}

