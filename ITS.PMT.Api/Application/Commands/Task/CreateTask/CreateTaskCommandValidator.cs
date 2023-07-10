using FluentValidation;

namespace ITS.PMT.Api.Application.Commands.Task.CreateTask
{
    public sealed class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
    {
        public CreateTaskCommandValidator()
        {
            //RuleFor(t => t.TaskName).NotEmpty().MinimumLength(4).WithMessage("Task Name cannot be null!");
            //RuleFor(t => t.TaskNo).NotEmpty().MinimumLength(4).WithMessage("Task No cannot be null!");
            RuleFor(t => t.taskForCreationDto.StatusId).NotEqual(0).NotNull().WithMessage("StatusId cannot be 0!");
            RuleFor(t => t.taskForCreationDto.TeamId).NotEqual(0).NotNull().WithMessage("TeamId cannot be 0!");
            RuleFor(t => t.taskForCreationDto.ProjectId).NotEqual(0).NotNull().WithMessage("ProjectId cannot be 0!");
            RuleFor(t => t.taskForCreationDto.StageId).NotEqual(0).NotNull().WithMessage("StageId cannot be 0!");
            RuleFor(t => t.taskForCreationDto.TaskName).NotEmpty().NotNull().WithMessage("TaskName is not null");
        }
    }
}
