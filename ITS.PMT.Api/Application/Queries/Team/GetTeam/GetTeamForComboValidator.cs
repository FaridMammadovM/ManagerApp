using FluentValidation;

namespace ITS.PMT.Api.Application.Queries.Team.GetTeam
{
    public sealed class GetTeamForComboValidator : AbstractValidator<GetTeamForComboQuery>
    {
        public GetTeamForComboValidator()
        {
            RuleFor(t => t.Projectid).NotEqual(0).WithMessage("Id cannot be null");

        }
    }
}
