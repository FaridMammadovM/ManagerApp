using FluentValidation;

namespace ITS.PMT.Api.Application.Queries.DeadlineOutInfo.GetDeadlineOutInfoByProjectId
{
    public sealed class GetDeadlineOutInfoByProjectIdQueryValidator : AbstractValidator<GetDeadlineOutInfoByProjectIdQuery>
    {
        public GetDeadlineOutInfoByProjectIdQueryValidator()
        {
            RuleFor(x => x.ProjectId).NotEmpty().WithMessage("Project Id can not be empty");
        }

    }
}
