using FluentValidation;

namespace ITS.PMT.Api.Application.Commands.Comment
{
    public sealed class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator()
        {
            //RuleFor(x => x.createCommentDto.InsertUser).NotNull().WithMessage("Insert user name can not empty");
            RuleFor(x => x.createCommentDto.MeetingId).NotEqual(0).WithMessage("Meeting Id can not empty");
        }
    }
}
