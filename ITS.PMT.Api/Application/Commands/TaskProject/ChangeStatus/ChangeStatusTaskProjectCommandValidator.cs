using FluentValidation;

namespace ITS.PMT.Api.Application.Commands.TaskProject.ChangeStatus
{
    public sealed class ChangeStatusTaskProjectCommandValidator : AbstractValidator<ChangeStatusTaskProjectCommand>
    {
        public ChangeStatusTaskProjectCommandValidator()
        {
            RuleFor(v => v.Id).NotNull().NotEmpty().WithMessage("Id cannot be null")
               .GreaterThan(0).WithMessage("Id should be greater than 0");
            RuleFor(v => v.Status).NotNull().NotEmpty().WithMessage("Status cannot be null")
                 .Must(x => x == 1 || x == 2).WithMessage("Status must be 1 or 2."); ;

        }
    }
}
