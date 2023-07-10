using FluentValidation;

namespace ITS.PMT.Api.Application.Queries.RoleType.GetById
{
    public sealed class GetByIdRoleTypeQueryValidator : AbstractValidator<GetByIdRoleTypeQuery>
    {
        public GetByIdRoleTypeQueryValidator()
        {
            RuleFor(v => v.Id).NotEqual(0).NotNull().NotEmpty().WithMessage("Id cannot be null");
        }
    }
}
