using FluentValidation;

namespace ITS.PMT.Api.Application.Queries.Project.GetAllProjectNameByCategory
{
    public sealed class GetAllProjectNameByCategoryQueryValidator : AbstractValidator<GetAllProjectNameByCategoryQuery>
    {
        public GetAllProjectNameByCategoryQueryValidator()
        {
            RuleFor(x => x.Id).NotEqual(0).WithMessage("Id is not empty");
        }
    }
}