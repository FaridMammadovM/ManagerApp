using FluentValidation;

namespace ITS.PMT.Api.Application.Commands.Project.UpdateProjectPriority
{
    public sealed class UpdateProjectPriorityCommandValidator : AbstractValidator<UpdateProjectPriorityCommand>
    {
        public UpdateProjectPriorityCommandValidator()
        {
            RuleFor(x => x.Id).NotEqual(0).NotEmpty()
                .WithMessage("Id not null");
            RuleFor(x => x.PriorityId).NotEqual(0)
                .NotEmpty()
                .WithMessage("Id not null");
        }
    }
}
