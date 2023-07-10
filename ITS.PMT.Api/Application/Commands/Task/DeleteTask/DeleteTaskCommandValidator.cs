using FluentValidation;

namespace ITS.PMT.Api.Application.Commands.Task.DeleteTask
{
    public sealed class DeleteTaskCommandValidator : AbstractValidator<DeleteTaskCommand>
    {
        public DeleteTaskCommandValidator()
        {
            RuleFor(x => x.Id).NotEqual(0).WithMessage("Id should not be null or empty!");

        }
    }
}
