using FluentValidation;

namespace ITS.PMT.Api.Application.Queries.RoleType.GetAllGroupPermissionById
{
    public sealed class GetAllGroupPermissionByIdQueryValidator : AbstractValidator<GetAllGroupPermissionByIdQuery>
    {
        public GetAllGroupPermissionByIdQueryValidator()
        {
            RuleFor(v => v.Id).NotEqual(0).NotNull().NotEmpty().WithMessage("Id cannot be null");
        }
    }
}
