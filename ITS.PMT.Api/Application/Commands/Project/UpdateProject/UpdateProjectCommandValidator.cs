using FluentValidation;

namespace ITS.PMT.Api.Application.Commands.Project.UpdateProject
{
    public sealed class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectCommand>
    {
        public UpdateProjectCommandValidator()
        {
            RuleFor(x => x.ProjectForUpdateDto.Id).NotEqual(0).WithMessage("Id not null");
            //RuleFor(x =>x.ProjectForUpdateDto.UpdateUser).NotNull().WithMessage("UpdateUser can not null");
        }
    }
}
