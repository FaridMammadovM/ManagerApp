using FluentValidation;

namespace ITS.PMT.Api.Application.Commands.Team.DeleteTeam
{
    public sealed class DeleteTeamCommandValidator : AbstractValidator<DeleteTeamCommand>
    {
        public DeleteTeamCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id should not be null or empty!");
        }
    }
}
