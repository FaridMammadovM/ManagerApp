using FluentValidation;

namespace ITS.PMT.Api.Application.Commands.RoleType.Delete
{
    public sealed class DeleteRoleTypeCommandValidator : AbstractValidator<DeleteRoleTypeCommand>
    {
        public DeleteRoleTypeCommandValidator()
        {
            RuleFor(t => t.Id).NotNull().WithMessage("Id must not be empty!")
                                  .GreaterThan(0).WithMessage("Id should be greater than 0");

        }
    }
}
