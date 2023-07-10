using FluentValidation;

namespace ITS.PMT.Api.Application.Queries.Project.GetAdditionallInfo
{
    public sealed class GetAdditionallInfoQueryValidator : AbstractValidator<GetAdditionallInfoQuery>
    {
        public GetAdditionallInfoQueryValidator()
        {
            RuleFor(x => x.ProjectId).NotEqual(0).NotEmpty().WithMessage("ProjectId is not empty and zero");
        }
    }
}
