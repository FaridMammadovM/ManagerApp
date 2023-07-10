using FluentValidation;

namespace ITS.PMT.Api.Application.Queries.Team
{
    public sealed class GetTeamByProjectIdValidator : AbstractValidator<GetTeamByProjectIdQuery>
    {
        public GetTeamByProjectIdValidator()
        {
            RuleFor(t => t.ProjectId).NotEqual(0).WithMessage("Id cannot be null");
        }
    }
}
