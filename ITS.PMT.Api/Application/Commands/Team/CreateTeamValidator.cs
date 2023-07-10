using FluentValidation;

namespace ITS.PMT.Api.Application.Commands.Team
{
    public sealed class CreateTeamValidator : AbstractValidator<CreateTeamCommand>
    {
        public CreateTeamValidator()
        {
            RuleFor(t => t.EmployeeId).NotEqual(0).WithMessage("Id cannot be null");
            RuleFor(t => t.RoleId).NotEqual(0).WithMessage("Id cannot be null");
            RuleFor(t => t.ProjectId).NotEqual(0).WithMessage("Id cannot be null");

        }
    }
}
