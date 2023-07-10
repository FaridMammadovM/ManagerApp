using FluentValidation;

namespace ITS.PMT.Api.Application.Queries.Parametric.Employee.GetEmployee
{
    public sealed class GetEmployeeByRoleIdQueryValidator : AbstractValidator<GetEmployeeByRoleIdQuery>
    {
        public GetEmployeeByRoleIdQueryValidator()
        {
            RuleFor(t => t.RoleId).NotEqual(0).WithMessage("RoleId can't be empty!");

        }


    }

}

