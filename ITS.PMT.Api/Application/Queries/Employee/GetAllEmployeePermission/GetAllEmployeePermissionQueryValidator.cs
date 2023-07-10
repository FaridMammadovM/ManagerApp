using FluentValidation;

namespace ITS.PMT.Api.Application.Queries.Employee.GetAllEmployeePermission
{
    public sealed class GetAllEmployeePermissionQueryValidator : AbstractValidator<GetAllEmployeePermissionQuery>
    {
        public GetAllEmployeePermissionQueryValidator()
        {
            RuleFor(v => v.Id).NotEqual(0).NotNull().NotEmpty().WithMessage("Id cannot be null");
        }
    }
}