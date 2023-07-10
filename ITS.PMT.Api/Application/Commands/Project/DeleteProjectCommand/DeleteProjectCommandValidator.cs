using FluentValidation;

namespace ITS.PMT.Api.Application.Commands.Project.DeleteProjectCommand
{
    public sealed class DeleteProjectCommandValidator : AbstractValidator<DeleteProjectCommand>
    {
        public DeleteProjectCommandValidator()
        {
            RuleFor(x => x.Id).NotEqual(0).WithMessage("Id cannot be empty!");
        }
    }
}
