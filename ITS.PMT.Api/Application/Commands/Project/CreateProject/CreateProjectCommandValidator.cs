using FluentValidation;

namespace ITS.PMT.Api.Application.Commands.Project.CreateProject
{
    public sealed class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(t => t.projectForCreationDto.ProjectName).NotNull().WithMessage("ProjectName must not be empty!");
            //RuleFor(t => t.projectForCreationDto.ProjectCode).NotNull().WithMessage("ProjectCode must not be empty!");
            //RuleFor(t => t.projectForCreationDto.DepartmentDesc).NotNull().WithMessage("DepartmentDesc must not be empty!");
            //RuleFor(t => t.projectForCreationDto.Description).NotNull().WithMessage("Description must not be empty!");
        }
    }
}
