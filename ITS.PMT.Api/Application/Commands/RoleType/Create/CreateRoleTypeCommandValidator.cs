using FluentValidation;

namespace ITS.PMT.Api.Application.Commands.RoleType.Create
{
    public sealed class CreateRoleTypeCommandValidator : AbstractValidator<CreateRoleTypeCommand>
    {
        public CreateRoleTypeCommandValidator()
        {
            RuleFor(t => t.Name).NotNull().WithMessage("Name must not be empty!");
            RuleFor(t => t.UserId).NotNull().WithMessage("UserId must not be empty!")
                                  .GreaterThan(0).WithMessage("UserId should be greater than 0");
        }
    }
}
