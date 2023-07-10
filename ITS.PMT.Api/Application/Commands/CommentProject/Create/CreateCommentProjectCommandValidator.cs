using FluentValidation;

namespace ITS.PMT.Api.Application.Commands.CommentProject.Create
{
    public sealed class CreateCommentProjectCommandValidator : AbstractValidator<CreateCommentProjectCommand>
    {
        public CreateCommentProjectCommandValidator()
        {
            RuleFor(x => x.createCommentDto.Note).NotNull().WithMessage("Insert text can not empty");
            RuleFor(x => x.createCommentDto.UserId).NotNull().WithMessage("UserId must not be empty!")
                .NotEqual(0).WithMessage("Insert userId can not empty");
            RuleFor(x => x.createCommentDto.ProjectId).NotNull().WithMessage("ProjectId must not be empty!")
                .NotEqual(0).WithMessage("Insert userId can not empty");

        }
    }
}

