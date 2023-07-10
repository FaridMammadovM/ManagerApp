using FluentValidation;

namespace ITS.PMT.Api.Application.Queries.RoleType.GetAllGroupUserById
{
    public sealed class GetAllGroupUserByIdQueryValidator : AbstractValidator<GetAllGroupUserByIdQuery>
    {
        public GetAllGroupUserByIdQueryValidator()
        {
            RuleFor(v => v.Id).NotEqual(0).NotNull().NotEmpty().WithMessage("Id cannot be null");
        }
    }
}