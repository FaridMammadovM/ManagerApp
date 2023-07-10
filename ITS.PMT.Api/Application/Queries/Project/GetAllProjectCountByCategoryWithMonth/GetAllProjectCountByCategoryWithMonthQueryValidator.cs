using FluentValidation;

namespace ITS.PMT.Api.Application.Queries.Project.GetAllProjectCountByCategoryWithMonth
{
    public sealed class GetAllProjectCountByCategoryWithMonthQueryValidator : AbstractValidator<GetAllProjectCountByCategoryWithMonthQuery>
    {
        public GetAllProjectCountByCategoryWithMonthQueryValidator()
        {
            RuleFor(x => x.Id).NotEqual(0).WithMessage("Id is not empty");
        }
    }
}