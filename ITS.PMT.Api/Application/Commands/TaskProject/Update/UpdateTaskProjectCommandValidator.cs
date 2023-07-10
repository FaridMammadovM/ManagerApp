using FluentValidation;
using System;

namespace ITS.PMT.Api.Application.Commands.TaskProject.Update
{
    public sealed class UpdateTaskProjectCommandValidator : AbstractValidator<UpdateTaskProjectCommand>
    {
        public UpdateTaskProjectCommandValidator()
        {
            RuleFor(v => v.Id).NotNull().NotEmpty().WithMessage("Id cannot be null")
               .GreaterThan(0).WithMessage("Id should be greater than 0");
            RuleFor(v => v.TaskName).NotNull().NotEmpty().WithMessage("TaskName cannot be null");
            RuleFor(v => v.DateNo).NotNull().NotEmpty().WithMessage("DateNo cannot be null")
                .Must(x => x == 1 || x == 2).WithMessage("DateNo must be 1 or 2.");
            When(v => v.DateNo == 1, () =>
            {
                RuleFor(v => v.Deadline).NotNull().NotEmpty().WithMessage("Deadline cannot be null");
            });
            When(v => v.DateNo == 2, () =>
            {
                RuleFor(v => v.Reason)
                    .NotNull().NotEmpty().WithMessage("Reason cannot be null or empty.");
                RuleFor(v => v.Deadline)
       .Must(d => d == null || d == DateTime.MinValue || d == DateTime.MaxValue || d == DateTime.MinValue.AddTicks(-1))
       .WithMessage("Deadline can be null or empty.");
            });
            RuleFor(v => v.ProjectId).NotNull().NotEmpty().WithMessage("ProjectId cannot be null")
               .GreaterThan(0).WithMessage("ProjectId should be greater than 0");


        }
    }
}
