using FluentValidation;

namespace ITS.PMT.Api.Application.Commands.Task.UpdateTask
{
    public sealed class UpdateTaskValidator : AbstractValidator<UpdateTaskCommand>
    {
        public UpdateTaskValidator()
        {
            RuleFor(t => t.Id).NotEqual(0).NotNull().WithMessage("Id cannot be 0!");
            RuleFor(t => t.StatusId).NotNull().WithMessage("It can not be empty");
            // RuleFor(t => t.TaskNo).NotNull().WithMessage("It can not be empty");
            // RuleFor(t => t.TaskNo).NotNull().WithMessage("It can not be empty");
            //RuleFor(t => t.PerfIndicator).NotNull().WithMessage("It can not be empty");
            RuleFor(t => t.StageId).NotNull().WithMessage("It can not be empty");
            RuleFor(t => t.ProjectId).NotNull().WithMessage("It can not be empty");
            RuleFor(t => t.TeamId).NotNull().WithMessage("It can not be empty");



        }
    }
}
